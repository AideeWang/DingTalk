using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.Entity;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public class CCHR_EmployeePositionRoleRepository:Repository<CCHR_EmployeePositionRole>,ICCHR_EmployeePositionRoleRepository
    {
        public CCHR_EmployeePositionRoleRepository():base(DingTalkSyncDBContext.GetInstance()){}

        public CCHR_EmployeePositionRole GetCCHR_EmployeePositionRole(string EmpID)
        {
            return this.GetFiltered(a => a.FlagPrimary == 1 && a.EmpID == EmpID).First();
        }
    }
}
