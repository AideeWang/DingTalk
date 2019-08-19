using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.newretail.sendsms
    /// </summary>
    public class OapiNewretailSendsmsRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiNewretailSendsmsResponse>
    {
        /// <summary>
        /// 短信接受者信息
        /// </summary>
        public string Smsmodule { get; set; }

        public List<SmsModelDomain> Smsmodule_ { set { this.Smsmodule = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.newretail.sendsms";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("smsmodule", this.Smsmodule);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateObjectMaxListSize("smsmodule", this.Smsmodule, 20);
        }

	/// <summary>
/// SmsModelDomain Data Structure.
/// </summary>
[Serializable]

public class SmsModelDomain : TopObject
{
	        /// <summary>
	        /// 品牌名
	        /// </summary>
	        [XmlElement("brandname")]
	        public string Brandname { get; set; }
	
	        /// <summary>
	        /// 员工id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
	
	        /// <summary>
	        /// 员工nick
	        /// </summary>
	        [XmlElement("username")]
	        public string Username { get; set; }
}

        #endregion
    }
}
