using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Repository.Helpers.DbContent
{
    public interface IGenericRepo<TEntity>
    {
        Task<int> SaveAsync();
        void Update(TEntity entity);
    }
}
