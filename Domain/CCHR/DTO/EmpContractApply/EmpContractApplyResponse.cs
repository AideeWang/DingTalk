using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CCHR.DTO
{
    public class EmpContractApplyResponse
    {
        /// <summary>
        /// 员工合同表主键
        /// </summary>		
        public string RowID { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 所属公司名称
        /// </summary>		
        public string CompanyName { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>		
        public string ContractName { get; set; }
        /// <summary>
        /// 合同类型
        /// </summary>		
        public string ContractType { get; set; }
        /// <summary>
        /// 合同开始时间
        /// </summary>		
        public string StartDate { get; set; }
        /// <summary>
        /// 合同结束时间
        /// </summary>		
        public string EndDate { get; set; }      
		   
    }
}
