using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.message.corpconversation.asyncsend_v2
    /// </summary>
    public class OapiMessageCorpconversationAsyncsendV2Request : BaseDingTalkRequest<DingTalk.Api.Response.OapiMessageCorpconversationAsyncsendV2Response>
    {
        /// <summary>
        /// 微应用的id
        /// </summary>
        public Nullable<long> AgentId { get; set; }

        /// <summary>
        /// 接收者的部门id列表
        /// </summary>
        public string DeptIdList { get; set; }

        /// <summary>
        /// 消息体，具体见文档
        /// </summary>
        public string Msg { get; set; }

        public MsgDomain Msg_ { set { this.Msg = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 是否发送给企业全部用户
        /// </summary>
        public Nullable<bool> ToAllUser { get; set; }

        /// <summary>
        /// 接收者的用户userid列表
        /// </summary>
        public string UseridList { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.message.corpconversation.asyncsend_v2";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("agent_id", this.AgentId);
            parameters.Add("dept_id_list", this.DeptIdList);
            parameters.Add("msg", this.Msg);
            parameters.Add("to_all_user", this.ToAllUser);
            parameters.Add("userid_list", this.UseridList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("agent_id", this.AgentId);
            RequestValidator.ValidateMaxListSize("dept_id_list", this.DeptIdList, 500);
            RequestValidator.ValidateRequired("msg", this.Msg);
            RequestValidator.ValidateMaxListSize("userid_list", this.UseridList, 5000);
        }

	/// <summary>
/// TextDomain Data Structure.
/// </summary>
[Serializable]

public class TextDomain : TopObject
{
	        /// <summary>
	        /// 文本消息
	        /// </summary>
	        [XmlElement("content")]
	        public string Content { get; set; }
}

	/// <summary>
/// ImageDomain Data Structure.
/// </summary>
[Serializable]

public class ImageDomain : TopObject
{
	        /// <summary>
	        /// 图片消息
	        /// </summary>
	        [XmlElement("media_id")]
	        public string MediaId { get; set; }
}

	/// <summary>
/// LinkDomain Data Structure.
/// </summary>
[Serializable]

public class LinkDomain : TopObject
{
	        /// <summary>
	        /// messageUrl
	        /// </summary>
	        [XmlElement("messageUrl")]
	        public string MessageUrl { get; set; }
	
	        /// <summary>
	        /// picUrl
	        /// </summary>
	        [XmlElement("picUrl")]
	        public string PicUrl { get; set; }
	
	        /// <summary>
	        /// text
	        /// </summary>
	        [XmlElement("text")]
	        public string Text { get; set; }
	
	        /// <summary>
	        /// title
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// FileDomain Data Structure.
/// </summary>
[Serializable]

public class FileDomain : TopObject
{
	        /// <summary>
	        /// media_id
	        /// </summary>
	        [XmlElement("media_id")]
	        public string MediaId { get; set; }
}

	/// <summary>
/// VoiceDomain Data Structure.
/// </summary>
[Serializable]

public class VoiceDomain : TopObject
{
	        /// <summary>
	        /// duration
	        /// </summary>
	        [XmlElement("duration")]
	        public string Duration { get; set; }
	
	        /// <summary>
	        /// media_id
	        /// </summary>
	        [XmlElement("media_id")]
	        public string MediaId { get; set; }
}

	/// <summary>
/// RichDomain Data Structure.
/// </summary>
[Serializable]

public class RichDomain : TopObject
{
	        /// <summary>
	        /// num
	        /// </summary>
	        [XmlElement("num")]
	        public string Num { get; set; }
	
	        /// <summary>
	        /// unit
	        /// </summary>
	        [XmlElement("unit")]
	        public string Unit { get; set; }
}

	/// <summary>
/// FormDomain Data Structure.
/// </summary>
[Serializable]

public class FormDomain : TopObject
{
	        /// <summary>
	        /// key
	        /// </summary>
	        [XmlElement("key")]
	        public string Key { get; set; }
	
	        /// <summary>
	        /// value
	        /// </summary>
	        [XmlElement("value")]
	        public string Value { get; set; }
}

	/// <summary>
/// BodyDomain Data Structure.
/// </summary>
[Serializable]

public class BodyDomain : TopObject
{
	        /// <summary>
	        /// author
	        /// </summary>
	        [XmlElement("author")]
	        public string Author { get; set; }
	
	        /// <summary>
	        /// content
	        /// </summary>
	        [XmlElement("content")]
	        public string Content { get; set; }
	
	        /// <summary>
	        /// file_count
	        /// </summary>
	        [XmlElement("file_count")]
	        public string FileCount { get; set; }
	
	        /// <summary>
	        /// form
	        /// </summary>
	        [XmlArray("form")]
	        [XmlArrayItem("form")]
	        public List<FormDomain> Form { get; set; }
	
	        /// <summary>
	        /// image
	        /// </summary>
	        [XmlElement("image")]
	        public string Image { get; set; }
	
	        /// <summary>
	        /// rich
	        /// </summary>
	        [XmlElement("rich")]
	        public RichDomain Rich { get; set; }
	
	        /// <summary>
	        /// title
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// HeadDomain Data Structure.
/// </summary>
[Serializable]

public class HeadDomain : TopObject
{
	        /// <summary>
	        /// bgcolor
	        /// </summary>
	        [XmlElement("bgcolor")]
	        public string Bgcolor { get; set; }
	
	        /// <summary>
	        /// text
	        /// </summary>
	        [XmlElement("text")]
	        public string Text { get; set; }
}

	/// <summary>
/// OADomain Data Structure.
/// </summary>
[Serializable]

public class OADomain : TopObject
{
	        /// <summary>
	        /// body
	        /// </summary>
	        [XmlElement("body")]
	        public BodyDomain Body { get; set; }
	
	        /// <summary>
	        /// head
	        /// </summary>
	        [XmlElement("head")]
	        public HeadDomain Head { get; set; }
	
	        /// <summary>
	        /// message_url
	        /// </summary>
	        [XmlElement("message_url")]
	        public string MessageUrl { get; set; }
	
	        /// <summary>
	        /// pc_message_url
	        /// </summary>
	        [XmlElement("pc_message_url")]
	        public string PcMessageUrl { get; set; }
}

	/// <summary>
/// MarkdownDomain Data Structure.
/// </summary>
[Serializable]

public class MarkdownDomain : TopObject
{
	        /// <summary>
	        /// text
	        /// </summary>
	        [XmlElement("text")]
	        public string Text { get; set; }
	
	        /// <summary>
	        /// title
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// BtnJsonListDomain Data Structure.
/// </summary>
[Serializable]

public class BtnJsonListDomain : TopObject
{
	        /// <summary>
	        /// action_url
	        /// </summary>
	        [XmlElement("action_url")]
	        public string ActionUrl { get; set; }
	
	        /// <summary>
	        /// title
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// ActionCardDomain Data Structure.
/// </summary>
[Serializable]

public class ActionCardDomain : TopObject
{
	        /// <summary>
	        /// btn_json_list
	        /// </summary>
	        [XmlArray("btn_json_list")]
	        [XmlArrayItem("btn_json_list")]
	        public List<BtnJsonListDomain> BtnJsonList { get; set; }
	
	        /// <summary>
	        /// btn_orientation
	        /// </summary>
	        [XmlElement("btn_orientation")]
	        public string BtnOrientation { get; set; }
	
	        /// <summary>
	        /// markdown
	        /// </summary>
	        [XmlElement("markdown")]
	        public string Markdown { get; set; }
	
	        /// <summary>
	        /// single_title
	        /// </summary>
	        [XmlElement("single_title")]
	        public string SingleTitle { get; set; }
	
	        /// <summary>
	        /// single_url
	        /// </summary>
	        [XmlElement("single_url")]
	        public string SingleUrl { get; set; }
	
	        /// <summary>
	        /// title
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// MsgDomain Data Structure.
/// </summary>
[Serializable]

public class MsgDomain : TopObject
{
	        /// <summary>
	        /// action_card
	        /// </summary>
	        [XmlElement("action_card")]
	        public ActionCardDomain ActionCard { get; set; }
	
	        /// <summary>
	        /// file
	        /// </summary>
	        [XmlElement("file")]
	        public FileDomain File { get; set; }
	
	        /// <summary>
	        /// 图片消息
	        /// </summary>
	        [XmlElement("image")]
	        public ImageDomain Image { get; set; }
	
	        /// <summary>
	        /// 链接消息
	        /// </summary>
	        [XmlElement("link")]
	        public LinkDomain Link { get; set; }
	
	        /// <summary>
	        /// markdown
	        /// </summary>
	        [XmlElement("markdown")]
	        public MarkdownDomain Markdown { get; set; }
	
	        /// <summary>
	        /// 消息类型
	        /// </summary>
	        [XmlElement("msgtype")]
	        public string Msgtype { get; set; }
	
	        /// <summary>
	        /// oa
	        /// </summary>
	        [XmlElement("oa")]
	        public OADomain Oa { get; set; }
	
	        /// <summary>
	        /// 文本消息
	        /// </summary>
	        [XmlElement("text")]
	        public TextDomain Text { get; set; }
	
	        /// <summary>
	        /// 语音消息
	        /// </summary>
	        [XmlElement("voice")]
	        public VoiceDomain Voice { get; set; }
}

        #endregion
    }
}
