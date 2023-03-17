using AeroSquare.Entities;
using AeroSquare.Repository.Repos.Interfaces;
using AeroSquare.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> SaveOrder(Order order)
        {
            return await _orderRepository.SaveOrder(order);
        }
    }
}
