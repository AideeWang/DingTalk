using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public interface ICCHR_EmployeeRepository : IRepository<CCHR_Employee>
    {
        CCHR_Employee GetCCHR_Employee(string EmpId);
        CCHR_Employee GetCCHR_EmployeeByDomainAccount(string DomainAccount);
    }
}
