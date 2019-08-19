using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.attendance.vacation.type.update
    /// </summary>
    public class OapiAttendanceVacationTypeUpdateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiAttendanceVacationTypeUpdateResponse>
    {
        /// <summary>
        /// 假期类型，普通假期或者加班转调休假期。(general_leave、lieu_leave其中一种)
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 调休假有效期规则(validity_type:有效类型 absolute_time(绝对时间)、relative_time(相对时间)其中一种 validity_value:延长日期(当validity_type为absolute_time该值该值不为空且满足yy-mm格式 validity_type为relative_time该值为大于1的整数))
        /// </summary>
        public string Extras { get; set; }

        /// <summary>
        /// 每天折算的工作时长(百分之一 例如1天=10小时=1000)
        /// </summary>
        public Nullable<long> HoursInPerDay { get; set; }

        /// <summary>
        /// 假期类型唯一标识
        /// </summary>
        public string LeaveCode { get; set; }

        /// <summary>
        /// 假期名称
        /// </summary>
        public string LeaveName { get; set; }

        /// <summary>
        /// 请假单位，可以按照天半天或者小时请假。(day、halfday、hour其中一种)
        /// </summary>
        public string LeaveViewUnit { get; set; }

        /// <summary>
        /// 是否按照自然日统计请假时长，当为false的时候，用户发起请假时候会根据用户在请假时间段内的排班情况来计算请假时长。
        /// </summary>
        public Nullable<bool> NaturalDayLeave { get; set; }

        /// <summary>
        /// 操作者ID
        /// </summary>
        public string OpUserid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.attendance.vacation.type.update";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_type", this.BizType);
            parameters.Add("extras", this.Extras);
            parameters.Add("hours_in_per_day", this.HoursInPerDay);
            parameters.Add("leave_code", this.LeaveCode);
            parameters.Add("leave_name", this.LeaveName);
            parameters.Add("leave_view_unit", this.LeaveViewUnit);
            parameters.Add("natural_day_leave", this.NaturalDayLeave);
            parameters.Add("op_userid", this.OpUserid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("leave_code", this.LeaveCode);
            RequestValidator.ValidateRequired("op_userid", this.OpUserid);
        }

        #endregion
    }
}
