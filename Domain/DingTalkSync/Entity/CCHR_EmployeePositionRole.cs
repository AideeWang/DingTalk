using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Entity
{
    public class CCHR_EmployeePositionRole
    {
        /// <summary>
        /// RowID
        /// </summary>	
        public string RowID { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>		
        public string EmpID { get; set; }
        /// <summary>
        /// PositionID
        /// </summary>		
        public string PositionID { get; set; }
        /// <summary>
        /// PositionName
        /// </summary>		
        public string PositionName { get; set; }
        /// <summary>
        /// FlagPrimary
        /// </summary>		
        public short FlagPrimary { get; set; }
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
