using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public int DestinationId { get; set; }
        public int OriginId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal ListPrice { get; set; }

        public Origin Origin { get; set; }
        public Destination Destination { get; set; }
        public Airplane Airplane { get; set; }
        public ICollection<FlightDays> FlightDays { get; set; }
    }
}
