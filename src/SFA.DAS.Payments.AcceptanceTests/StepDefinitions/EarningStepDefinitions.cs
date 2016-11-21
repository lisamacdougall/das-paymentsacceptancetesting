﻿using NUnit.Framework;
using ProviderPayments.TestStack.Core;
using SFA.DAS.Payments.AcceptanceTests.Contexts;
using SFA.DAS.Payments.AcceptanceTests.DataHelpers;
using SFA.DAS.Payments.AcceptanceTests.ExecutionEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Payments.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EarningStepDefinitions : BaseCalculationSteps
    {
        public EarningStepDefinitions(EarningAndPaymentsContext earningAndPaymentsContext)
            :base(earningAndPaymentsContext)
        {

        }

        [Given(@"a provider has previously earned (.*) in period R01")]
        public void GivenProviderHasPreviouslyEarnedInPeriod(decimal previousAmount)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            EarningAndPaymentsContext.SetDefaultProvider();

            var provider = EarningAndPaymentsContext.GetDefaultProvider();
            var learner = EarningAndPaymentsContext.CreateLearner(15000, new DateTime(2017, 08, 01), new DateTime(2018, 07, 01));

            SetupEarningsData(provider, learner);


            var committment = EarningAndPaymentsContext.ReferenceDataContext.Commitments.First();
            var account = EarningAndPaymentsContext.ReferenceDataContext.Employers.FirstOrDefault(x => x.Name == committment.Employer);


            //Save the previous earning
            EarningsDataHelper.SaveEarnedAmount(provider.Ukprn,
                                                committment.Id,
                                                account.AccountId,
                                                learner.Uln,
                                                "R01",
                                                08,
                                                2016,
                                                1,
                                                previousAmount, environmentVariables);

        }

        [When(@"an earning of (.*) is calculated for period R01")]
        public void AnEarningIsCalculatedForThePeriod(decimal earnedAmount)
        {

            // Setup reference data
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //save the periodiosed values
            EarningsDataHelper.SavePeriodisedValuesForUkprn(EarningAndPaymentsContext.GetDefaultProvider().Ukprn,
                                                            new Dictionary<string, decimal> { { "Period_1", earnedAmount } },
                                                            environmentVariables);

            RunMonthEnd(new DateTime(2016, 09, 01));
        }

        [Then(@"a payment of (.*) is due")]
        public void ThenAPaymentIsDue(decimal dueAmount)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //Get the due amount 
            var earning = PaymentsDueDataHelper.GetPaymentsDueForPeriod(EarningAndPaymentsContext.GetDefaultProvider().Ukprn,
                                                                        2016,
                                                                        09,
                                                                        environmentVariables)
                                                                        .FirstOrDefault();

            if (dueAmount != 0)
            {
                Assert.IsNotNull(earning, $"Expected earning for the period but nothing found");
                Assert.AreEqual(dueAmount, earning.AmountDue, $"Expected earning of {dueAmount} for period R01 but found {earning.AmountDue}");
            }
            else
            {
                Assert.IsNull(earning, $"There was no expected earning for the period but earnigs data found");

            }
        }


        #region Earnings Distribution

        [When(@"the planned course duration covers (.*) months")]
        public void WhenThePlannedCourseDurationCoversMonths(int months)
        {
            ScenarioContext.Current.Add("months", months);
        }

        [When(@"an agreed price of (.*)")]
        public void WhenAnAgreedPriceOf(decimal agreedPrice)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();
            //get months value
            var months = ScenarioContext.Current.Get<int>("months");

            EarningAndPaymentsContext.SetDefaultProvider();

            var provider = EarningAndPaymentsContext.GetDefaultProvider();

            var startDate = new DateTime(2017, 08, 01);
            var learner = EarningAndPaymentsContext.CreateLearner(agreedPrice, startDate, startDate.AddMonths(months));

            // Store spec values in context
            EarningAndPaymentsContext.AddProviderLearner(provider, learner);


            //set a default employer
            EarningAndPaymentsContext.ReferenceDataContext.SetDefaultEmployer(
                                                new Dictionary<string, decimal> {
                                                    { "All", int.MaxValue }
                                                });

            // Setup reference data
            SetupReferenceData();

            // Process months
            var ilrStartDate = startDate.NextCensusDate();

            SubmitIlr(provider.Ukprn, provider.Learners,
                ilrStartDate.GetAcademicYear(),
                ilrStartDate.NextCensusDate(),
                new ProcessService(new TestLogger()),
                provider.EarnedByPeriod);
        }

        [Then(@"the monthly earnings is (.*)")]
        public void ThenTheMonthlyEarningsIs(decimal monthlyEarnings)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            var learner = EarningAndPaymentsContext.GetDefaultProvider().Learners.FirstOrDefault();
            var output = LearnerDataHelper.GetAELearningDelivery(EarningAndPaymentsContext.GetDefaultProvider().Ukprn,
                                                                learner.Uln,
                                                                learner.LearningDelivery.StartDate,
                                                                learner.LearningDelivery.PlannedEndDate,
                                                                environmentVariables);


            Assert.IsNotNull(output, $"Expected AE Learning Delivery but nothing found");
            Assert.AreEqual(monthlyEarnings, output.MonthlyInstallment, $"Expected monthly installment of {monthlyEarnings} but found {output.MonthlyInstallment}");


        }

        [Then(@"the completion payment is (.*)")]
        public void ThenTheCompletionPaymentIs(decimal completionPayment)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            var learner = EarningAndPaymentsContext.GetDefaultProvider().Learners.FirstOrDefault();
            var output = LearnerDataHelper.GetAELearningDelivery(EarningAndPaymentsContext.GetDefaultProvider().Ukprn,
                                                                learner.Uln,
                                                                learner.LearningDelivery.StartDate,
                                                                learner.LearningDelivery.PlannedEndDate,
                                                                environmentVariables);


            Assert.IsNotNull(output, $"Expected AE Learning Delivery but nothing found");
            Assert.AreEqual(completionPayment, output.CompletionPayment, $"Expected completion payment of {completionPayment} but found {output.CompletionPayment}");


        }

        #endregion
    }
}
