using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [MaxLength(100)]
        public string CustomerSurname { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Airplane { get; set; }
        public double Total { get; set; }
        public string FlightDate { get; set; }
        public int PaymentValidated { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
