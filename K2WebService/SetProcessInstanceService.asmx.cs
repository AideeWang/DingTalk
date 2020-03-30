﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using K2Application.Common;

namespace K2WebService
{
    /// <summary>
    /// SetProcessInstanceService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SetProcessInstanceService : System.Web.Services.WebService
    {

        [WebMethod]
        public void SetProcessInstanceVersionRetry(int procInstID)
        {
            K2WorkflowHelper.SetProcessInstanceVersionRetry(procInstID);
        }

           [WebMethod]
        public void SetProcessInstanceVersion()
        {
            K2WorkflowHelper.SetProcessInstanceVersion();
        }
    }
}
