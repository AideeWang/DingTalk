
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CCHR.Entity;
using Domain.UnitOfWork;
namespace Domain.CCHR.Repository
{
	/// <summary>
	/// EmployeeContractApply
	/// </summary>
	public interface IEmployeeContractApplyRepository:IRepository<EmployeeContractApply>
	{
        bool GetEmployeeContractApplyByEmpId(string EmpId);

        void SetEmployeeContractApply(EmployeeContractApply employeeContractApply);

        IEnumerable<EmployeeContractApply> GetEmployeeContractApplyList(string EmpID);
	} 
}