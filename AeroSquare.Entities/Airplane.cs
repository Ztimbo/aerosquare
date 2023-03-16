﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Entities
{
    public class Airplane
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public short Capacity { get; set; }
        public short FlightCrew { get; set; }

    }
}
