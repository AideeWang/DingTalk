using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiAlitripBtripHotelOrderSearchResponse.
    /// </summary>
    public class OapiAlitripBtripHotelOrderSearchResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 酒店订单列表
        /// </summary>
        [XmlArray("module")]
        [XmlArrayItem("open_hotel_order_rs")]
        public List<OpenHotelOrderRsDomain> Module { get; set; }

        /// <summary>
        /// 成功标识
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// OpenCostCenterDoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenCostCenterDoDomain : TopObject
{
	        /// <summary>
	        /// 企业id
	        /// </summary>
	        [XmlElement("corpid")]
	        public string Corpid { get; set; }
	
	        /// <summary>
	        /// 商旅成本中心id
	        /// </summary>
	        [XmlElement("id")]
	        public long Id { get; set; }
	
	        /// <summary>
	        /// 成本中心名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 成本中心编号
	        /// </summary>
	        [XmlElement("number")]
	        public string Number { get; set; }
}

	/// <summary>
/// OpenInvoiceDoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenInvoiceDoDomain : TopObject
{
	        /// <summary>
	        /// 商旅发票id
	        /// </summary>
	        [XmlElement("id")]
	        public long Id { get; set; }
	
	        /// <summary>
	        /// 发票抬头
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// OpenPriceInfoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenPriceInfoDomain : TopObject
{
	        /// <summary>
	        /// 交易类型
	        /// </summary>
	        [XmlElement("category")]
	        public string Category { get; set; }
	
	        /// <summary>
	        /// 流水创建时间
	        /// </summary>
	        [XmlElement("gmt_create")]
	        public string GmtCreate { get; set; }
	
	        /// <summary>
	        /// 入住人信息，多个用‘,’分割
	        /// </summary>
	        [XmlElement("passenger_name")]
	        public string PassengerName { get; set; }
	
	        /// <summary>
	        /// 结算方式:1个人现付，2:企业现付,4:企业月结，8企业预存
	        /// </summary>
	        [XmlElement("pay_type")]
	        public long PayType { get; set; }
	
	        /// <summary>
	        /// 价格
	        /// </summary>
	        [XmlElement("price")]
	        public string Price { get; set; }
	
	        /// <summary>
	        /// 资金流向:1:支出，2:收入
	        /// </summary>
	        [XmlElement("type")]
	        public long Type { get; set; }
}

	/// <summary>
/// OpenUserAffiliateDoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenUserAffiliateDoDomain : TopObject
{
	        /// <summary>
	        /// 入住人名称
	        /// </summary>
	        [XmlElement("user_name")]
	        public string UserName { get; set; }
	
	        /// <summary>
	        /// 入住人ID
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

	/// <summary>
/// OpenHotelOrderRsDomain Data Structure.
/// </summary>
[Serializable]

public class OpenHotelOrderRsDomain : TopObject
{
	        /// <summary>
	        /// 商旅申请单id
	        /// </summary>
	        [XmlElement("apply_id")]
	        public long ApplyId { get; set; }
	
	        /// <summary>
	        /// 入住时间
	        /// </summary>
	        [XmlElement("check_in")]
	        public string CheckIn { get; set; }
	
	        /// <summary>
	        /// 离店时间
	        /// </summary>
	        [XmlElement("check_out")]
	        public string CheckOut { get; set; }
	
	        /// <summary>
	        /// 酒店所在城市
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 联系人姓名
	        /// </summary>
	        [XmlElement("contact_name")]
	        public string ContactName { get; set; }
	
	        /// <summary>
	        /// 企业名称
	        /// </summary>
	        [XmlElement("corp_name")]
	        public string CorpName { get; set; }
	
	        /// <summary>
	        /// 企业id
	        /// </summary>
	        [XmlElement("corpid")]
	        public string Corpid { get; set; }
	
	        /// <summary>
	        /// 成本中心对象
	        /// </summary>
	        [XmlElement("cost_center")]
	        public OpenCostCenterDoDomain CostCenter { get; set; }
	
	        /// <summary>
	        /// 部门名称
	        /// </summary>
	        [XmlElement("dept_name")]
	        public string DeptName { get; set; }
	
	        /// <summary>
	        /// 部门id
	        /// </summary>
	        [XmlElement("deptid")]
	        public string Deptid { get; set; }
	
	        /// <summary>
	        /// 创建时间
	        /// </summary>
	        [XmlElement("gmt_create")]
	        public string GmtCreate { get; set; }
	
	        /// <summary>
	        /// 更新时间
	        /// </summary>
	        [XmlElement("gmt_modified")]
	        public string GmtModified { get; set; }
	
	        /// <summary>
	        /// 入住顾客，多个用','分割
	        /// </summary>
	        [XmlElement("guest")]
	        public string Guest { get; set; }
	
	        /// <summary>
	        /// 酒店名称
	        /// </summary>
	        [XmlElement("hotel_name")]
	        public string HotelName { get; set; }
	
	        /// <summary>
	        /// 订单id
	        /// </summary>
	        [XmlElement("id")]
	        public long Id { get; set; }
	
	        /// <summary>
	        /// 发票对象
	        /// </summary>
	        [XmlElement("invoice")]
	        public OpenInvoiceDoDomain Invoice { get; set; }
	
	        /// <summary>
	        /// 总共住几晚
	        /// </summary>
	        [XmlElement("night")]
	        public long Night { get; set; }
	
	        /// <summary>
	        /// 订单状态
	        /// </summary>
	        [XmlElement("order_status")]
	        public long OrderStatus { get; set; }
	
	        /// <summary>
	        /// 订单状态描述
	        /// </summary>
	        [XmlElement("order_status_desc")]
	        public string OrderStatusDesc { get; set; }
	
	        /// <summary>
	        /// 订单类型
	        /// </summary>
	        [XmlElement("order_type")]
	        public long OrderType { get; set; }
	
	        /// <summary>
	        /// 订单类型描述
	        /// </summary>
	        [XmlElement("order_type_desc")]
	        public string OrderTypeDesc { get; set; }
	
	        /// <summary>
	        /// 价目详情列表
	        /// </summary>
	        [XmlArray("price_info_list")]
	        [XmlArrayItem("open_price_info")]
	        public List<OpenPriceInfoDomain> PriceInfoList { get; set; }
	
	        /// <summary>
	        /// 房间数
	        /// </summary>
	        [XmlElement("room_num")]
	        public long RoomNum { get; set; }
	
	        /// <summary>
	        /// 房型
	        /// </summary>
	        [XmlElement("room_type")]
	        public string RoomType { get; set; }
	
	        /// <summary>
	        /// 第三方行程id
	        /// </summary>
	        [XmlElement("thirdpart_itinerary_id")]
	        public string ThirdpartItineraryId { get; set; }
	
	        /// <summary>
	        /// 入住人列表
	        /// </summary>
	        [XmlArray("user_affiliate_list")]
	        [XmlArrayItem("open_user_affiliate_do")]
	        public List<OpenUserAffiliateDoDomain> UserAffiliateList { get; set; }
	
	        /// <summary>
	        /// 用户名称
	        /// </summary>
	        [XmlElement("user_name")]
	        public string UserName { get; set; }
	
	        /// <summary>
	        /// 用户id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

    }
}
