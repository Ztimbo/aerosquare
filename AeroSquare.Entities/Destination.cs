using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string CityId { get; set; }

        public Flight Flight { get; set; }
        public City City { get; set; }
    }
}
