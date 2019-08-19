using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.DingTalkSync.DTO
{
    public class BaseDingTalkResponse
    {        
        /// <summary>
        /// 返回错误代码 0 成功，其他值 失败
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}