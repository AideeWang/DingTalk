using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2Application.Common
{
    public class K2Exception : Exception
    {
        public K2Exception(string message)
            : base(message) 
        {
            LogHelper.Debug(message);
        }
    }
}
