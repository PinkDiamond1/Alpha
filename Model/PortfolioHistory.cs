﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Auctus.Model
{
    public class PortfolioHistory
    {
        public int Risk { get; set; }
        public int AdvisorId { get; set; }
        public List<HistoryValue> Values { get; set; }

        public class HistoryValue
        {
            public DateTime Date { get; set; }
            public double Value { get; set; }
        }
    }
}