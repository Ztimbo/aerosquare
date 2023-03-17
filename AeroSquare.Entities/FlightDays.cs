using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    [Table("FlightDays")]
    public class FlightDays
    {
        [Key]
        public int FlightDayId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
