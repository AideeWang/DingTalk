using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2Application.Common
{
    public class ApprovalUserInfo
    {
        public string ApprovalUserId { get; set; }

        public string ApprovalUserName { get; set; }

        public string ComAuditResult { get; set; }

        public string ComAuditText { get; set; }

        public string ComAuditComment { get; set; }

        public string ActionName { get; set; }

        public string ManagedUser{ get; set; }
        public string SharedUser { get; set; }
    }
}
