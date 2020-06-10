﻿using System;
using System.Collections.Generic;

namespace CSharp.NET_CAPSTONE_GC_Car_Dealership.Models
{
    public partial class CarInfo
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
    }
}