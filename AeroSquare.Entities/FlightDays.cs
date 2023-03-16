using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class FlightDays
    {
        public int FlightDayId { get; set; }
        public string Name { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
