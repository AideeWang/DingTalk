using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using SourceCode.Workflow.Client;
using SourceCode.Workflow.Management;
using System.Data;

namespace K2Application.Common
{
    public static class K2WorkflowHelper
    {
        #region 字段
        private static string PlanServer = AppSettings.Get("PlanServer");

        public static string MngUserID = AppSettings.Get("MngUserID");

        private static string MngUserPassword = AppSettings.Get("MngUserPassword");

        private static string StringTableType = AppSettings.Get("StringTableType");

        private static string K2ConnectionString = AppSettings.Get("K2ConnectionString");

        private static readonly string ACTIONNAME = "Task Completed";//节点审批成功(任务自动完成)
        private static readonly string PLATFORM = "ASP";
        private static readonly string CENLINE =@"K2:CENTALINE\";


        #endregion

        #region 存储过程 名称

        /// <summary>
        /// 获取流程类型 
        /// </summary>
        private readonly static string SERVER_MPROCSETGET = "[Server].[mProcSetGet]";

        private readonly static string GETWORKLISTITEMCOMPLETED = "[Utility].[GetWorkListItemCompleted]";

        #endregion


        /// <summary>
        /// 获取K2连接
        /// </summary>
        /// <returns></returns>
        public static Connection GetK2Connection()
        {
            try
            {
                Connection oK2Connection = new Connection();
                string K2Server = PlanServer;
                string mngUserID = MngUserID;
                string mngUserPasswrod = Cryptography.DESDecryption(MngUserPassword);
                string connectionString = "[;];Authentication=Windows;Domain=centaline;User=" + mngUserID + ";Password=" + mngUserPasswrod + "";

                oK2Connection.Open(K2Server, connectionString);
                return oK2Connection;
            }
            catch (Exception ex)
            {
                LogHelper.Debug("K2 链接发生错误： " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 得到K2连接串
        /// </summary>
        /// <returns></returns>
        public static string GetK2ManagementServerConnectionString()
        {
            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString;
            connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            connectionString.Authenticate = true;
            connectionString.WindowsDomain = "CENTALINE";
            connectionString.SecurityLabelName = "K2";
            connectionString.UserID = MngUserID;
            connectionString.Password = Cryptography.DESDecryption(MngUserPassword);
            connectionString.Host = PlanServer;
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5555;
            return connectionString.ToString();
        }

        /// <summary>
        /// 获取流程的全称
        /// </summary>
        /// <returns></returns>
        public static string GetWorkflowName(string WorkflowTypeName)
        {
            WorkflowManagementServer wms = new WorkflowManagementServer();
            wms.Open(GetK2ManagementServerConnectionString());
            ProcessSets processSets = wms.GetProcSets();
            foreach (ProcessSet procSet in processSets)
            {
                if (procSet.StringTable == StringTableType && procSet.Name == WorkflowTypeName)
                    return procSet.FullName;
            }
            return "";
        }

        /// <summary>
        /// 模拟用户
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="user"></param>
        public static void ImpersonateUser(Connection connection, string user)
        {
            if (user.IndexOf(CENLINE) < 0)
            {
                user = CENLINE + user;
            }
            connection.ImpersonateUser(user);//模拟审批者
        }

        /// <summary>
        /// 根据流程类型生成 Folio
        /// </summary>
        /// <returns></returns>
        public static string CreateFolio(string WorkflowTypeName, ApplyUserInfo ApplyUserInfo)
        {
            switch (WorkflowTypeName)
            {
                case "上海职员劳务合同审批":
                    return "[" + ApplyUserInfo.ApplyDeptName + " " + ApplyUserInfo.ApplyUserName + "/" + ApplyUserInfo.ApplyUserId + "]提交的" + WorkflowTypeName;
                default:
                    return "";
            }
        }

        /// <summary>
        /// 发起新的流程实例
        /// </summary>
        /// <param name="WorkflowTypeName">流程类型</param>
        /// <param name="dicDataFields">流程参数集合</param>
        /// <param name="Folio">流程单号</param>
        /// <param name="Sync">发起流程是否异步（默认否）</param>
        /// <returns></returns>
        public static void StartProcessInstance(string WorkflowTypeName, Dictionary<string, object> dicDataFields, string ApplyUserInfoString, bool Sync = false)
        {
            Connection connection = GetK2Connection();//创建K2 链接
            try
            {
                string ProcessInstanceName = GetWorkflowName(WorkflowTypeName);//获取流程全称

                //创建新的流程实例
                SourceCode.Workflow.Client.ProcessInstance pi = connection.CreateProcessInstance(ProcessInstanceName);
                var PIDataFields = pi.DataFields;

                //循环赋值流程参数
                foreach (var dic in dicDataFields)
                {
                    PIDataFields[dic.Key].Value = dic.Value;
                }
                ApplyUserInfo applyUserInfo = ApplyUserInfoString.ToObject<ApplyUserInfo>();

                pi.Folio = CreateFolio(WorkflowTypeName, applyUserInfo);

                //添加审批历史
                string ApprovalResultXML=string.Empty;
                ApprovalResultXML = XMLApproval.ToResultXML(ApprovalResultXML);
                XMLApproval xmlApproval = new XMLApproval();
                xmlApproval.LoadFromXML(ApprovalResultXML);
                xmlApproval.AddApproval(applyUserInfo.ApplyUserName, applyUserInfo.ApplyUserId, "发起", string.Empty, "发起流程");
                pi.XmlFields["ApprovalResult"].Value = xmlApproval.ToXML();

                //发起流程实例
                connection.StartProcessInstance(pi, Sync);
            }
            catch (Exception ex)
            {
                throw new K2Exception(ex.ToString());
            }
            finally
            {
                // 关闭连接
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #region 审批流程实例


        /// <summary>
        /// 审批流程实例
        /// </summary>
        /// <param name="SN">流程编号</param>
        /// <param name="DicDataFields">流程参数</param>
        /// <param name="ManagedUser">流程审批者</param>
        /// <param name="SharedUser">流程共同审批者</param>
        /// <param name="ActionName">流程动作</param>
        /// <param name="Platform">流程审批页面平台</param>
        public static void ApprovalProcessInstance(string SN, Dictionary<string, object> DicDataFields, string ApprovalUserInfoString)
        {
            Connection Connection = GetK2Connection();//创建K2 链接
            try
            {

                ApprovalUserInfo ApprovalUserInfo = ApprovalUserInfoString.ToObject<ApprovalUserInfo>();
                ImpersonateUser(Connection, ApprovalUserInfo.ApprovalUserId);

                //获取流程工作项
                SourceCode.Workflow.Client.WorklistItem wit = GetWorkListItemBySN(Connection, SN, ApprovalUserInfo.ManagedUser, ApprovalUserInfo.SharedUser, PLATFORM);

                BatchSetInstanceDataFields(wit, DicDataFields);

                //添加审批历史
                AddProcessInstanceApprovalHistory(wit, ApprovalUserInfo);

                //设置审批动作 （节点审批成功(任务自动完成)）
                string ActionName = string.IsNullOrEmpty(ApprovalUserInfo.ActionName) ? ACTIONNAME : ApprovalUserInfo.ActionName;
                //执行审批动作
                wit.Actions[ActionName].Execute();
            }
            catch (Exception ex)
            {
                throw new K2Exception(ex.ToString());
            }
            finally
            {
                // 关闭连接
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
        }



        /// <summary>
        /// 根据SN 获取流程工作项
        /// </summary>
        /// <param name="Connection">K2 链接</param>
        /// <param name="sn">SN 流程编号</param>
        /// <param name="ManagedUser">审批者</param>
        /// <param name="SharedUser">共同审批者</param>
        /// <param name="Platform">平台</param>
        /// <returns></returns>
        public static SourceCode.Workflow.Client.WorklistItem GetWorkListItemBySN(Connection Connection, string sn, string ManagedUser, string SharedUser, string Platform)
        {

            SourceCode.Workflow.Client.WorklistItem worklistItem = null;
            //正常的
            if ((string.IsNullOrEmpty(SharedUser)) && (ManagedUser == string.Empty))
            {
                worklistItem = Connection.OpenWorklistItem(sn, Platform);
            }

            if ((!string.IsNullOrEmpty(SharedUser)) && (ManagedUser == string.Empty))
            {
                worklistItem = Connection.OpenSharedWorklistItem(SharedUser, ManagedUser, sn);
            }

            if ((string.IsNullOrEmpty(SharedUser)) && (ManagedUser != string.Empty))
            {
                worklistItem = Connection.OpenManagedWorklistItem(ManagedUser, sn);
            }

            // 检查是否为委托的
            if ((!string.IsNullOrEmpty(SharedUser)) && (ManagedUser != string.Empty))
            {
                worklistItem = Connection.OpenSharedWorklistItem(SharedUser, ManagedUser, sn);
            }

            return worklistItem;
        }
        #endregion

        #region 操作流程实例数据字段

        /// <summary>
        /// 获取流程实例数据字段
        /// </summary>
        /// <param name="oK2Connection"></param>
        /// <param name="sn"></param>
        /// <param name="fieldName"></param>
        /// <param name="isXMLField"></param>
        /// <param name="managedUser"></param>
        /// <param name="sharedUser"></param>
        /// <returns></returns>
        public static string GetInstanceDataFields(SourceCode.Workflow.Client.WorklistItem worklistItem, string fieldName, bool isXMLField)
        {
            string retValue = "";
            if (worklistItem != null)
            {
                if (isXMLField)
                {
                    retValue = worklistItem.ProcessInstance.XmlFields[fieldName].Value.ToString();
                }
                else
                {
                    retValue = worklistItem.ProcessInstance.DataFields[fieldName].Value.ToString();
                }
            }

            return retValue;
        }

        //修改流程实例数据字段
        public static void SetInstanceDataFields(SourceCode.Workflow.Client.WorklistItem worklistItem, string fieldName, string fieldValue, bool isXMLField)
        {
            if (worklistItem != null)
            {
                if (isXMLField)
                {
                    worklistItem.ProcessInstance.XmlFields[fieldName].Value = fieldValue;
                }
                else
                {
                    worklistItem.ProcessInstance.DataFields[fieldName].Value = fieldValue;
                }
            }
        }

        /// <summary>
        /// 批量修改流程实例数据字段
        /// </summary>
        public static void BatchSetInstanceDataFields(SourceCode.Workflow.Client.WorklistItem worklistItem, Dictionary<string, object> DicDataFields)
        {
            foreach (var dic in DicDataFields)
            {
                worklistItem.ProcessInstance.DataFields[dic.Key].Value = dic.Value;
            }
        }

        /// <summary>
        /// 获取当前流程实例节点名称
        /// </summary>
        /// <param name="worklistItem"></param>
        /// <returns></returns>
        public static string GetCurrentActivityName(SourceCode.Workflow.Client.WorklistItem worklistItem)
        {
            return worklistItem.ActivityInstanceDestination.Name;
        }

        public static string GetK2ProcessFolder()
        {
            WorkflowManagementServer wms = new WorkflowManagementServer();
            wms.Open(GetK2ManagementServerConnectionString());
            ProcessSets processSets = wms.GetProcSets();
            foreach (ProcessSet procSet in processSets)
            {
                if (procSet.StringTable == StringTableType)
                    return procSet.Folder;
            }
            return "";
        }

        #endregion

        #region 流程实例审批历史
        /// <summary>
        /// 添加流程实例审批历史
        /// </summary>
        public static void AddProcessInstanceApprovalHistory(SourceCode.Workflow.Client.WorklistItem worklistItem, ApprovalUserInfo ApprovalUserInfo)
        {
            //获取流程审批历史
            string ApprovalResultXML = GetInstanceDataFields(worklistItem, "ApprovalResult", true);
            string LastApprovalResultXML = GetInstanceDataFields(worklistItem, "LastApprovalResult", true);
            ApprovalResultXML = XMLApproval.ToResultXML(ApprovalResultXML);
            LastApprovalResultXML = XMLApproval.ToResultXML(LastApprovalResultXML);

            XMLApproval xmlApproval = new XMLApproval();
            //增加一个审批记录
            xmlApproval.LoadFromXML(ApprovalResultXML);
            xmlApproval.AddApproval(ApprovalUserInfo.ApprovalUserName, ApprovalUserInfo.ApprovalUserId, ApprovalUserInfo.ComAuditText, ApprovalUserInfo.ComAuditComment, GetCurrentActivityName(worklistItem));
            SetInstanceDataFields(worklistItem, "ApprovalResult", xmlApproval.ToXML(), true);

            //设置最后审批历史记录				
            xmlApproval.LoadFromXML(LastApprovalResultXML);
            xmlApproval.SetLastApproval(ApprovalUserInfo.ApprovalUserName, ApprovalUserInfo.ApprovalUserId, ApprovalUserInfo.ComAuditText, ApprovalUserInfo.ComAuditComment, GetCurrentActivityName(worklistItem));
            SetInstanceDataFields(worklistItem, "LastApprovalResult", xmlApproval.ToXML(), true);

            //设置审批结果
            SetInstanceDataFields(worklistItem, "ComAuditComment", ApprovalUserInfo.ComAuditComment, false);
            SetInstanceDataFields(worklistItem, "ComAuditResult", ApprovalUserInfo.ComAuditResult, false);
        }

        /// <summary>
        /// 获取流程实例审批历史（转JSON）
        /// </summary>
        /// <param name="SN"></param>
        /// <param name="ApprovalUserId"></param>
        /// <returns></returns>
        public static string GetProcessInstanceApprovalHistory(string SN, string ApprovalUserId)
        {
            Connection connection = GetK2Connection();
            try
            {
                ImpersonateUser(connection, ApprovalUserId);
                SourceCode.Workflow.Client.WorklistItem worklistItem = connection.OpenWorklistItem(SN);
                string ApprovalResultXML = worklistItem.ProcessInstance.XmlFields["ApprovalResult"].Value;
                if (ApprovalResultXML != null)
                {
                    XMLApproval xmlApproval = new XMLApproval();
                    xmlApproval.LoadFromXML(ApprovalResultXML);
                    return xmlApproval.mobj.ToJson();
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new K2Exception(ex.ToString());
            }
            finally
            {
                // 关闭连接
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region 流程审批列表
        /// <summary>
        /// 获取当前审批者列表（包括委托）
        /// </summary>
        /// <param name="ApproverUser"></param>
        public static List<ApprovalWorklistItem> GetCurrentUserWorkListItem(string ApproverUser)
        {
            Connection connection = GetK2Connection();
            try
            {
                ImpersonateUser(connection, ApproverUser);
                List<ApprovalWorklistItem> ApprovalWorklistItemList = new List<ApprovalWorklistItem>();
                //获取审批列表添加条件
                SourceCode.Workflow.Client.WorklistCriteria criteria = new SourceCode.Workflow.Client.WorklistCriteria();
                criteria.Platform = "ASP";
                //添加流程文件类别条件
                criteria.AddFilterField(SourceCode.Workflow.Client.WCLogical.And, SourceCode.Workflow.Client.WCField.ProcessFolder, SourceCode.Workflow.Client.WCCompare.Equal, GetK2ProcessFolder());
                //添加审批者的列表
                criteria.AddFilterField(SourceCode.Workflow.Client.WCLogical.And, SourceCode.Workflow.Client.WCField.WorklistItemOwner, "Me", SourceCode.Workflow.Client.WCCompare.Equal, SourceCode.Workflow.Client.WCWorklistItemOwner.Me);

                //添加审批者委托的列表
                //criteria.AddFilterField(SourceCode.Workflow.Client.WCLogical.Or, SourceCode.Workflow.Client.WCField.WorklistItemOwner, "Other", SourceCode.Workflow.Client.WCCompare.Equal, SourceCode.Workflow.Client.WCWorklistItemOwner.Other);
                Worklist worklist = connection.OpenWorklist(criteria);

                if (worklist != null && worklist.Count > 0)
                {
                    foreach (SourceCode.Workflow.Client.WorklistItem item in worklist)
                    {
                        var work = new ApprovalWorklistItem();
                        work.SN = item.SerialNumber;
                        work.ProcInstID = item.ProcessInstance.ID.ToString();
                        work.ProcessName = item.ProcessInstance.Name.Substring(4, item.ProcessInstance.Name.Length - 4);
                        work.Folio = item.ProcessInstance.Folio;
                        work.StartDate = item.ActivityInstanceDestination.StartDate.ToString("yyyy-MM-dd HH:mm:ss");
                        work.CurActivityName = item.ActivityInstanceDestination.Name;
                        work.URL = item.Data;

                        ApprovalWorklistItemList.Add(work);
                    }
                    ApprovalWorklistItemList.OrderByDescending(a => a.StartDate);
                }
                return ApprovalWorklistItemList;

            }
            catch (Exception ex)
            {
                throw new K2Exception(ex.ToString());
            }
            finally
            {
                // 关闭连接
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 获取当前审批完成的列表
        /// </summary>
        /// <param name="ApproverUser"></param>
        public static string GetCurrentUserCompletedWorkListItem(string ApproverUser)
        {
            SqlHelper sqlHelper = new SqlHelper(K2ConnectionString);
            try
            {
                if(ApproverUser.IndexOf(CENLINE)<0){
                    ApproverUser=CENLINE+ApproverUser;
                }
                DataTable dt=  sqlHelper.ExecuteDataTable(string.Format("exec {0} '{1}'", GETWORKLISTITEMCOMPLETED, ApproverUser));
                var approvalCompletedWorkListItemList = dt.ToList<ApprovalCompletedWorkListItem>();
                approvalCompletedWorkListItemList.ForEach(a => a.Name = a.Name.Substring(4, a.Name.Length - 4));
                return approvalCompletedWorkListItemList.ToJson();
            }
            catch (Exception ex)
            {
                throw new K2Exception(ex.ToString());
            }
        } 
        #endregion

        #region 设置流程实例
        /// <summary>
        /// 设置流程实例最新版本，重试流程错误
        /// </summary>
        /// <param name="procInstID"></param>
        public static void SetProcessInstanceVersionRetry(int procInstID) 
        {
            WorkflowManagementServer wms = new WorkflowManagementServer();
            wms.Open(GetK2ManagementServerConnectionString());
           
            SqlHelper sqlHelper = new SqlHelper(K2ConnectionString);
            var dt=  sqlHelper.ExecuteDataTable(string.Format("EXEC Utility.GetProcInstNewVersionByProcInstID {0}",procInstID));
            int Ver = Convert.ToInt32(dt.Rows[0]["Ver"]);
            int ErrorID = Convert.ToInt32(dt.Rows[0]["ErrorID"]);
            if (ErrorID != 0)
            {
                wms.SetProcessInstanceVersion(procInstID, Ver);

                wms.RetryError(procInstID, ErrorID, MngUserID);
            }
          
        }

        public static void SetProcessInstanceVersion() 
        {
            WorkflowManagementServer wms = new WorkflowManagementServer();
            wms.Open(GetK2ManagementServerConnectionString());
           // wms.StopProcessInstances

             SqlHelper sqlHelper = new SqlHelper(K2ConnectionString);

             var dt = sqlHelper.ExecuteDataTable("SELECT ID FROM Server.ProcInst WHERE ProcID IN (1202,1217,1195,1176)");
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     wms.StopProcessInstances(Convert.ToInt32(dr["ID"]));
                     wms.SetProcessInstanceVersion(Convert.ToInt32(dr["ID"]), 68);
                     wms.StartProcessInstances(Convert.ToInt32(dr["ID"]));
                 }
             }


        } 



        #endregion

    }
}
