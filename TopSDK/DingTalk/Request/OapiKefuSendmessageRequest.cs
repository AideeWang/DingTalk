using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.kefu.sendmessage
    /// </summary>
    public class OapiKefuSendmessageRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiKefuSendmessageResponse>
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消费者id
        /// </summary>
        public string Customerid { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string Msgtype { get; set; }

        /// <summary>
        /// 客服服务id
        /// </summary>
        public Nullable<long> Serviceid { get; set; }

        /// <summary>
        /// 消息token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 客服id
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.kefu.sendmessage";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            parameters.Add("customerid", this.Customerid);
            parameters.Add("msgtype", this.Msgtype);
            parameters.Add("serviceid", this.Serviceid);
            parameters.Add("token", this.Token);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("content", this.Content);
            RequestValidator.ValidateRequired("customerid", this.Customerid);
            RequestValidator.ValidateRequired("msgtype", this.Msgtype);
            RequestValidator.ValidateRequired("serviceid", this.Serviceid);
            RequestValidator.ValidateRequired("token", this.Token);
            RequestValidator.ValidateRequired("userid", this.Userid);
        }

        #endregion
    }
}
