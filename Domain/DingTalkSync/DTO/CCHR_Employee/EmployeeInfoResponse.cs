using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.DTO
{
    public class EmployeeInfoResponse
    {
        public string DingUserID { get; set; }
        public string EmpID { get; set; }
        public string EmpNo { get; set; }

        public string EmpName { get; set; }

        public string DomainAccount { get; set; }

        public string JobLevel { get; set; }
        public string PositionName { get; set; }
        public string PositionID { get; set; }

        public string InCompanyDate { get; set; }

        public string CompanyName { get; set; }

        public string ContractName { get; set; }

        public string DeptID { get; set; }
        public string DeptName { get; set; }

        public string DeptFullName { get; set; }
    }
}
