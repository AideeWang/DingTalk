using DingTalk.Api.Response;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api.Util;
using Application.Common;
using System.Security.Cryptography;
using Domain.DingTalkSync.DTO;

namespace Application.Service
{
    public class BaseDingTalkService
    {
        private HttpHelper _httpHelper = new HttpHelper(AppSettings.Get("dingtalk"));
        public CacheHelper _cacheHelper = new CacheHelper();
        public BaseDingTalkService()
        {
            corpid = AppSettings.Get("corpid");
            corpsecret = AppSettings.Get("corpsecret");
            agentid = AppSettings.Get("agentid");
            appkey = AppSettings.Get("appkey");
            appsecret = AppSettings.Get("appsecret");
            url = AppSettings.Get("url");
            registerurl = AppSettings.Get("registerurl");
            timestamp = TopUtils.GetCurrentTimeMillis().ToString();
            noncestr = DingTalkSignatureUtil.GetRandomStr(10);
        }
        #region 钉钉参数
        /// <summary>
        /// 钉钉企业Id
        /// </summary>
        public string corpid { get; set; }
        /// <summary>
        /// 钉钉企业密钥
        /// </summary>
        public string corpsecret { get; set; }
        /// <summary>
        /// 钉钉微应用Id
        /// </summary>
        public string agentid { get; set; }
        /// <summary>
        /// 钉钉微应用键
        /// </summary>
        public string appkey { get; set; }
        /// <summary>
        /// 钉钉微应用密钥
        /// </summary>
        public string appsecret { get; set; }
        /// <summary>
        /// 钉钉微应用 access_token （access_token有效期为2小时,实际缓存设置120分钟）
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 钉钉微应用访问地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 钉钉回调地址
        /// </summary>
        public string registerurl { get; set; }
        /// <summary>
        /// 生成签名的当前时间（ 获取从1970年1月1日到现在的毫秒总数。）
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        public string noncestr { get; set; }
        /// <summary>
        /// 钉钉免登的临时票据（有效期2小时，实际缓存设置120分钟）
        /// </summary>
        public string jsapi_ticket { get; set; }
        #endregion

        #region 调用接口
        /// <summary>
        /// 调用 Get接口
        /// </summary>
        /// <param name="ApiName">接口名称</param>
        /// <param name="token">token</param>
        /// <param name="RequestDic">请求参数</param>
        /// <param name="RequestType">请求类型</param>
        /// <returns>响应数据</returns>
        public string BaseGetApi(string ApiName, string token, Dictionary<string, string> RequestDic)
        {
            ApiName = string.IsNullOrEmpty(token) ? ApiName : ApiName + ("?" + token);
            return _httpHelper.Get(RequestDic, ApiName);
        }

        /// <summary>
        /// 调用 Get接口
        /// </summary>
        /// <param name="ApiName">接口名称</param>
        /// <param name="RequestDic">请求参数</param>
        /// <param name="RequestType">请求类型</param>
        /// <returns>响应数据</returns>
        public string BaseGetApi(string ApiName, Dictionary<string, string> RequestDic)
        {
            return BaseGetApi(ApiName, string.Empty, RequestDic);
        }

        /// <summary>
        /// 调用 POST接口
        /// </summary>
        /// <param name="ApiName">接口名称</param>
        /// <param name="token">token</param>
        /// <param name="RequestDic">请求参数</param>
        /// <param name="RequestType">请求类型</param>
        /// <returns>响应数据</returns>
        public string BasePostApi(string ApiName,string token,Dictionary<string,object> RequestDic)
        {
            ApiName = string.IsNullOrEmpty(token) ? ApiName : ApiName+("?" + token);
            return _httpHelper.Post(RequestDic, ApiName);
        }

        #endregion

        #region access_token jsapiticket
        /// <summary>
        /// 获取AccessToken
        /// 请求方式：GET（HTTPS）
        /// 请求地址：https://oapi.dingtalk.com/gettoken?appkey=key&appsecret=secret
        /// </summary>
        /// <returns></returns>
        public string GetAccess_token()
        {
            var token = _cacheHelper.Get("access_token");
            if (_cacheHelper.Get("access_token") == null)
            {
                Dictionary<string, string> RequestDic = new Dictionary<string, string>();
                RequestDic.Add("appkey", appkey);
                RequestDic.Add("appsecret", appsecret);
                AccessTokenResponse Response = BaseGetApi("gettoken", null, RequestDic).ToObject<AccessTokenResponse>();
                if (Response.errcode == 0)
                {
                    access_token =Response.access_token;
                    _cacheHelper.Add("access_token", access_token);//保存 access_token
                    return access_token;
                }
                throw new BusinessException(Response.errmsg);
            }
            return token.ToString();
        }

        /// <summary>
        /// 获取 jsapi_ticket
        /// 请求方式：GET（HTTPS）
        /// 请求地址：https://oapi.dingtalk.com/get_jsapi_ticket?access_token=ACCESS_TOKEN
        /// </summary>
        public string GetJsapi_ticket()
        {
            var ticket = _cacheHelper.Get("jsapi_ticket");
            if (ticket == null)
            {
                string Result = BaseGetApi("get_jsapi_ticket", GetAccessTokenToDic());
                JsapiTicketResponse Response = Result.ToObject<JsapiTicketResponse>();
                if (Response.errcode == 0)
                {
                    jsapi_ticket = Response.ticket;
                    _cacheHelper.Add("jsapi_ticket", jsapi_ticket);//保存 access_token
                    return jsapi_ticket;
                }
                throw new BusinessException(Response.errmsg);
            }
            return ticket.ToString();
        }

        #endregion

        public string GetConfig()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("agentId", agentid);
            dic.Add("corpId", corpid);
            dic.Add("timeStamp", timestamp);
            dic.Add("nonceStr", noncestr);
            dic.Add("signature", GetSignature());
            dic.Add("jsapi_ticket", GetJsapi_ticket());
            dic.Add("url", url);
            return dic.ToJson();
        }

        public string GetSignature()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("jsapi_ticket", GetJsapi_ticket());
            dic.Add("noncestr", noncestr);
            dic.Add("timestamp", timestamp);
            dic.Add("url", url);

            byte[] bytes = Encoding.UTF8.GetBytes(ConvertDictionaryToString(dic));
            byte[] digest = SHA1.Create().ComputeHash(bytes);
            string digestBytesString = BitConverter.ToString(digest).Replace("-", "");
            _cacheHelper.Add("signature", digestBytesString.ToLower());
            return digestBytesString.ToLower();   
        }

        public string ConvertDictionaryToString(Dictionary<string, object> dic)
        {
            return string.Join("&", dic.Select(o => o.Key + "=" + o.Value));
        }

        public string ConvertDictionaryToString(Dictionary<string, string> dic)
        {
            return string.Join("&", dic.Select(o => o.Key + "=" + o.Value));
        }

        /// <summary>
        /// 获取含有access_token 的键值对
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAccessTokenToDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("access_token", GetAccess_token());
            return dic;
        }
    }
}
