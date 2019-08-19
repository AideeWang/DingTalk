using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.DTO;
using Domain.DingTalkSync.Entity;
using Infrastructure;

namespace Application.ToDTO
{
    public static class CCHR_EmployeeToDTO
    {
        public static EmployeeInfoResponse ToDTO(this CCHR_Employee entity)
        {

            EmployeeInfoResponse response = new EmployeeInfoResponse();
            response.EmpID = entity.EmpID;
            response.EmpNo = entity.EmpNo;
            response.EmpName = entity.EmpName;
            response.DomainAccount = entity.DomainAccount;
            response.JobLevel = entity.JobLevel;
            response.InCompanyDate =entity.InCompanyDate.ToDate();
            response.ContractName = entity.ContractName;
            response.CompanyName = entity.ContractType;
            return response;
        }
    }
}
