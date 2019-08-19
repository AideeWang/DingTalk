using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class StringUtil
    {
        /// <summary>
        /// 比较两个字符是否相等，基于当前语言环境（CurrentCulture）
        /// </summary>
        /// <param name="original">源字符</param>
        /// <param name="destination">目标字符</param>
        /// <returns></returns>
        public static bool EqualsTo(this string original, string destination)
        {
            return AreEquals(original, destination);
        }

        /// <summary>
        /// 比较两个字符是否相等，基于当前语言环境（CurrentCulture）
        /// </summary>
        /// <param name="original"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool AreEquals(string original, string destination)
        {
            if (original == null) { return false; }
            if (destination == null) { return false; }
            return original.Equals(destination, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 比较两个字符是否不相等，基于当前语言环境（CurrentCulture）
        /// </summary>
        /// <param name="original">源字符</param>
        /// <param name="destination">目标字符</param>
        /// <returns></returns>
        public static bool NotEqualsTo(this string original, string destination)
        {
            return AreNotEquals(original, destination);
        }

        /// <summary>
        /// 比较两个字符是否不相等，基于当前语言环境（CurrentCulture）
        /// </summary>
        /// <param name="original">源字符</param>
        /// <param name="destination">目标字符</param>
        /// <returns></returns>
        public static bool AreNotEquals(string original, string destination)
        {
            if (original == null) { return false; }
            if (destination == null) { return false; }
            return !original.Equals(destination, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 比较orginal字符串与destination字符串是否相似
        /// </summary>
        /// <param name="original"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool LikeTo(this string original, string destination)
        {
            return IsLike(original, destination);
        }

        /// <summary>
        /// 比较orginal字符串与destination字符串是否相似
        /// </summary>
        /// <param name="original"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool IsLike(string original, string destination)
        {
            if (original == null) { return false; }
            if (destination == null) { return false; }

            return destination.Contains(original);
        }
        /// <summary>
        /// 校验邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <param name="allowEmpty">true 允许邮箱为空,不为空时校验邮箱格式，为空时直接返回true</param>
        /// <returns></returns>
        public static bool IsEmail(this string value, bool allowEmpty = false)
        {
            if (allowEmpty && string.IsNullOrWhiteSpace(value)) return true;
            if (string.IsNullOrWhiteSpace(value)) { return false; }

            //return Regex.IsMatch(value, @"^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,10})\s*$");
            //return Regex.IsMatch(value, @"^\s*([a-zA-Z0-9_\.\-])+@([a-zA-Z0-9_\.\-])+((\.[a-zA-Z0-9_\.\-]{2,3}){1,2})\s*$");
            //return Regex.IsMatch(value, @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$");
            return Regex.IsMatch(value, @"^((([a-z]|[A-Z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|[A-Z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|[A-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[A-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|[A-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[A-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[A-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[A-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|[A-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[A-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$");
        }

        public static bool IsLegalPerson(this string value, bool allowEmpty = false)
        {
            if (allowEmpty && string.IsNullOrWhiteSpace(value)) return true;
            if (string.IsNullOrWhiteSpace(value)) { return false; }
            return Regex.IsMatch(value, @"^[\u4e00-\u9fa5]{2,}$");
        }

        public static bool IsName(this string value, bool allowEmpty = false)
        {
            if (allowEmpty && string.IsNullOrWhiteSpace(value)) return true;
            if (string.IsNullOrWhiteSpace(value)) { return false; }
            return Regex.IsMatch(value, @"^[\u4e00-\u9fa5]{2,}$|^[a-zA-Z]{3,}$");
        }

        public static bool IsGuid(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { return false; }
            var g = Guid.NewGuid();
            return Guid.TryParse(value, out g);
        }

        public static bool IsInt(this string value)
        {
            return Regex.IsMatch(value, @"\d+$");
        }

        public static bool IsIDNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { return false; }
            return Regex.IsMatch(value, @"^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$");
        }
        /// <summary>
        /// 校验手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="allowEmpty">true 允许手机号码为空,不为空时校验手机号码格式，为空时直接返回true</param>
        /// <returns></returns>
        public static bool IsCellPhoneNumber(this string value, bool allowEmpty = false)
        {
            if (allowEmpty && string.IsNullOrWhiteSpace(value)) return true;
            if (string.IsNullOrWhiteSpace(value)) { return false; }
            return Regex.IsMatch(value, @"^1[3,4,5,6,7,8,9]\d{9}$");
        }

    }
}
