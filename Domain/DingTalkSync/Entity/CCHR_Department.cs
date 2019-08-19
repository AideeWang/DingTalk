using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Entity
{
    public class CCHR_Department
    {

        /// <summary>
        /// DeptID
        /// </summary>	
        public string DeptID { get; set; }
        /// <summary>
        /// DeptName
        /// </summary>		
        public string DeptName { get; set; }
        /// <summary>
        /// Path
        /// </summary>		
        public string Path { get; set; }
        /// <summary>
        /// FullName
        /// </summary>		
        public string FullName { get; set; }
        /// <summary>
        /// ParentID
        /// </summary>		
        public string ParentID { get; set; }
        /// <summary>
        /// DateOpen
        /// </summary>		
        public DateTime DateOpen { get; set; }
        /// <summary>
        /// DateClosed
        /// </summary>		
        public DateTime? DateClosed { get; set; }
        /// <summary>
        /// DeptNo
        /// </summary>		
        public string DeptNo { get; set; }
        /// <summary>
        /// Status
        /// </summary>		
        public string Status { get; set; }
        /// <summary>
        /// FlagDeleted
        /// </summary>		
        public short FlagDeleted { get; set; }
        /// <summary>
        /// ModDate
        /// </summary>		
        public DateTime ModDate { get; set; }
        /// <summary>
        /// Tel
        /// </summary>		
        public string Tel { get; set; }
        /// <summary>
        /// Fax
        /// </summary>		
        public string Fax { get; set; }
        /// <summary>
        /// DeptAddress
        /// </summary>		
        public string DeptAddress { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>		
        public string ZipCode { get; set; }

    }
}
