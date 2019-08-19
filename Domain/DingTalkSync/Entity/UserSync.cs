using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Entity
{
    public class UserSync 
    {
        /// <summary>
        /// UserID
        /// </summary>		
        public string UserID { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>		
        public string EmpID { get; set; }
        /// <summary>
        /// EmpNo
        /// </summary>		
        public string EmpNo { get; set; }
        /// <summary>
        /// EmpName
        /// </summary>		
        public string EmpName { get; set; }
        /// <summary>
        /// DomailAccount
        /// </summary>		
        public string DomailAccount { get; set; }
        /// <summary>
        /// Department
        /// </summary>		
        public string Department { get; set; }
        /// <summary>
        /// Mobile
        /// </summary>		
        public string Mobile { get; set; }
        /// <summary>
        /// Position
        /// </summary>		
        public string Position { get; set; }
        /// <summary>
        /// JobLevel
        /// </summary>		
        public int JobLevel { get; set; }
        /// <summary>
        /// Email
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// IsHide
        /// </summary>		
        public int IsHide { get; set; }
        /// <summary>
        /// IsSenior
        /// </summary>		
        public int IsSenior { get; set; }
        /// <summary>
        /// Extattr
        /// </summary>		
        public string Extattr { get; set; }
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
