using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities.DTOs
{
    public class FlightDTO
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Airplane { get; set; }
        public double ListPrice { get; set; }
    }
}
