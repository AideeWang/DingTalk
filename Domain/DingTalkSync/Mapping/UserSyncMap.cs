using Domain.DingTalkSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.Mapping
{
    public class UserSyncMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserSync>
    {
        public UserSyncMap()
        {
            // table
            ToTable("UserSync", "dbo");

            // keys
            HasKey(t => t.UserID);
        }
    }
}
