
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
	public class EmployeeContractApplyRepository:Repository<EmployeeContractApply>,IEmployeeContractApplyRepository
	{
		public EmployeeContractApplyRepository() : base(CCHRDBContextDBContext.GetInstance()) { }

        public bool GetEmployeeContractApplyByEmpId(string EmpId)
        {
            return this.GetFiltered(a => a.EmpID == EmpId && a.FlagDeleted == 0 && a.FlagDone == 0 && a.FlagStatus == "有效" && a.FlagAudit == 0).Count()<=0;
        }

        /// <summary>
        /// 修改劳动合同
        /// </summary>
        /// <param name="employeeContractApply"></param>
        public void SetEmployeeContractApply(EmployeeContractApply employeeContractApply)
        {
            var EmployeeContractApply = this.GetFiltered(a => a.EmpID == employeeContractApply.EmpID && a.FlagDeleted == 0 && a.FlagDone == 0 && a.FlagStatus == "有效" && a.FlagAudit == 0).First();
            if (EmployeeContractApply != null)
            {
                EmployeeContractApply.CompanyName = employeeContractApply.CompanyName;
                EmployeeContractApply.ContractName = employeeContractApply.ContractName;
                EmployeeContractApply.ContractType = employeeContractApply.ContractType;
                EmployeeContractApply.StartDate = employeeContractApply.StartDate;
                EmployeeContractApply.EndDate = employeeContractApply.EndDate;
                this.Modify(EmployeeContractApply);
                this.UnitOfWork.Commit();
            }
        }

        /// <summary>
        /// 已保存未提交
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeContractApply> GetEmployeeContractApplyList(string EmpID)
        {
            return this.GetFiltered(a => a.FlagAudit == 0 && a.EmpID == EmpID);
        }
	} 
}