using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class CCHR_EmployeePositionRoleMap: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CCHR_EmployeePositionRole>
    {
        public CCHR_EmployeePositionRoleMap()
        {
            // table
            ToTable("CCHR_EmployeePositionRole", "dbo");

            // keys
            HasKey(t => t.RowID);
        }
    }
}
