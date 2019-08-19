using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiCateringStoreGetResponse.
    /// </summary>
    public class OapiCateringStoreGetResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [XmlElement("result")]
        public PageResultDomain Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// ManagerlistDomain Data Structure.
/// </summary>
[Serializable]

public class ManagerlistDomain : TopObject
{
	        /// <summary>
	        /// 门店店长工号
	        /// </summary>
	        [XmlElement("staff_id")]
	        public string StaffId { get; set; }
}

	/// <summary>
/// DataDomain Data Structure.
/// </summary>
[Serializable]

public class DataDomain : TopObject
{
	        /// <summary>
	        /// 部门编号
	        /// </summary>
	        [XmlElement("dept_id")]
	        public long DeptId { get; set; }
	
	        /// <summary>
	        /// 部门名称
	        /// </summary>
	        [XmlElement("dept_name")]
	        public string DeptName { get; set; }
	
	        /// <summary>
	        /// 门店店长列表
	        /// </summary>
	        [XmlArray("manager_list")]
	        [XmlArrayItem("managerlist")]
	        public List<ManagerlistDomain> ManagerList { get; set; }
	
	        /// <summary>
	        /// 部门类型，门店为store
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

	/// <summary>
/// PageResultDomain Data Structure.
/// </summary>
[Serializable]

public class PageResultDomain : TopObject
{
	        /// <summary>
	        /// 当前页码
	        /// </summary>
	        [XmlElement("current")]
	        public long Current { get; set; }
	
	        /// <summary>
	        /// 当前页数据
	        /// </summary>
	        [XmlArray("data")]
	        [XmlArrayItem("data")]
	        public List<DataDomain> Data { get; set; }
	
	        /// <summary>
	        /// 是否有下一页数据
	        /// </summary>
	        [XmlElement("has_more")]
	        public bool HasMore { get; set; }
	
	        /// <summary>
	        /// 每页记录数
	        /// </summary>
	        [XmlElement("page_size")]
	        public long PageSize { get; set; }
	
	        /// <summary>
	        /// 总记录数
	        /// </summary>
	        [XmlElement("total")]
	        public long Total { get; set; }
	
	        /// <summary>
	        /// 总页数
	        /// </summary>
	        [XmlElement("total_page")]
	        public long TotalPage { get; set; }
}

    }
}
