using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.K2;
using Domain.CCHR.Entity;

namespace Domain.CCHR.DTO
{
    public class EmpContractApplyRequest
    {
        public string WorkflowTypeName { get; set; }

        public Dictionary<string,object> dicDataFields { get; set; }

        public ApplyUserInfo ApplyUserInfo { get; set; }

        public EmployeeContractApply employeeContractApply { get; set; }
    }
}
