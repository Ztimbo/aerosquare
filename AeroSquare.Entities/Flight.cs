using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
        public double ListPrice { get; set; }

        [ForeignKey("OriginId")]
        public virtual Origin Origin { get; set; }
        [ForeignKey("DestinationId")]
        public virtual Destination Destination { get; set; }
        [ForeignKey("AirplaneId")]
        public virtual Airplane Airplane { get; set; }

        public virtual ICollection<FlightDays> FlightDays { get; set; }
    }
}
