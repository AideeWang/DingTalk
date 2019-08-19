
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
    public class NameValuePairsRepository : Repository<NameValuePairs>, INameValuePairsRepository
	{
		public NameValuePairsRepository() : base(DingTalkSyncDBContext.GetInstance()) { }

        public IEnumerable<NameValuePairs> GetNameValuePairs(string Category)
        {
            return this.GetFiltered(a => a.Category == Category && a.FlagDeleted == 0);
        }
	} 
}