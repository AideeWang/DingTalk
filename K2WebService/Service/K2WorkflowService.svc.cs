using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using K2Application.Common;

namespace K2WebService.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class K2WorkflowService : IK2WorkflowService
    {
        /// <summary>
        /// 发起k2流程实例
        /// </summary>
        /// <param name="WorkflowTypeName">K2流程类型名称</param>
        /// <param name="dicDataFields">K2流程实例参数</param>
        /// <param name="ApplyUserInfo">K2申请人员信息</param>
        /// <returns></returns>
        public void StartProcessInstance(string WorkflowTypeName, Dictionary<string, object> dicDataFields, string ApplyUserInfo)
        {
            K2WorkflowHelper.StartProcessInstance(WorkflowTypeName, dicDataFields, ApplyUserInfo);
        }

        public List<ApprovalWorklistItem> GetCurrentUserWorkListItem(string ApprovalUser)
        {
            return K2WorkflowHelper.GetCurrentUserWorkListItem(ApprovalUser);
        }

        public void ApprovalProcessInstance(string SN, Dictionary<string, object> dicDataFields, string ApprovalUserInfo)
        {
            K2WorkflowHelper.ApprovalProcessInstance(SN, dicDataFields, ApprovalUserInfo);
        }

        public string GetProcessInstanceApprovalHistory(string SN, string ApprovalUserId)
        {
            return K2WorkflowHelper.GetProcessInstanceApprovalHistory(SN, ApprovalUserId);
        }

        public string GetCurrentUserCompletedWorkListItem(string ApprovalUser)
        {
            return K2WorkflowHelper.GetCurrentUserCompletedWorkListItem(ApprovalUser);
        }
    }
}
