using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace K2Application.Common
{
    /// <summary>
    /// Summary description for XMLApproval.
    /// </summary>
    public class XMLApproval
    {
        public XmlDocument mobj = new XmlDocument();

        public XMLApproval()
        {
        }

        public bool LoadFromXML(string srcXML)
        {
            try
            {
                srcXML = srcXML.Replace("<<", "&lt;&lt;");
                srcXML = srcXML.Replace(">>", "&gt;&gt;");
                this.mobj.LoadXml(srcXML);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ToXML()
        {
            return this.mobj.OuterXml;
        }

        /// <summary>
        /// 增加一个历史审批记录

        /// </summary>
        /// <param name="Name"></param>
        /// <param name="DomainAccount"></param>
        /// <param name="ApprovalResult"></param>
        /// <param name="ApprovalComment"></param>
        /// <param name="ActivityName"></param>
        public void AddApproval(string Name, string DomainAccount, string ApprovalResult, string ApprovalComment, string ActivityName)
        {
            string strDomainAccount = DomainAccount;

            strDomainAccount = strDomainAccount.ToLower();
            strDomainAccount = strDomainAccount.Replace("centaline\\\\", "");

            System.Xml.XmlNode ApprovalNode = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "Approval", "");

            System.Xml.XmlNode tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "Name", "");
            tmp.InnerText = Name;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "DomainAccount", "");
            tmp.InnerText = strDomainAccount;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalResult", "");
            tmp.InnerText = ApprovalResult;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalComment", "");
            tmp.InnerText = ApprovalComment;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalTime", "");
            tmp.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ActivityName", "");
            tmp.InnerText = ActivityName;
            ApprovalNode.AppendChild(tmp);

            System.Xml.XmlNode pobj = this.mobj.SelectSingleNode("Root/Approvals");
            if (pobj == null)
            {
                throw new Exception("没有找到XML节点[Root/Approvals],请检查数据格式定义是否正确!");
            }
            else
            {
                tmp = pobj.FirstChild;
                if (tmp != null)
                {
                    if (tmp.InnerText.Trim() == "")	//如果<Approval></Approval>为空则要删除掉
                    {
                        pobj.RemoveChild(tmp);
                    }
                }
                pobj.AppendChild(ApprovalNode);
            }
        }

        /// <summary>
        /// 设置最后审批历史记录

        /// </summary>
        /// <param name="Name"></param>
        /// <param name="DomainAccount"></param>
        /// <param name="ApprovalResult"></param>
        /// <param name="ApprovalComment"></param>
        /// <param name="ActivityName"></param>
        public void SetLastApproval(string Name, string DomainAccount, string ApprovalResult, string ApprovalComment, string ActivityName)
        {
            string strDomainAccount = DomainAccount;

            strDomainAccount = GetShortADUserID(strDomainAccount);

            System.Xml.XmlNode ApprovalNode = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "Approval", "");

            System.Xml.XmlNode tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "Name", "");
            tmp.InnerText = Name;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "DomainAccount", "");
            tmp.InnerText = strDomainAccount;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalResult", "");
            tmp.InnerText = ApprovalResult;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalComment", "");
            tmp.InnerText = ApprovalComment;
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ApprovalTime", "");
            tmp.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ApprovalNode.AppendChild(tmp);

            tmp = this.mobj.CreateNode(System.Xml.XmlNodeType.Element, "ActivityName", "");
            tmp.InnerText = ActivityName;
            ApprovalNode.AppendChild(tmp);

            System.Xml.XmlNode pobj = this.mobj.SelectSingleNode("Root/Approvals");
            if (pobj == null)
            {
                throw new Exception("没有找到XML节点[Root/Approvals],请检查数据格式定义是否正确!");
            }
            else
            {
                tmp = pobj.FirstChild;
                if (tmp != null)
                {
                    if (tmp.InnerText.Trim() == "")
                    {
                        pobj.RemoveChild(tmp);
                    }
                }
                pobj.RemoveAll();				//清空旧的
                pobj.AppendChild(ApprovalNode); //加入新的
            }
        }

        public static string GetShortADUserID(string adUserID)
        {
            try
            {
                string result = adUserID;
                if (adUserID.Trim() != "")
                {
                    string delimStr = "\\";
                    char[] delimiter = delimStr.ToCharArray();
                    string[] split = null;
                    split = adUserID.Split(delimiter);
                    if (split.Length > 1)
                    {
                        result = split[1];
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ToResultXML(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Root><Approvals></Approvals></Root>";
            }
            return xml;
        }
    }
}
