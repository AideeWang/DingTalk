using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class CCHR_PositionMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CCHR_Position>
    {
        public CCHR_PositionMap()
        {
            // table
            ToTable("CCHR_Position", "dbo");

            // keys
            HasKey(t => t.PositionID);
        }
    }
}
