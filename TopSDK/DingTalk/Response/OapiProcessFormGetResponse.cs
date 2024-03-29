using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiProcessFormGetResponse.
    /// </summary>
    public class OapiProcessFormGetResponse : DingTalkResponse
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
        /// result
        /// </summary>
        [XmlElement("result")]
        public ProcessTopVoDomain Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// FormComponentStatVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponentStatVoDomain : TopObject
{
	        /// <summary>
	        /// 组件id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 标题
	        /// </summary>
	        [XmlElement("label")]
	        public string Label { get; set; }
	
	        /// <summary>
	        /// 单位
	        /// </summary>
	        [XmlElement("unit")]
	        public string Unit { get; set; }
	
	        /// <summary>
	        /// 是否大写
	        /// </summary>
	        [XmlElement("upper")]
	        public bool Upper { get; set; }
}

	/// <summary>
/// FormComponentPropVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponentPropVoDomain : TopObject
{
	        /// <summary>
	        /// 业务别名, 当组件属于业务套件的一部分时方便业务识别(DDBizSuite)
	        /// </summary>
	        [XmlElement("biz_alias")]
	        public string BizAlias { get; set; }
	
	        /// <summary>
	        /// 业务套件类型(DDBizSuite)
	        /// </summary>
	        [XmlElement("biz_type")]
	        public string BizType { get; set; }
	
	        /// <summary>
	        /// 套件内子组件可见性，key为label，value=false不可见
	        /// </summary>
	        [XmlElement("child_field_visible")]
	        public string ChildFieldVisible { get; set; }
	
	        /// <summary>
	        /// 是否可编辑
	        /// </summary>
	        [XmlElement("disable")]
	        public bool Disable { get; set; }
	
	        /// <summary>
	        /// id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 隐藏字段
	        /// </summary>
	        [XmlElement("invisible")]
	        public bool Invisible { get; set; }
	
	        /// <summary>
	        /// 标题
	        /// </summary>
	        [XmlElement("label")]
	        public string Label { get; set; }
	
	        /// <summary>
	        /// 是否参与打印(1表示不打印, 0表示打印)
	        /// </summary>
	        [XmlElement("not_print")]
	        public string NotPrint { get; set; }
	
	        /// <summary>
	        /// 是否需要大写 默认是需要; 1:不需要大写, 空或者0:需要大写
	        /// </summary>
	        [XmlElement("not_upper")]
	        public string NotUpper { get; set; }
	
	        /// <summary>
	        /// 必填
	        /// </summary>
	        [XmlElement("required")]
	        public bool Required { get; set; }
	
	        /// <summary>
	        /// 明细里需要统计的字段
	        /// </summary>
	        [XmlArray("stat_field")]
	        [XmlArrayItem("form_component_stat_vo")]
	        public List<FormComponentStatVoDomain> StatField { get; set; }
}

	/// <summary>
/// FormComponent2VoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponent2VoDomain : TopObject
{
	        /// <summary>
	        /// 组件类型
	        /// </summary>
	        [XmlElement("component_name")]
	        public string ComponentName { get; set; }
	
	        /// <summary>
	        /// 组件属性
	        /// </summary>
	        [XmlElement("props")]
	        public FormComponentPropVoDomain Props { get; set; }
}

	/// <summary>
/// FormComponent1VoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponent1VoDomain : TopObject
{
	        /// <summary>
	        /// 子组件
	        /// </summary>
	        [XmlArray("children")]
	        [XmlArrayItem("form_component2_vo")]
	        public List<FormComponent2VoDomain> Children { get; set; }
	
	        /// <summary>
	        /// 组件类型
	        /// </summary>
	        [XmlElement("component_name")]
	        public string ComponentName { get; set; }
	
	        /// <summary>
	        /// 组件属性
	        /// </summary>
	        [XmlElement("props")]
	        public FormComponentPropVoDomain Props { get; set; }
}

	/// <summary>
/// FormComponentVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponentVoDomain : TopObject
{
	        /// <summary>
	        /// 子组件
	        /// </summary>
	        [XmlArray("children")]
	        [XmlArrayItem("form_component1_vo")]
	        public List<FormComponent1VoDomain> Children { get; set; }
	
	        /// <summary>
	        /// 组件类型
	        /// </summary>
	        [XmlElement("component_name")]
	        public string ComponentName { get; set; }
	
	        /// <summary>
	        /// 是否为旧套件
	        /// </summary>
	        [XmlElement("is_old_suite")]
	        public bool IsOldSuite { get; set; }
	
	        /// <summary>
	        /// 组件属性
	        /// </summary>
	        [XmlElement("props")]
	        public FormComponentPropVoDomain Props { get; set; }
}

	/// <summary>
/// ProcessTopVoDomain Data Structure.
/// </summary>
[Serializable]

public class ProcessTopVoDomain : TopObject
{
	        /// <summary>
	        /// 表单列表
	        /// </summary>
	        [XmlArray("form_component_vos")]
	        [XmlArrayItem("form_component_vo")]
	        public List<FormComponentVoDomain> FormComponentVos { get; set; }
	
	        /// <summary>
	        /// 是否开启手写签名
	        /// </summary>
	        [XmlElement("hand_sign_enable")]
	        public bool HandSignEnable { get; set; }
	
	        /// <summary>
	        /// 图片地址
	        /// </summary>
	        [XmlElement("icon_url")]
	        public string IconUrl { get; set; }
	
	        /// <summary>
	        /// 模板名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

    }
}
