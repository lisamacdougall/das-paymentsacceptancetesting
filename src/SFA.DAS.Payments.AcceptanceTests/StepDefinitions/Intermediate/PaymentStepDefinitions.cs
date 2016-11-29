﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Payments.AcceptanceTests.Contexts;
using SFA.DAS.Payments.AcceptanceTests.DataHelpers;
using SFA.DAS.Payments.AcceptanceTests.Enums;
using SFA.DAS.Payments.AcceptanceTests.ExecutionEnvironment;
using SFA.DAS.Payments.AcceptanceTests.StepDefinitions.Base;
using TechTalk.SpecFlow;

namespace SFA.DAS.Payments.AcceptanceTests.StepDefinitions.Intermediate
{
    [Binding]
    public class PaymentStepDefinitions : BaseStepDefinitions
    {
        public PaymentStepDefinitions(StepDefinitionsContext earningAndPaymentsContext)
            : base(earningAndPaymentsContext)
        { }
            #region Payment Type Breakdown 

        [Given(@"an employer levy balance of (.*)")]
        public void GivenTheAccountHasABalance(decimal employerLevyBalance)
        {
            // Setup reference data
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            StepDefinitionsContext.SetDefaultProvider();

            var provider = StepDefinitionsContext.GetDefaultProvider();
            var learner = StepDefinitionsContext.CreateLearner(15000, new DateTime(2017, 08, 01), new DateTime(2018, 07, 01));


            //setup the data for learnig delivery,learner and earnings
            SetupEarningsData(provider, learner);

            var committment = StepDefinitionsContext.ReferenceDataContext.Commitments.First();
            var account = StepDefinitionsContext.ReferenceDataContext.Employers.FirstOrDefault(x => x.Name == committment.Employer);


            //Update the balance to the value passed in
            AccountDataHelper.UpdateAccountBalance(account.AccountId, employerLevyBalance, environmentVariables);

        }


        [When(@"a payment of (.*) is due")]
        public void WhenAPaymentIsDue(decimal dueAmount)
        {

            // Setup reference data
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //save the periodiosed values
            EarningsDataHelper.SavePeriodisedValuesForUkprn(StepDefinitionsContext.GetDefaultProvider().Ukprn,
                                                            new Dictionary<string, decimal> { { "Period_1", dueAmount } },
                                                            environmentVariables);


            RunMonthEnd(new DateTime(2016, 09, 01));
        }


        [Then(@"the employer levy account is debited by (.*)")]
        public void ThenALevyPaymentIsMade(decimal levyAccountDebit)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //Get the due amount 
            var levyEntity = PaymentsDataHelper.GetPaymentsForPeriod(StepDefinitionsContext.GetDefaultProvider().Ukprn,
                                                                        2016,
                                                                        09,
                                                                        FundingSource.Levy,
                                                                        environmentVariables)
                                                                        .FirstOrDefault();

            if (levyAccountDebit != 0)
            {
                Assert.IsNotNull(levyEntity, $"Expected Levy earning for the period but nothing found");
                Assert.AreEqual(levyAccountDebit, levyEntity.Amount, $"Expected earning of {levyAccountDebit} for period R01 but found {levyEntity.Amount}");
            }
            else
            {
                Assert.IsNull(levyEntity, $"There was no expected levy amount for the period but levy amount data found");

            }
        }

        [Then(@"the provider is paid (.*) by the SFA")]
        public void ThenAGovernmentPaymentIsMade(decimal paidBySFA)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //Get the due amount 
            var governmentDueEntity = PaymentsDataHelper.GetPaymentsForPeriod(StepDefinitionsContext.GetDefaultProvider().Ukprn,
                                                                        2016,
                                                                        09,
                                                                        FundingSource.CoInvestedSfa,
                                                                        environmentVariables)
                                                                        .FirstOrDefault();

            if (paidBySFA != 0)
            {
                Assert.IsNotNull(governmentDueEntity, $"Expected goverment due for the period but nothing found");
                Assert.AreEqual(paidBySFA, governmentDueEntity.Amount, $"Expected government payment of {paidBySFA} for period R01 but found {governmentDueEntity.Amount}");
            }
            else
            {
                Assert.IsNull(governmentDueEntity, $"There was no expected goverment due amount for the period but data was found");

            }
        }

        [Then(@"the provider is due (.*) from the employer")]
        public void ThenAEmployerAmountIsExpected(decimal paymentDueFromEmployer)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            //Get the due amount 
            var employerPaymentEntity = PaymentsDataHelper.GetPaymentsForPeriod(StepDefinitionsContext.GetDefaultProvider().Ukprn,
                                                                        2016,
                                                                        09,
                                                                        FundingSource.CoInvestedEmployer,
                                                                        environmentVariables)
                                                                       .FirstOrDefault();

            if (paymentDueFromEmployer != 0)
            {
                Assert.IsNotNull(employerPaymentEntity, $"Expected employer amount for the period but nothing found");
                Assert.AreEqual(paymentDueFromEmployer, employerPaymentEntity.Amount, $"Expected employer amount of {paymentDueFromEmployer} for period R01 but found {employerPaymentEntity.Amount}");
            }
            else
            {
                Assert.IsNull(employerPaymentEntity, $"There was no expected employer amount for the period but employer amount data found");

            }
        }



        #endregion
    }
}

