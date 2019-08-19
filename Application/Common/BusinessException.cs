using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Application.Common
{
    public class BusinessException : Exception
    {
        public BusinessException(string message):base(message) 
        {
            LogHelper.BusinessDebug(message);
        }
    }

    public class CodeException : Exception
    {
        public CodeException(string message)
            : base(message)
        {
            LogHelper.Debug(message);
        }
    }
}
