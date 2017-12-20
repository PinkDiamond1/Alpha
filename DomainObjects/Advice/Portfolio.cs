﻿using Auctus.Util.DapperAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auctus.DomainObjects.Advice
{
    public class Portfolio
    {
        [DapperKey(true)]
        [DapperType(System.Data.DbType.Int32)]
        public int Id { get; set; }
        [DapperType(System.Data.DbType.Int32)]
        public int AdvisorId { get; set; }
        [DapperType(System.Data.DbType.Int32)]
        public int Risk { get; set; }
        [DapperType(System.Data.DbType.DateTime)]
        public DateTime CreationDate { get; set; }
        [DapperType(System.Data.DbType.DateTime)]
        public DateTime? Disabled { get; set; }
        [DapperType(System.Data.DbType.Int32)]
        public int? ProjectionId { get; set; }

        public Projection Projection { get; set; }

        public List<Projection> Projections { get; set; }
    }
}
