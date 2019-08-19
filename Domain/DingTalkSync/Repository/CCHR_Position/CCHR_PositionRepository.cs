using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.Entity;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
    public class CCHR_PositionRepository : Repository<CCHR_Position>, ICCHR_PositionRepository

    {
        public CCHR_PositionRepository():base(DingTalkSyncDBContext.GetInstance()){}
    }
}
