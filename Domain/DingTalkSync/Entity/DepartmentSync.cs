using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Entity
{
    public class DepartmentSync
    {
        /// <summary>
        /// DingDeptID
        /// </summary>	
        public long DingDeptID { get; set; }
        /// <summary>
        /// DingParentID
        /// </summary>		
        public long DingParentID { get; set; }
        /// <summary>
        /// DeptID
        /// </summary>		
        public string DeptID { get; set; }
        /// <summary>
        /// DeptName
        /// </summary>		
        public string DeptName { get; set; }
        /// <summary>
        /// ModDate
        /// </summary>		
        public DateTime ModDate { get; set; }
        /// <summary>
        /// SyncTime
        /// </summary>		
        public DateTime SyncTime { get; set; }       
    }
}
