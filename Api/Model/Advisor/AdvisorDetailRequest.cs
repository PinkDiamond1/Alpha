﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Advisor
{
    public class AdvisorDetailRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }
}
