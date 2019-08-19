using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public class UserSyncRepository : Repository<UserSync>, IUserSyncRepository
    {
        public UserSyncRepository() : base(DingTalkSyncDBContext.GetInstance()) { }

        public UserSync GetUserSyncByEmpID(string EmpID)
        {
            return this.GetFiltered(a => a.EmpID == EmpID).First();
        }
    }
}
