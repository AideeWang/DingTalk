using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.K2
{
    public enum ComAuditResult
    {
        [Description("同意")]
        Agree=1,
        [Description("拒绝")]
        Refuse=0,
        [Description("驳回")]
        Reject =2,
    }
}
