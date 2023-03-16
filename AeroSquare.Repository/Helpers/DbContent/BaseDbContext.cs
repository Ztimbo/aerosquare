using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Repository.Helpers.DbContent
{
    public class BaseDbContext<T> : DbContext, IDbContext where T : DbContext
    {
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public void SyncObjectState(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
