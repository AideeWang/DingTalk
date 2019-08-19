using Domain.K2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.K2
{
    public class ApprovalRequest
    {
        public string SN { get; set; }

        public Dictionary<string, object> dicDataFields { get; set; }

        public ApprovalUserInfo ApprovalUserInfo { get; set; }
    }
}
