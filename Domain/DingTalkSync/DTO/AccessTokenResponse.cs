using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.DingTalkSync.DTO
{
    public class AccessTokenResponse:BaseDingTalkResponse
    {

        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }
    }
}