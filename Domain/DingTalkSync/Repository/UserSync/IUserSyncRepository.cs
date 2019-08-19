using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public interface IUserSyncRepository:IRepository<UserSync>
    {
        UserSync GetUserSyncByEmpID(string EmpID);
    }
}
