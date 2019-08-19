using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.DingTalkSync.DTO;
using Application.Service;
using Infrastructure;
using Application.Common;

namespace DingTalkApi.Controllers
{
    public class NameValueController : ApiController
    {
        INameValuePairsService nameValuePairsService = ServiceLoader.LoadService<INameValuePairsService>();
        /// <summary>
        /// 获取单个类别的配置键值对
        /// </summary>
        /// <returns></returns>
        public BaseResponse GetNameValue(string Category)
        {
            try
            {
                BaseResponse response = new BaseResponse(nameValuePairsService.GetNameValue(Category));
                return response;
            }
            catch (Exception e)
            {
                throw new CodeException(e.Message);
            }
        }

        /// <summary>
        /// 获取多个类别的配置键值对
        /// </summary>
        /// <returns></returns>
        public BaseResponse GetNameValueList(string Categorys)
        {
            try
            {
                BaseResponse response = new BaseResponse(nameValuePairsService.GetNameValueList(Categorys));
                return response;
            }
            catch (Exception e)
            {
                throw new CodeException(e.Message);
            }
        }
    }
}
