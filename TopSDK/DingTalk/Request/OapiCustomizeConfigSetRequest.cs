using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.customize.config.set
    /// </summary>
    public class OapiCustomizeConfigSetRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiCustomizeConfigSetResponse>
    {
        /// <summary>
        /// e应用id
        /// </summary>
        public string ActiveId { get; set; }

        /// <summary>
        /// e应用
        /// </summary>
        public string ActiveType { get; set; }

        /// <summary>
        /// 入口会话id，自定义的业务
        /// </summary>
        public string Biz { get; set; }

        /// <summary>
        /// 二级会话
        /// </summary>
        public string RuleName { get; set; }

        /// <summary>
        /// 会话类型
        /// </summary>
        public string Type { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.customize.config.set";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("active_id", this.ActiveId);
            parameters.Add("active_type", this.ActiveType);
            parameters.Add("biz", this.Biz);
            parameters.Add("rule_name", this.RuleName);
            parameters.Add("type", this.Type);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("active_id", this.ActiveId);
            RequestValidator.ValidateRequired("active_type", this.ActiveType);
            RequestValidator.ValidateRequired("biz", this.Biz);
            RequestValidator.ValidateRequired("rule_name", this.RuleName);
            RequestValidator.ValidateRequired("type", this.Type);
        }

        #endregion
    }
}
