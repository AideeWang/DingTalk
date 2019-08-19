using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace K2Application.Common
{
     [DataContract]
    public class ApprovalCompletedWorkListItem
    {
        [DataMember]
        public string SN { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string BizEmpName { get; set; }
        [DataMember]
        public string RowID { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime FinishDate { get; set; }
        [DataMember]
        public string Folio { get; set; }     
    }
}
