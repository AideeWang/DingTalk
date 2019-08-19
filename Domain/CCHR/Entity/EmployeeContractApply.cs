using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Domain.CCHR.Entity
{
	//EmployeeContractApply
	public class EmployeeContractApply
	{
   		     
      	/// <summary>
		/// 员工合同表主键
        /// </summary>		
        public string RowID{ get; set;}        
		/// <summary>
		/// 员工ID
        /// </summary>		
        public string EmpID{ get; set;}        
		/// <summary>
		/// 员工姓名
        /// </summary>		
        public string EmpName{ get; set;}        
		/// <summary>
		/// 员工编号
        /// </summary>		
        public string EmpCode{ get; set;}        
		/// <summary>
		/// 员工职级
        /// </summary>		
        public int JobLevel{ get; set;}        
		/// <summary>
		/// 所属公司名称
        /// </summary>		
        public string CompanyName{ get; set;}        
		/// <summary>
		/// 合同名称
        /// </summary>		
        public string ContractName{ get; set;}        
		/// <summary>
		/// 合同类型
        /// </summary>		
        public string ContractType{ get; set;}        
		/// <summary>
		/// 合同开始时间
        /// </summary>		
        public DateTime StartDate{ get; set;}        
		/// <summary>
		/// 合同结束时间
        /// </summary>		
        public DateTime? EndDate{ get; set;}        
		/// <summary>
		/// 生效时间
        /// </summary>		
        public DateTime ValidedDate{ get; set;}        
		/// <summary>
		/// 审核标记(1已审核0未审核-1拒绝)
        /// </summary>		
        public short FlagAudit{ get; set;}        
		/// <summary>
		/// 删除标记(1删除)
        /// </summary>		
        public short FlagDeleted{ get; set;}        
		/// <summary>
		/// 已处理标记(0 未处理 1已处理)
        /// </summary>		
        public short FlagDone{ get; set;}   
		/// <summary>
		/// 后台任务执行时间
        /// </summary>		
        public DateTime? OperateTime{ get; set;}        
		/// <summary>
		/// 状态(有效/无效)
        /// </summary>		
        public string FlagStatus{ get; set;}   
     

		   
	}
}