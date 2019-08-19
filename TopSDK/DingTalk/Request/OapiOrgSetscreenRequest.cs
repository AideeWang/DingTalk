using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.org.setscreen
    /// </summary>
    public class OapiOrgSetscreenRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiOrgSetscreenResponse>
    {
        /// <summary>
        /// yyyy-MM-dd显示截止时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 点击开机图片跳转地址
        /// </summary>
        public string JumpUrl { get; set; }

        /// <summary>
        /// 开机图片资源id，可以通过/media/upload接口上传图片获取
        /// </summary>
        public string MediaId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.org.setscreen";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("endTime", this.EndTime);
            parameters.Add("jumpUrl", this.JumpUrl);
            parameters.Add("mediaId", this.MediaId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("endTime", this.EndTime);
            RequestValidator.ValidateRequired("mediaId", this.MediaId);
        }

        #endregion
    }
}
