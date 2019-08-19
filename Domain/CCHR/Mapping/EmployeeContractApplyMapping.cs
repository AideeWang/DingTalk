
using Domain.CCHR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.CCHR.Mapping
{
	/// <summary>
	/// EmployeeContractApply
	/// </summary>
	public class EmployeeContractApplyMap:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmployeeContractApply>
	{
		public EmployeeContractApplyMap()
		{
			// table
            ToTable("EmployeeContractApply", "dbo");
            // keys
           HasKey(t => t.RowID);
		}
	} 
}