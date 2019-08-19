using Domain.CCHR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Service;
using Infrastructure;
using Domain.K2;
using Application.Common;
using Domain.CCHR.DTO;

namespace DingTalkApi.Controllers
{
    public class EmpContractController : ApiController
    {
        IEmpContractService EmpContractService = ServiceLoader.LoadService<IEmpContractService>();
        K2WorkflowService.K2WorkflowServiceClient K2Client = new K2WorkflowService.K2WorkflowServiceClient();
        /// <summary>
        /// 添加员工合同信息
        /// </summary>
        /// <param name="employeeContractApply"></param>
        [HttpPost]
        
        public void AddEmpContractApply(EmployeeContractApply employeeContractApply)
        {
            EmpContractService.AddEmpContractApply(employeeContractApply);
        }

        /// <summary>
        /// 发起员工合同流程（以及保存员工合同信息）
        /// </summary>
        /// <param name="WorkflowTypeName"></param>
        /// <param name="dicDataFields"></param>
        /// <param name="ApplyUserInfo"></param>
        /// <param name="employeeContractApply"></param>
        [HttpPost]
        public void StartEmpContractApply(EmpContractApplyRequest EmpContractApplyRequest)
        {
            try
            {
                if (EmpContractService.IsEmployeeContractApplyByEmpId(EmpContractApplyRequest.employeeContractApply.EmpID))
                {
                    EmpContractService.AddEmpContractApply(EmpContractApplyRequest.employeeContractApply);
                }else{
                    EmpContractService.SetEmpContractApply(EmpContractApplyRequest.employeeContractApply);
                }

                var EmpContractApply =  EmpContractService.GetEmpContractApplyByEmpId(EmpContractApplyRequest.employeeContractApply.EmpID);
                if (EmpContractApply != null)
                {
                    EmpContractApplyRequest.dicDataFields["BizDataID"] = EmpContractApply.RowID;
                }
                K2Client.StartProcessInstance(EmpContractApplyRequest.WorkflowTypeName, EmpContractApplyRequest.dicDataFields, EmpContractApplyRequest.ApplyUserInfo.ToJson());
                
            }
            catch (Exception e)
            {
                
                throw new CodeException(e.ToString());
            }

        }

        [HttpGet]

        public BaseResponse GetEmployeeContractApplyByRowID(string RowID)
        {
            try
            {
                return  new BaseResponse(EmpContractService.GetEmployeeContractApplyByRowID(RowID));
            }
            catch (Exception e) 
            {
                
                throw new CodeException(e.ToString());
            }
        }

        [HttpGet]
        public BaseResponse GetEmployeeContractApplyList(string EmpID)
        {
            try
            {
                return new BaseResponse(EmpContractService.GetEmployeeContractApplyList(EmpID));
            }
            catch (Exception e)
            {
                
                throw new CodeException(e.ToString());
            }
        }

    }
}
