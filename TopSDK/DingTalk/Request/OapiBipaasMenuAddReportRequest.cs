using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.bipaas.menu.add_report
    /// </summary>
    public class OapiBipaasMenuAddReportRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiBipaasMenuAddReportResponse>
    {
        /// <summary>
        /// 金融云租户ID信息
        /// </summary>
        public string AntcloudTenantId { get; set; }

        /// <summary>
        /// 智能参谋菜单ID
        /// </summary>
        public Nullable<long> MenuId { get; set; }

        /// <summary>
        /// 报表ID列表
        /// </summary>
        public string ReportIds { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.bipaas.menu.add_report";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("antcloud_tenant_id", this.AntcloudTenantId);
            parameters.Add("menu_id", this.MenuId);
            parameters.Add("report_ids", this.ReportIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("antcloud_tenant_id", this.AntcloudTenantId);
            RequestValidator.ValidateRequired("menu_id", this.MenuId);
            RequestValidator.ValidateRequired("report_ids", this.ReportIds);
            RequestValidator.ValidateMaxListSize("report_ids", this.ReportIds, 20);
        }

        #endregion
    }
}
