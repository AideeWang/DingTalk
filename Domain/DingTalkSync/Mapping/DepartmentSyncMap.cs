using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class DepartmentSyncMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DepartmentSync>
    {
        public DepartmentSyncMap()
        {
            // table
            ToTable("DepartmentSync", "dbo");

            // keys
            HasKey(t => t.DingDeptID);
        }
    }
}
