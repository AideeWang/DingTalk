using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure
{
    public static class StringExtensions
    {
        public static string MaxSubstring(this string origin, int maxLength)
        {
            return origin.Length >= maxLength ? origin.Substring(0, maxLength) : origin;
        }

        public static string ToMd5(this string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                return string.Empty;
            }

            var md5Algorithm = MD5.Create();
            var utf8Bytes = Encoding.UTF8.GetBytes(origin);
            var md5Hash = md5Algorithm.ComputeHash(utf8Bytes);
            var hexString = new StringBuilder();
            foreach (var hexByte in md5Hash)
            {
                hexString.Append(hexByte.ToString("x2"));
            }
            return hexString.ToString();
        }

        public static string ObjectToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T StringToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static T ToEnum<T>(this string data)
        {
            var result = default(T);
            try
            {
                return (T)Enum.Parse(typeof(T), data, true);
            }
            catch
            {
                return result;
            }
        }

        public static T ToEnum<T>(this int data)
        {
            var result = default(T);
            try
            {
                return (T)Enum.Parse(typeof(T), data.ToString(), true);
            }
            catch
            {
                return result;
            }
        }

        public static DateTime ToDate(this string date)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(date, out dt))
            {
                return dt;
            }
            throw new ArgumentException("date");
        }

        public static DateTime ToDateMonth(this string date)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(date, out dt))
            {
                return new DateTime(dt.Year, dt.Month, 1);
            }
            throw new ArgumentException("date");
        }

        public static DateTime? ToNullableDate(this string date)
        {
            if (string.IsNullOrWhiteSpace(date)) { return null; }
            return date.ToDate();
        }

        public static int ToInt(this string num)
        {
            if (string.IsNullOrEmpty(num)) { return 0; }
            //CheckParameter.NotEmpty(num, "num");

            int n = 0;
            if (int.TryParse(num, out n))
            {
                return n;
            }
            throw new ArgumentException("num");
        }

        public static decimal ToDecimal(this string num)
        {
            if (string.IsNullOrEmpty(num)) { return 0M; }
            //CheckParameter.NotEmpty(num, "num");
            num = num.ClearCurrencyFormat();
            decimal n = 0;
            if (decimal.TryParse(num, out n))
            {
                return n;
            }
            throw new ArgumentException("num");
        }

        public static string ToDecimalOneDigital(this decimal num)
        {
            if (num == Convert.ToInt32(num))
            {
                return string.Format("{0:###,##}", num);
            }
            return string.Format("{0:f1}", num);
        }

        public static string ToDecimalOneDigital(this decimal? num)
        {
            return num.HasValue ? num.Value.ToDecimalOneDigital() : string.Empty;
        }

        public static int? ToNullableInt(this string num)
        {
            if (string.IsNullOrWhiteSpace(num) || !num.IsInt()) { return null; }
            return num.ToInt();
        }

        public static decimal? ToNullableDecimal(this string num)
        {
            if (string.IsNullOrWhiteSpace(num)) { return null; }
            return num.ToDecimal();
        }

        public static string FromNullableInt(this int? num)
        {
            if (num.HasValue) { return num.Value.ToString(); }
            return string.Empty;
        }

        //public static string ToRSAEncrypt(this string str)
        //{
        //    return Cryptography.AES_decrypt(str);
        //}

        public static string ToRSADecrypt(this string str)
        {
            try
            {
                return Cryptography.DESDecryption(str);
            }
            catch { return str; }
        }

        public static string ClearCurrencyFormat(this string value)
        {
            return value.Replace(",", string.Empty).Replace("￥", string.Empty);
        }

        //public static string GetEnumDescription(this Enum enumValue)
        //{
        //    string value = enumValue.ToString();
        //    FieldInfo field = enumValue.GetType().GetField(value);
        //    object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
        //    if (objs.Length == 0)    //当描述属性没有时，直接返回名称
        //        return value;
        //    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
        //    return descriptionAttribute.Description;
        //}
    }
}