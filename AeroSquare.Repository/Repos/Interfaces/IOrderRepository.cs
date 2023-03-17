using AeroSquare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Repository.Repos.Interfaces
{
    public interface IOrderRepository
    {
        public Task<bool> SaveOrder(Order order);
    }
}
