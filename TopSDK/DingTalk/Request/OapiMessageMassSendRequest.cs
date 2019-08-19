using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.message.mass.send
    /// </summary>
    public class OapiMessageMassSendRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiMessageMassSendResponse>
    {
        /// <summary>
        /// 接收者的部门id列表，接收者是部门id下(包括子部门下)的所有用户
        /// </summary>
        public string DepIdList { get; set; }

        /// <summary>
        /// 是否预览推送
        /// </summary>
        public Nullable<bool> IsPreview { get; set; }

        /// <summary>
        /// 是否群发给所有订阅者，true-是，false-否
        /// </summary>
        public Nullable<bool> IsToAll { get; set; }

        /// <summary>
        /// 消息卡片素材id
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// msg_type, 消息类型：text，文本类型，此时文本内容填在text_content字段中；news_card，消息卡片，此时的media_id通过消息卡片上传接口得到； image，图片，此时的media_id通过图片上传接口得到
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 文本内容，当msg_type为text时有效
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// 服务号的unionid
        /// </summary>
        public string Unionid { get; set; }

        /// <summary>
        /// 接收者的用户userid列表
        /// </summary>
        public string UseridList { get; set; }

        /// <summary>
        /// 调用时填写随机生成的UUID, 防止消息重复发送
        /// </summary>
        public string Uuid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.message.mass.send";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dep_id_list", this.DepIdList);
            parameters.Add("is_preview", this.IsPreview);
            parameters.Add("is_to_all", this.IsToAll);
            parameters.Add("media_id", this.MediaId);
            parameters.Add("msg_type", this.MsgType);
            parameters.Add("text_content", this.TextContent);
            parameters.Add("unionid", this.Unionid);
            parameters.Add("userid_list", this.UseridList);
            parameters.Add("uuid", this.Uuid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("dep_id_list", this.DepIdList, 20);
            RequestValidator.ValidateRequired("is_to_all", this.IsToAll);
            RequestValidator.ValidateMaxLength("media_id", this.MediaId, 256);
            RequestValidator.ValidateRequired("msg_type", this.MsgType);
            RequestValidator.ValidateMaxLength("msg_type", this.MsgType, 32);
            RequestValidator.ValidateMaxLength("text_content", this.TextContent, 65535);
            RequestValidator.ValidateRequired("unionid", this.Unionid);
            RequestValidator.ValidateMaxLength("unionid", this.Unionid, 128);
            RequestValidator.ValidateMaxListSize("userid_list", this.UseridList, 10000);
            RequestValidator.ValidateRequired("uuid", this.Uuid);
            RequestValidator.ValidateMaxLength("uuid", this.Uuid, 128);
        }

        #endregion
    }
}
