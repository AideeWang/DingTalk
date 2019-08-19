
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DingTalkSync.Entity;
using Domain.UnitOfWork;

namespace Domain.DingTalkSync.Repository
{
	/// <summary>
	/// NameValuePairs
	/// </summary>
	public interface INameValuePairsRepository:IRepository<NameValuePairs>
	{
        IEnumerable<NameValuePairs> GetNameValuePairs(string Category);
	} 
}