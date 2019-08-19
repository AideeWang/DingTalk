using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.DTO
{
    public class DingUserIdResponse:BaseDingTalkResponse
    {
        /// <summary>
        /// 员工在当前企业内的唯一标识，也称staffId
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 是否是管理员，true：是，false：不是
        /// </summary>
        public int sys_level { get; set; }
        /// <summary>
        /// 级别，1：主管理员，2：子管理员，100：老板，0：其他（如普通员工）
        /// </summary>
        public bool is_sys { get; set; }
        /// <summary>
        /// 用户的设备id
        /// </summary>
        public string deviceId { get; set; }
    }

}
