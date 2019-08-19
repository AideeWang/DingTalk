using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class NameValuePairsMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NameValuePairs>
    {
        public NameValuePairsMap()
        {
            // table
            ToTable("NameValuePairs", "dbo");

            // keys
            HasKey(t => t.ID);
        }
    }
}
