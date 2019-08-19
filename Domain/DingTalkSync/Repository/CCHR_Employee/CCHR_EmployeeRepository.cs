using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Domain.DingTalkSync.Entity;
using System.Collections;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public class CCHR_EmployeeRepository : Repository<CCHR_Employee>, ICCHR_EmployeeRepository
    {
        public CCHR_EmployeeRepository(): base(DingTalkSyncDBContext.GetInstance()){}

        public CCHR_Employee GetCCHR_Employee(string EmpId)
        {
           return this.GetFiltered(a => a.EmpID == EmpId && a.FlagDeleted == 0).First();
        }

        public CCHR_Employee GetCCHR_EmployeeByDomainAccount(string DomainAccount)
        {
            return this.GetFiltered(a => a.DomainAccount == DomainAccount && a.FlagDeleted == 0).First();
        }
    }
}
