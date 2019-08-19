using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.Entity;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public interface ICCHR_DepartmentRepository:IRepository<CCHR_Department>
    {
        CCHR_Department GetCCHR_Department(string DeptId);
    }
}
