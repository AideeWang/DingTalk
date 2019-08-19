using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.process.save
    /// </summary>
    public class OapiProcessSaveRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiProcessSaveResponse>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public string SaveProcessRequest { get; set; }

        public SaveProcessRequestDomain SaveProcessRequest_ { set { this.SaveProcessRequest = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.process.save";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("saveProcessRequest", this.SaveProcessRequest);
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
	        /// 组件名称
	        /// </summary>
	        [XmlElement("label")]
	        public string Label { get; set; }
	
	        /// <summary>
	        /// 单元
	        /// </summary>
	        [XmlElement("unit")]
	        public string Unit { get; set; }
	
	        /// <summary>
	        /// 统计总和是否大写
	        /// </summary>
	        [XmlElement("upper")]
	        public Nullable<bool> Upper { get; set; }
}

	/// <summary>
/// FormComponentPropVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormComponentPropVoDomain : TopObject
{
	        /// <summary>
	        /// 增加明细动作名称
	        /// </summary>
	        [XmlElement("action_name")]
	        public string ActionName { get; set; }
	
	        /// <summary>
	        /// 内部联系人choice，1表示多选，0表示单选
	        /// </summary>
	        [XmlElement("choice")]
	        public Nullable<long> Choice { get; set; }
	
	        /// <summary>
	        /// 说明文字
	        /// </summary>
	        [XmlElement("content")]
	        public string Content { get; set; }
	
	        /// <summary>
	        /// 是否自动计算时长
	        /// </summary>
	        [XmlElement("duration")]
	        public Nullable<bool> Duration { get; set; }
	
	        /// <summary>
	        /// 时间格式
	        /// </summary>
	        [XmlElement("format")]
	        public string Format { get; set; }
	
	        /// <summary>
	        /// 暂不需要
	        /// </summary>
	        [XmlElement("formula")]
	        public string Formula { get; set; }
	
	        /// <summary>
	        /// 表单id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 表单名称
	        /// </summary>
	        [XmlElement("label")]
	        public string Label { get; set; }
	
	        /// <summary>
	        /// 说明文案的链接地址
	        /// </summary>
	        [XmlElement("link")]
	        public string Link { get; set; }
	
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
	        /// 单选框或者多选框的选项
	        /// </summary>
	        [XmlArray("options")]
	        [XmlArrayItem("string")]
	        public List<string> Options { get; set; }
	
	        /// <summary>
	        /// 占位提示（仅输入类组件）
	        /// </summary>
	        [XmlElement("placeholder")]
	        public string Placeholder { get; set; }
	
	        /// <summary>
	        /// 是否必填
	        /// </summary>
	        [XmlElement("required")]
	        public Nullable<bool> Required { get; set; }
	
	        /// <summary>
	        /// 需要计算总和的明细组件
	        /// </summary>
	        [XmlArray("stat_field")]
	        [XmlArrayItem("form_component_stat_vo")]
	        public List<FormComponentStatVoDomain> StatField { get; set; }
	
	        /// <summary>
	        /// 数字组件/日期区间组件单位属性
	        /// </summary>
	        [XmlElement("unit")]
	        public string Unit { get; set; }
}

	/// <summary>
/// FormComponentVo2Domain Data Structure.
/// </summary>
[Serializable]

public class FormComponentVo2Domain : TopObject
{
	        /// <summary>
	        /// 表单名称
	        /// </summary>
	        [XmlElement("component_name")]
	        public string ComponentName { get; set; }
	
	        /// <summary>
	        /// 子表单属性
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
	        /// 子表单列表
	        /// </summary>
	        [XmlArray("children")]
	        [XmlArrayItem("form_component_vo2")]
	        public List<FormComponentVo2Domain> Children { get; set; }
	
	        /// <summary>
	        /// 表单名称
	        /// </summary>
	        [XmlElement("component_name")]
	        public string ComponentName { get; set; }
	
	        /// <summary>
	        /// 表单属性
	        /// </summary>
	        [XmlElement("props")]
	        public FormComponentPropVoDomain Props { get; set; }
}

	/// <summary>
/// SaveProcessRequestDomain Data Structure.
/// </summary>
[Serializable]

public class SaveProcessRequestDomain : TopObject
{
	        /// <summary>
	        /// 企业应用id
	        /// </summary>
	        [XmlElement("agentid")]
	        public Nullable<long> Agentid { get; set; }
	
	        /// <summary>
	        /// 审批模板描述
	        /// </summary>
	        [XmlElement("description")]
	        public string Description { get; set; }
	
	        /// <summary>
	        /// true
	        /// </summary>
	        [XmlElement("disable_form_edit")]
	        public Nullable<bool> DisableFormEdit { get; set; }
	
	        /// <summary>
	        /// true
	        /// </summary>
	        [XmlElement("disable_stop_process_button")]
	        public Nullable<bool> DisableStopProcessButton { get; set; }
	
	        /// <summary>
	        /// true表示不带流程的模板
	        /// </summary>
	        [XmlElement("fake_mode")]
	        public Nullable<bool> FakeMode { get; set; }
	
	        /// <summary>
	        /// 表单列表
	        /// </summary>
	        [XmlArray("form_component_list")]
	        [XmlArrayItem("form_component_vo")]
	        public List<FormComponentVoDomain> FormComponentList { get; set; }
	
	        /// <summary>
	        /// 设置模板是否隐藏，true表示隐藏
	        /// </summary>
	        [XmlElement("hidden")]
	        public Nullable<bool> Hidden { get; set; }
	
	        /// <summary>
	        /// 审批模板名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 审批模板唯一码
	        /// </summary>
	        [XmlElement("process_code")]
	        public string ProcessCode { get; set; }
	
	        /// <summary>
	        /// 审批模板编辑跳转页。当fake_mode为true时，此参数失效。
	        /// </summary>
	        [XmlElement("template_edit_url")]
	        public string TemplateEditUrl { get; set; }
}

        #endregion
    }
}
