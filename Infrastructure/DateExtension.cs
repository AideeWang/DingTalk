using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DateExtension
    {
        public static string ToDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ToFlightDate(this DateTime date)
        {
            var flightDate = string.Empty;
            if (date.Hour == 0 && date.Minute == 0)
            {
                flightDate = date.ToChineseDate();
            }
            else
            {
                flightDate = date.ToChineseDateTime();
            }

            return flightDate;
        }

        public static string ToDateTime(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取xxxx年xx月xx日 xx:xx
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToChineseDateTime(this DateTime date)
        {
            return date.ToString("yyyy年MM月dd日 HH:mm");
        }

        /// <summary>
        /// 获取xxxx年xx月xx日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToChineseDate(this DateTime date)
        {
            return date.ToString("yyyy年MM月dd日");
        }

        public static string ToDateMonth(this DateTime date)
        {
            return date.ToString("yyyy-MM");
        }

        public static string ToTime(this DateTime date)
        {
            return date.ToString("HH:mm");
        }

        public static string ToDate(this DateTime? date)
        {
            if (!date.HasValue) { return string.Empty; }
            return date.Value.ToDate();
        }

        /// <summary>
        /// 指定的时间离现在有多久（超过三天直接返回当前指定的时间）
        /// </summary>
        /// <param name="date">指定的时间</param>
        public static string HowLongFromNow(this DateTime? date)
        {
            if (date == null) { return string.Empty; }

            return ((DateTime)date).HowLongFromNow();
        }

        /// <summary>
        /// 指定的时间离现在有多久（超过三天直接返回当前指定的时间）
        /// </summary>
        /// <param name="date">指定的时间</param>
        public static string HowLongFromNow(this DateTime date)
        {
            var now = DateTime.Now;

            //if:当前时间小于指定的时间,返回值类似于"......之后";  else:返回值类似于"......以前"
            if (now < date)
            {
                //待处理
            }
            else
            {
                var span = now - date;
                var daySpan = now.Day - date.Day;

                if (daySpan >= 3 || span.Days >= 4) { return ((DateTime)date).ToString("yyyy-MM-dd"); }
                else if (daySpan >= 2 || span.Days >= 3) { return "前天"; }
                else if (daySpan >= 1 || span.Days >= 2) { return "昨天"; }
                else if (span.Hours >= 1) { return span.Hours.ToString() + "小时前"; }
                else if (span.Minutes >= 1) { return span.Minutes.ToString() + "分钟前"; }
                else { return "刚刚"; }
            }

            return string.Empty;
        }
    }
}
