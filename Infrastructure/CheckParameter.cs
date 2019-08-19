using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CheckParameter
    {
        /// <summary>
        /// 判断参数不能为空,若为空则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">参数对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <returns></returns>
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(parameterName + " 为空");
            }
            return value;
        }

        public static int GreaterZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format("参数：{0} 的值必须大于0!", parameterName));
            }
            return value;
        }

        /// <summary>
        /// 检测指定的JSON字符串与指定的类型是否匹配，若不匹配则将抛出异常
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="json">指定的JSON字符串</param>
        /// <param name="jsonParmeterName">json参数名称</param>
        public static string JsonMatchObject<T>(string json, string jsonParmeterName) where T : class
        {
            try
            {
                JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("{0} format error!", jsonParmeterName ?? string.Empty), ex);
            }
            return json;
        }
    }
}
