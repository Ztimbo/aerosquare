﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public Destination Destination { get; set; }
        public Origin Origin { get; set; }
    }
}
