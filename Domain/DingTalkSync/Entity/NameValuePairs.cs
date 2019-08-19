using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Domain.DingTalkSync.Entity
{
    //NameValuePairs
    public class NameValuePairs
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Category
        /// </summary>		
        public string Category { get; set; }
        /// <summary>
        /// Name
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>		
        public string Value { get; set; }
        /// <summary>
        /// ParentID
        /// </summary>		
        public int ParentID { get; set; }
        /// <summary>
        /// SortOrder
        /// </summary>		
        public int SortOrder { get; set; }
        /// <summary>
        /// FlagDeleted
        /// </summary>		
        public int FlagDeleted { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }
}