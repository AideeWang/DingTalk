using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.Entity;
using Domain.UnitOfWork;
using Domain.DingTalkSync;

namespace Domain.DingTalkSync.Repository
{
    public class CCHR_DepartmentRepository:Repository<CCHR_Department>,ICCHR_DepartmentRepository
    {
        public CCHR_DepartmentRepository() : base(DingTalkSyncDBContext.GetInstance()) { }

        public CCHR_Department GetCCHR_Department(string DeptId)
        {
            return this.GetFiltered(a => a.DeptID == DeptId && a.FlagDeleted == 0).First();
        }
    }
}
