using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Domain.DingTalkSync.Repository;
using Domain.DingTalkSync.DTO;

namespace Application.Service
{
    public class NameValuePairsService:INameValuePairsService
    {
        INameValuePairsRepository nameValuePairsRepository = ServiceLoader.LoadService<INameValuePairsRepository>();
        public List<string> GetNameValue(string Category)
        {
            CheckParameter.NotEmpty(Category, "GetNameValue 中的Category值为空");
            List<string> ValueList = new List<string>();
            
            var NameValueList = nameValuePairsRepository.GetNameValuePairs(Category);
            if (NameValueList != null)
            {
                foreach (var item in NameValueList)
                {
                    ValueList.Add(item.Value);
                }
            }
            return ValueList;
        }

        public Dictionary<string, object> GetNameValueList(string Categorys)
        {
            CheckParameter.NotEmpty(Categorys, "GetNameValueList 中的Categorys值为空");
            Dictionary<string, object> dic = new Dictionary<string, object>(); 
            string[] CategoryArray = Categorys.Split(',');
            foreach (string item in CategoryArray)
            {
                dic.Add(item, GetNameValue(item));
            }
            return dic;
        }
    }
}
