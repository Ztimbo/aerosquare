using AeroSquare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> SaveOrder(Order order);
    }
}
