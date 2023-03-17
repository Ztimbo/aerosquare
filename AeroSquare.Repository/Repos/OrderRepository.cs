using AeroSquare.Entities;
using AeroSquare.Repository.Repos.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace AeroSquare.Repository.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string _functionUri;

        public OrderRepository(IConfiguration configuration)
        {
            _functionUri = configuration["AzureFunctions:CreateOrder"];
        }

        public async Task<bool> SaveOrder(Order order)
        {
            var body = JsonConvert.SerializeObject(order);
            var buffer = Encoding.UTF8.GetBytes(body);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PostAsync(_functionUri, byteContent);
            return true;
        }
    }
}
