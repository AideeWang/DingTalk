using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.bipaas.notify.grouprobot
    /// </summary>
    public class OapiBipaasNotifyGrouprobotRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiBipaasNotifyGrouprobotResponse>
    {
        /// <summary>
        /// 群机器人通知请求
        /// </summary>
        public string RobotNotify { get; set; }

        public GroupRobotNotifyDtoDomain RobotNotify_ { set { this.RobotNotify = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.bipaas.notify.grouprobot";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("robot_notify", this.RobotNotify);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// GroupRobotNotifyDtoDomain Data Structure.
/// </summary>
[Serializable]

public class GroupRobotNotifyDtoDomain : TopObject
{
	        /// <summary>
	        /// 需要@到的金融云租户下操作员列表
	        /// </summary>
	        [XmlArray("antcloud_operator_ids")]
	        [XmlArrayItem("string")]
	        public List<string> AntcloudOperatorIds { get; set; }
	
	        /// <summary>
	        /// 金融云租户 ID
	        /// </summary>
	        [XmlElement("antcloud_tenant_id")]
	        public string AntcloudTenantId { get; set; }
	
	        /// <summary>
	        /// 对应消息格式内容
	        /// </summary>
	        [XmlElement("message_body")]
	        public string MessageBody { get; set; }
	
	        /// <summary>
	        /// 消息格式
	        /// </summary>
	        [XmlElement("message_type")]
	        public string MessageType { get; set; }
	
	        /// <summary>
	        /// 钉钉群机器人地址
	        /// </summary>
	        [XmlElement("robot_url")]
	        public string RobotUrl { get; set; }
}

        #endregion
    }
}
