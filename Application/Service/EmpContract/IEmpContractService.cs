using Domain.CCHR.DTO;
using Domain.CCHR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IEmpContractService
    {
        void AddEmpContractApply(EmployeeContractApply employeeContractApply);
        bool IsEmployeeContractApplyByEmpId(string EmpID);
        EmployeeContractApply GetEmpContractApplyByEmpId(string EmpID);

        void SetEmpContractApply(EmployeeContractApply EmployeeContractApply);

        EmpContractApplyResponse GetEmployeeContractApplyByRowID(string RowID);

        IEnumerable<EmployeeContractApply> GetEmployeeContractApplyList(string EmpID);
    }
}
