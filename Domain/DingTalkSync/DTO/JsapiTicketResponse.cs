using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.DTO
{
    public class JsapiTicketResponse :BaseDingTalkResponse
    {
        /// <summary>
        /// 用于JSAPI的临时票据
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 票据过期时间
        /// </summary>
        public int expires_in { get; set; }
    }
}
