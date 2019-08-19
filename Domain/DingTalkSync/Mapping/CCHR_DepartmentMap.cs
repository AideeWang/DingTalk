using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class CCHR_DepartmentMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CCHR_Department>
    {
        public CCHR_DepartmentMap()
        {
            // table
            ToTable("CCHR_Department", "dbo");
            // keys
            HasKey(t => t.DeptID);
        }
    }
}
