using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities.DTOs
{
    public class CityDTO
    {
        public string Name { get; set; }
        public bool IsOrigin { get; set; }
        public bool IsDestination { get; set; }
    }
}
