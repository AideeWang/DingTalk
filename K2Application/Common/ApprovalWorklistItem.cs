using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace K2Application.Common
{
    [DataContract]
    public class ApprovalWorklistItem
    {
        [DataMember]
        public string SN { get; set; }
        /// <summary>
        /// 流程审批实例
        /// </summary>
        [DataMember]
        public string ProcInstID { get; set; }
        /// <summary>
        /// 流程Folio
        /// </summary>
        [DataMember]
        public string Folio { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        [DataMember]
        public string ProcessName { get; set; }
        /// <summary>
        /// 流程申请时间
        /// </summary>
        [DataMember]
        public string StartDate { get; set; }
        /// <summary>
        /// 当前流程节点
        /// </summary>
        [DataMember]
        public string CurActivityName { get; set; }
        /// <summary>
        /// 审批页面地址
        /// </summary>
        [DataMember]
        public string URL { get; set; }

        /// <summary>
        /// 流程申请人
        /// </summary>
        [DataMember]
        public string ApplyUser { get; set; }
        /// <summary>
        /// 流程状态
        /// </summary>
       // public string Status { get; set; }

    }
}
