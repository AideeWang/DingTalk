using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Entity
{
    public class CCHR_Position
    {

        /// <summary>
        /// PositionID
        /// </summary>	
        public string PositionID { get; set; }
        /// <summary>
        /// PositionName
        /// </summary>		
        public string PositionName { get; set; }
        /// <summary>
        /// DeptID
        /// </summary>		
        public string DeptID { get; set; }
        /// <summary>
        /// ParentID
        /// </summary>		
        public string ParentID { get; set; }
        /// <summary>
        /// FlagDeleted
        /// </summary>		
        public short FlagDeleted { get; set; }
        /// <summary>
        /// JobLevel
        /// </summary>		
        public string JobLevel { get; set; }        
    }
}
