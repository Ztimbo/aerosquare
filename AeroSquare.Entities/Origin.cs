using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class Origin
    {
        [Key]
        public int OriginId { get; set; }
        public int CityId { get; set; }

        public Flight Flight { get; set; }
        public City City { get; set; }
    }
}
