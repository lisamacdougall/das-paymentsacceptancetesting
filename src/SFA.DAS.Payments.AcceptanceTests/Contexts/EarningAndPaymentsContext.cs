﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Payments.AcceptanceTests.Contexts
{
    public class EarningAndPaymentsContext
    {

        public EarningAndPaymentsContext(ReferenceDataContext referenceDataContext)
        {
            ReferenceDataContext = referenceDataContext;
        }

        public ReferenceDataContext ReferenceDataContext { get; set; }
        public DateTime IlrStartDate
        {
            get { return Learners.Min(l => l.LearningDelivery.StartDate); }
        }
        public DateTime IlrEndDate
        {
            get
            {
                var maxActualEndDate = Learners.Max(l => l.LearningDelivery.ActualEndDate) ?? DateTime.MinValue;
                var maxEndDate = Learners.Max(l => l.LearningDelivery.PlannedEndDate);

                return maxActualEndDate > maxEndDate
                    ? maxActualEndDate
                    : maxEndDate;
            }
        }
        public Learner[] Learners { get; set; }
        public Dictionary<string, decimal> EarnedByPeriod { get; set; }
        public long Ukprn { get; set; }
        public string AccountId { get; set; }
    }
}