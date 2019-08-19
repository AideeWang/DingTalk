using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiAlitripBtripFlightOrderSearchResponse.
    /// </summary>
    public class OapiAlitripBtripFlightOrderSearchResponse : DingTalkResponse
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
        /// 机票列表
        /// </summary>
        [XmlArray("flight_order_list")]
        [XmlArrayItem("open_flight_order_rs")]
        public List<OpenFlightOrderRsDomain> FlightOrderList { get; set; }

        /// <summary>
        /// 成功标识
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

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
/// OpenPriceInfoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenPriceInfoDomain : TopObject
{
	        /// <summary>
	        /// 交易类目
	        /// </summary>
	        [XmlElement("category")]
	        public string Category { get; set; }
	
	        /// <summary>
	        /// 流水创建时间
	        /// </summary>
	        [XmlElement("gmt_create")]
	        public string GmtCreate { get; set; }
	
	        /// <summary>
	        /// 乘机人，多个用‘,’分割
	        /// </summary>
	        [XmlElement("passenger_name")]
	        public string PassengerName { get; set; }
	
	        /// <summary>
	        /// 结算方式:1：个人现付，2:企业现付,4:企业月结，8、企业预存
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
/// OpenFlightInsureInfoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenFlightInsureInfoDomain : TopObject
{
	        /// <summary>
	        /// 保单号
	        /// </summary>
	        [XmlElement("insure_no")]
	        public string InsureNo { get; set; }
	
	        /// <summary>
	        /// 乘机人(保险人)姓名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 状态：1已出保 2已退保
	        /// </summary>
	        [XmlElement("status")]
	        public long Status { get; set; }
}

	/// <summary>
/// OpenUserAffiliateDoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenUserAffiliateDoDomain : TopObject
{
	        /// <summary>
	        /// 出行人名称
	        /// </summary>
	        [XmlElement("user_name")]
	        public string UserName { get; set; }
	
	        /// <summary>
	        /// 出行人ID
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

	/// <summary>
/// OpenFlightOrderRsDomain Data Structure.
/// </summary>
[Serializable]

public class OpenFlightOrderRsDomain : TopObject
{
	        /// <summary>
	        /// 商旅申请单id
	        /// </summary>
	        [XmlElement("apply_id")]
	        public string ApplyId { get; set; }
	
	        /// <summary>
	        /// 到达机场
	        /// </summary>
	        [XmlElement("arr_airport")]
	        public string ArrAirport { get; set; }
	
	        /// <summary>
	        /// 到达城市
	        /// </summary>
	        [XmlElement("arr_city")]
	        public string ArrCity { get; set; }
	
	        /// <summary>
	        /// 舱位类型
	        /// </summary>
	        [XmlElement("cabin_class")]
	        public string CabinClass { get; set; }
	
	        /// <summary>
	        /// 联系人
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
	        /// 出发机场
	        /// </summary>
	        [XmlElement("dep_airport")]
	        public string DepAirport { get; set; }
	
	        /// <summary>
	        /// 出发城市
	        /// </summary>
	        [XmlElement("dep_city")]
	        public string DepCity { get; set; }
	
	        /// <summary>
	        /// 出发日期
	        /// </summary>
	        [XmlElement("dep_date")]
	        public string DepDate { get; set; }
	
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
	        /// 折扣
	        /// </summary>
	        [XmlElement("discount")]
	        public string Discount { get; set; }
	
	        /// <summary>
	        /// 航班号
	        /// </summary>
	        [XmlElement("flight_no")]
	        public string FlightNo { get; set; }
	
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
	        /// 机票订单id
	        /// </summary>
	        [XmlElement("id")]
	        public long Id { get; set; }
	
	        /// <summary>
	        /// 保险信息
	        /// </summary>
	        [XmlArray("insureInfo_list")]
	        [XmlArrayItem("open_flight_insure_info")]
	        public List<OpenFlightInsureInfoDomain> InsureInfoList { get; set; }
	
	        /// <summary>
	        /// 发票信息对象
	        /// </summary>
	        [XmlElement("invoice")]
	        public OpenInvoiceDoDomain Invoice { get; set; }
	
	        /// <summary>
	        /// 乘机人数量
	        /// </summary>
	        [XmlElement("passenger_count")]
	        public long PassengerCount { get; set; }
	
	        /// <summary>
	        /// 乘机人，多个用‘,’分割
	        /// </summary>
	        [XmlElement("passenger_name")]
	        public string PassengerName { get; set; }
	
	        /// <summary>
	        /// 价目信息
	        /// </summary>
	        [XmlArray("price_info_list")]
	        [XmlArrayItem("open_price_info")]
	        public List<OpenPriceInfoDomain> PriceInfoList { get; set; }
	
	        /// <summary>
	        /// 到达日期
	        /// </summary>
	        [XmlElement("ret_date")]
	        public string RetDate { get; set; }
	
	        /// <summary>
	        /// 订单状态：0待支付,1出票中,2已关闭,3有改签单,4有退票单,5出票成功,6退票申请中,7改签申请中
	        /// </summary>
	        [XmlElement("status")]
	        public long Status { get; set; }
	
	        /// <summary>
	        /// 第三方行程id
	        /// </summary>
	        [XmlElement("thirdpart_itinerary_id")]
	        public string ThirdpartItineraryId { get; set; }
	
	        /// <summary>
	        /// 行程类型。0:单程，1:往返，2:中转
	        /// </summary>
	        [XmlElement("trip_type")]
	        public long TripType { get; set; }
	
	        /// <summary>
	        /// 出行人列表
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
