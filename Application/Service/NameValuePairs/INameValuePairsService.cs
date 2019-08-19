using Domain.DingTalkSync.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface INameValuePairsService
    {
        /// <summary>
        /// 获取单个类别的配置键值对
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        List<string> GetNameValue(string Category);

        /// <summary>
        /// 获取多个类别的配置键值对
        /// </summary>
        /// <param name="Categorys"></param>
        /// <returns></returns>
        Dictionary<string, object> GetNameValueList(string Categorys);
    }
}
