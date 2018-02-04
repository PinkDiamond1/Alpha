﻿using Auctus.DataAccess.Advisor;
using Auctus.DomainObjects.Advisor;
using Auctus.Util;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auctus.Business.Advisor
{
    public class AdvisorDetailBusiness : BaseBusiness<AdvisorDetail, AdvisorDetailData>
    {
        public AdvisorDetailBusiness(ILoggerFactory loggerFactory, Cache cache, INodeServices nodeServices) : base(loggerFactory, cache, nodeServices) { }

        public AdvisorDetail SetNew(int advisorId, string description, int period, double price, bool enabled)
        {
            ValidateBaseCreation(description, period, price);
            var advisorDetail = new AdvisorDetail();
            advisorDetail.AdvisorId = advisorId;
            advisorDetail.Date = DateTime.UtcNow;
            advisorDetail.Description = description;
            advisorDetail.Period = period;
            advisorDetail.Price = price;
            advisorDetail.Enabled = enabled; 
            return advisorDetail;
        }

        public AdvisorDetail Create(string email, int advisorId, string description, int period, double price, bool enabled)
        {
            var advisor = AdvisorBusiness.GetWithOwner(advisorId, email);
            if (advisor == null)
                throw new ArgumentException("Invalid advisor.");

            var advisorDetail = SetNew(advisor.Id, description, period, price, enabled);
            Data.Insert(advisorDetail);
            return advisorDetail;
        }

        private void ValidateBaseCreation(string description, int period, double price)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.");
            if (description.Length > 500)
                throw new ArgumentException("Description is too long.");
            if (period < 1)
                throw new ArgumentException("Period is invalid.");
            if (price < 0.000001)
                throw new ArgumentException("Price is invalid.");
        }
        
        public AdvisorDetail GetForAutoEnabled(int advisorId)
        {
            return Data.GetForAutoEnabled(advisorId);
        }
    }
}
