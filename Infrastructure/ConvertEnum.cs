using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Infrastructure
{
    public static class ConvertEnum
    {


        /// <summary>
        /// 获取枚举的值与特性说明 以 特定的 对象 结构显示
        /// </summary>
        /// <returns></returns>
        public static List<object> GetEnumNameList<T>()
        {
            List<object> dict = new List<object>();
            Type t = typeof(T);
            Array arrays = Enum.GetValues(t);
            for (int i = 0; i < arrays.LongLength; i++)
            {
                Enum tmp = (Enum)arrays.GetValue(i);
                string Description = GetEnumDescription(tmp);
                dict.Add(new { key = tmp, value = Description });
            }
            return dict;
        }

        /// <summary>
        /// 获取枚举的值与特性说明
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetTypeDict<T>()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            Type t = typeof(T);
            Array arrays = Enum.GetValues(t);
            for (int i = 0; i < arrays.LongLength; i++)
            {
                Enum tmp = (Enum)arrays.GetValue(i);
                string Description = GetEnumDescription(tmp);
                dict.Add(Convert.ToInt32(tmp), Description);
            }
            return dict;
        }


        public static List<object> GetEnumList<T>(this Enum obj)
        {
            List<object> list = new List<object>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new { value = item, name = Enum.GetName(typeof(T), item) });
            }
            return list;
        }


        /// <summary>
        /// 获取一个枚举值的中文描述
        /// </summary>
        /// <param name="obj">枚举值</param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum obj)
        {
            FieldInfo fi = obj.GetType().GetField(obj.ToString());
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return arrDesc[0].Description;
        }

    }
}