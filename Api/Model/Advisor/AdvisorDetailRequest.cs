﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Advisor
{
    public class AdvisorDetailRequest
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Period { get; set; }
        public bool Enabled { get; set; }
    }
}