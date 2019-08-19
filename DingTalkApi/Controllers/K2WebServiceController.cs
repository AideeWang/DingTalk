using Domain.K2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infrastructure;
using Application.Service;
using Domain.CCHR.Entity;
using Application.Common;
using Domain.K2;

namespace DingTalkApi.Controllers
{
    public class K2WebServiceController : ApiController
    {
        K2WorkflowService.K2WorkflowServiceClient K2Client = new K2WorkflowService.K2WorkflowServiceClient();

        [HttpPost]
        public void StartProcessInstance(string WorkflowTypeName, Dictionary<string, object> dicDataFields, ApplyUserInfo ApplyUserInfo)
        {
            try
            {
                K2Client.StartProcessInstance(WorkflowTypeName, dicDataFields, ApplyUserInfo.ToJson());
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }

        }

        public string GetCurrentUserWorkListItem(string ApprovalUser)
        {
            try
            {
                var ApprovalInfoList = K2Client.GetCurrentUserWorkListItem(ApprovalUser);
                if (ApprovalInfoList != null)
                {
                    return ApprovalInfoList.ToJson();
                }
                return "";
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        }

        public void ApprovalProcessInstance(ApprovalRequest approvalRequest)
        {
            try
            {
                K2Client.ApprovalProcessInstance(approvalRequest.SN,approvalRequest.dicDataFields,approvalRequest.ApprovalUserInfo.ToJson());
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        }

        public string GetProcessInstanceApprovalHistory(string SN,string ApprovalUserId)
        {
            try
            {
                return K2Client.GetProcessInstanceApprovalHistory(SN, ApprovalUserId);
            }
            catch (Exception e)
            {
                
                throw new CodeException(e.ToString());
            }
        }

        public string GetCurrentUserCompletedWorkListItem(string ApprovalUser)
        {
            try
            {
                return K2Client.GetCurrentUserCompletedWorkListItem(ApprovalUser);
            }
            catch (Exception e)
            {
                throw new CodeException(e.ToString());
            }
        } 

    }
}
