using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiBlackboardListtoptenResponse.
    /// </summary>
    public class OapiBlackboardListtoptenResponse : DingTalkResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlArray("blackboard_list")]
        [XmlArrayItem("oapi_blackboard_vo")]
        public List<OapiBlackboardVoDomain> BlackboardList { get; set; }

        /// <summary>
        /// errcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errmsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

	/// <summary>
/// OapiBlackboardVoDomain Data Structure.
/// </summary>
[Serializable]

public class OapiBlackboardVoDomain : TopObject
{
	        /// <summary>
	        /// 创建时间
	        /// </summary>
	        [XmlElement("gmt_create")]
	        public string GmtCreate { get; set; }
	
	        /// <summary>
	        /// 标题
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
	
	        /// <summary>
	        /// 跳转URL
	        /// </summary>
	        [XmlElement("url")]
	        public string Url { get; set; }
}

    }
}
