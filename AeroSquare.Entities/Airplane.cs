using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    [Table("Airplane")]
    public class Airplane
    {
        [Key]
        public int AirplaneId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public short Capacity { get; set; }
        public short FlightCrew { get; set; }

    }
}
