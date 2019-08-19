using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Service;
using Application.Common;
using Infrastructure;
using Domain.DingTalkSync.DTO;


namespace DingTalkApi.Controllers
{
    public class LoginController : ApiController
    {
        BaseDingTalkService dingtalkService = new BaseDingTalkService();

       // ILoginService loginService = ServiceLoader.LoadService<ILoginService>();

        private ILoginService _ILoginService;
        private ILoginService LoginService
        {
            get
            {
                return _ILoginService ?? (_ILoginService = ServiceLoader.LoadService<ILoginService>());
            }
        }
        public string GetConfig()
        {
            try
            {
                return dingtalkService.GetConfig();
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        }

        public string GetAccess_token()
        {
            try
            {
                string access_token =dingtalkService.GetAccess_token();
                LogHelper.Log("access_token 值：" + access_token);
                return dingtalkService.GetAccess_token();
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        }

        public DingUserIdResponse GetDingDingUserId(string Code)
        {
            try
            {
                return LoginService.GetUserId(Code);
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        }

        public BaseResponse GetEmployeeInfo(string DingUserId)
        {
            try
            {
                BaseResponse response = new BaseResponse(LoginService.GetEmployeeInfo(DingUserId));
                return response;
            }
            catch (Exception e)
            {
                
                throw new CodeException(e.ToString());
            }
        }

        public BaseResponse GetEmployeeInfoByEmpID(string EmpID)
        {
            try
            {
                BaseResponse response = new BaseResponse(LoginService.GetEmployeeInfoByEmpID(EmpID));
                return response;
            }
            catch (Exception e)
            {

                throw new CodeException(e.ToString());
            }
        }

        public BaseResponse GetEmployeeInfoByDomainAccount(string DomainAccount)
        {
            try
            {
                BaseResponse response = new BaseResponse(LoginService.GetCCHR_EmployeeByDomainAccount(DomainAccount));
                return response;
            }
            catch (Exception e)
            {

                throw new CodeException(e.ToString());
            }
        }
         
    }
}
