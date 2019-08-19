using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiNewretailQueryorginfoResponse.
    /// </summary>
    public class OapiNewretailQueryorginfoResponse : DingTalkResponse
    {
        /// <summary>
        /// dingOpenErrcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public OrgDomain Result { get; set; }

	/// <summary>
/// OrgDomain Data Structure.
/// </summary>
[Serializable]

public class OrgDomain : TopObject
{
	        /// <summary>
	        /// licenseMediaId
	        /// </summary>
	        [XmlElement("licensemediaid")]
	        public string Licensemediaid { get; set; }
	
	        /// <summary>
	        /// orgName
	        /// </summary>
	        [XmlElement("orgname")]
	        public string Orgname { get; set; }
	
	        /// <summary>
	        /// registNum
	        /// </summary>
	        [XmlElement("registnum")]
	        public string Registnum { get; set; }
	
	        /// <summary>
	        /// unifiedSocialCredit
	        /// </summary>
	        [XmlElement("unifiedsocialcredit")]
	        public string Unifiedsocialcredit { get; set; }
	
	        /// <summary>
	        /// unnameorganizationCoded
	        /// </summary>
	        [XmlElement("unnameorganizationcoded")]
	        public string Unnameorganizationcoded { get; set; }
}

    }
}
