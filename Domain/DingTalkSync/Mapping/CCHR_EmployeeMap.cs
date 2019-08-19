using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class CCHR_EmployeeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CCHR_Employee>
    {
        public CCHR_EmployeeMap()
        {
            // table
            ToTable("CCHR_Employee", "dbo");
            // keys
            HasKey(t => t.EmpID);
        }
    }
}
