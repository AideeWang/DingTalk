using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CCHR.Entity;
using Domain.CCHR.Repository;
using Infrastructure;
using Application.Common;
using Domain.CCHR.DTO;

namespace Application.Service
{
    public class EmpContractService:IEmpContractService
    {

        IEmployeeContractApplyRepository EmployeeContractApplyRepository = ServiceLoader.LoadService<IEmployeeContractApplyRepository>();
        /// <summary>
        /// 添加员工合同申请表
        /// </summary>
        /// <param name="employeeContractApply"></param>
        public void AddEmpContractApply(EmployeeContractApply employeeContractApply)
        {
            if (IsEmployeeContractApplyByEmpId(employeeContractApply.EmpID))//判断是否添加过
            {
                employeeContractApply.RowID = Guid.NewGuid().ToString();
                employeeContractApply.FlagDeleted = 0;
                employeeContractApply.FlagAudit = 0;
                employeeContractApply.FlagDone = 0;
                employeeContractApply.FlagStatus = "有效";

                EmployeeContractApplyRepository.Add(employeeContractApply);

                EmployeeContractApplyRepository.UnitOfWork.Commit();
            }
            else
            {
                throw new BusinessException("已经申请过员工合同流程");
            }

        }

        public bool IsEmployeeContractApplyByEmpId(string EmpID)
        {
            return EmployeeContractApplyRepository.GetEmployeeContractApplyByEmpId(EmpID);
        }

        public EmployeeContractApply GetEmpContractApplyByEmpId(string EmpID)
        {
            return EmployeeContractApplyRepository.GetFiltered(a => a.EmpID == EmpID && a.FlagDeleted == 0 && a.FlagDone == 0 && a.FlagStatus == "有效" && a.FlagAudit == 0).First();
        }

        public void SetEmpContractApply(EmployeeContractApply EmployeeContractApply)
        {
            EmployeeContractApplyRepository.SetEmployeeContractApply(EmployeeContractApply);
        }


        public EmpContractApplyResponse GetEmployeeContractApplyByRowID(string RowID)
        {
            EmpContractApplyResponse response = new EmpContractApplyResponse();
            var employeeContractApply = EmployeeContractApplyRepository.Get(RowID);
            if (employeeContractApply != null)
            {
                response.RowID = employeeContractApply.RowID;
                response.EmpID = employeeContractApply.EmpID;
                response.CompanyName = employeeContractApply.CompanyName;
                response.ContractName = employeeContractApply.CompanyName;
                response.ContractType = employeeContractApply.ContractType;
                response.StartDate = employeeContractApply.StartDate.ToDate();
                response.EndDate = employeeContractApply.EndDate.ToDate();
            }
            return response;
        }

        public IEnumerable<EmployeeContractApply> GetEmployeeContractApplyList(string EmpID)
        {
            return EmployeeContractApplyRepository.GetEmployeeContractApplyList(EmpID);
        }

    }
}
