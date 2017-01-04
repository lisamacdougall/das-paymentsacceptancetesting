﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.DAS.Payments.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Provider earnings and payments where learner changes apprenticeship standard")]
    public partial class ProviderEarningsAndPaymentsWhereLearnerChangesApprenticeshipStandardFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "change_in_circumstances.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Provider earnings and payments where learner changes apprenticeship standard", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line 4
testRunner.Given("The learner is programme only DAS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
testRunner.And("the apprenticeship funding band maximum is 17000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
testRunner.And("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Earnings and payments for a DAS learner, levy available, where the apprenticeship" +
            " standard changes and data lock is passed in both instances")]
        public virtual void EarningsAndPaymentsForADASLearnerLevyAvailableWhereTheApprenticeshipStandardChangesAndDataLockIsPassedInBothInstances()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Earnings and payments for a DAS learner, levy available, where the apprenticeship" +
                    " standard changes and data lock is passed in both instances", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "commitment Id",
                        "ULN",
                        "standard code",
                        "price effective date",
                        "planned end date",
                        "actual end date",
                        "agreed price"});
            table1.AddRow(new string[] {
                        "1",
                        "learner a",
                        "51",
                        "01/08/2017",
                        "01/08/2018",
                        "31/10/2017",
                        "15000"});
            table1.AddRow(new string[] {
                        "2",
                        "learner a",
                        "52",
                        "03/11/2017",
                        "01/08/2018",
                        "",
                        "5625"});
#line 10
testRunner.Given("the following commitments exist on 03/12/2017:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "standard code",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status",
                        "Total training price",
                        "Total training price effective date",
                        "Total assessment price",
                        "Total assessment price effective date"});
            table2.AddRow(new string[] {
                        "learner a",
                        "51",
                        "03/08/2017",
                        "01/08/2018",
                        "31/10/2017",
                        "transferred",
                        "12000",
                        "03/08/2017",
                        "3000",
                        "03/08/2017"});
            table2.AddRow(new string[] {
                        "learner a",
                        "52",
                        "03/11/2017",
                        "01/08/2018",
                        "",
                        "continuing",
                        "4500",
                        "03/11/2017",
                        "1125",
                        "03/11/2017"});
#line 15
testRunner.When("an ILR file is submitted on 03/12/2017 with the following data:", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17 - 10/17",
                        "11/17 onwards"});
            table3.AddRow(new string[] {
                        "Matching commitment",
                        "1",
                        "2"});
#line 20
testRunner.Then("the data lock status of the ILR in 03/12/2017 is:", ((string)(null)), table3, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17"});
            table4.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "500",
                        "500"});
            table4.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "500",
                        "500"});
            table4.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "500"});
            table4.AddRow(new string[] {
                        "Employer Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "500"});
            table4.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "500",
                        "0"});
            table4.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 24
testRunner.And("the provider earnings and payments break down as follows:", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ILR changes before second Commitment starts (i.e. there is only one existing Comm" +
            "itment in place)")]
        public virtual void ILRChangesBeforeSecondCommitmentStartsI_E_ThereIsOnlyOneExistingCommitmentInPlace()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ILR changes before second Commitment starts (i.e. there is only one existing Comm" +
                    "itment in place)", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "commitment Id",
                        "ULN",
                        "standard code",
                        "price effective date",
                        "planned end date",
                        "actual end date",
                        "agreed price"});
            table5.AddRow(new string[] {
                        "1",
                        "learner a",
                        "51",
                        "03/08/2017",
                        "04/08/2018",
                        "31/10/2017",
                        "15000"});
#line 37
testRunner.Given("the following commitments exist on 03/12/2017:", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "standard code",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status",
                        "Total training price",
                        "Total training price effective date",
                        "Total assessment price",
                        "Total assessment price effective date"});
            table6.AddRow(new string[] {
                        "learner a",
                        "51",
                        "03/08/2017",
                        "01/08/2018",
                        "31/10/2017",
                        "transferred",
                        "12000",
                        "03/08/2017",
                        "3000",
                        "03/08/2017"});
            table6.AddRow(new string[] {
                        "learner a",
                        "52",
                        "03/11/2017",
                        "01/08/2018",
                        "",
                        "continuing",
                        "4500",
                        "03/11/2017",
                        "1125",
                        "03/11/2017"});
#line 41
testRunner.When("an ILR file is submitted on 03/12/2017 with the following data:", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17 - 10/17",
                        "11/17 onwards"});
            table7.AddRow(new string[] {
                        "Matching commitment",
                        "1",
                        "FAIL"});
#line 46
testRunner.Then("the data lock status of the ILR in 03/12/2017 is:", ((string)(null)), table7, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17"});
            table8.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "500",
                        "500"});
            table8.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "500",
                        "500"});
            table8.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "0"});
            table8.AddRow(new string[] {
                        "Employer Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "0"});
            table8.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "0",
                        "0"});
            table8.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 50
testRunner.And("the provider earnings and payments break down as follows:", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("New Commitment which is not reflected in the updated ILR submission (i.e. new Com" +
            "mitment but no corresponding change in the ILR).")]
        public virtual void NewCommitmentWhichIsNotReflectedInTheUpdatedILRSubmissionI_E_NewCommitmentButNoCorrespondingChangeInTheILR_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("New Commitment which is not reflected in the updated ILR submission (i.e. new Com" +
                    "mitment but no corresponding change in the ILR).", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "commitment Id",
                        "ULN",
                        "standard code",
                        "price effective date",
                        "planned end date",
                        "actual end date",
                        "agreed price",
                        "status"});
            table9.AddRow(new string[] {
                        "1",
                        "learner a",
                        "51",
                        "03/08/2017",
                        "04/08/2018",
                        "31/10/2017",
                        "15000",
                        "cancelled"});
            table9.AddRow(new string[] {
                        "2",
                        "learner a",
                        "52",
                        "01/11/2017",
                        "04/08/2018",
                        "",
                        "5625",
                        "active"});
#line 62
testRunner.Given("the following commitments exist on 03/12/2017:", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "standard code",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status",
                        "Total training price",
                        "Total training price effective date",
                        "Total assessment price",
                        "Total assessment price effective date"});
            table10.AddRow(new string[] {
                        "learner a",
                        "51",
                        "03/08/2017",
                        "04/08/2018",
                        "",
                        "continuing",
                        "12000",
                        "03/08/2017",
                        "3000",
                        "03/08/2017"});
#line 68
testRunner.When("an ILR file is submitted on 03/12/2017 with the following data:", ((string)(null)), table10, "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17 - 10/17",
                        "11/17 onwards"});
            table11.AddRow(new string[] {
                        "Matching commitment",
                        "1",
                        "FAIL"});
#line 72
testRunner.Then("the data lock status of the ILR in 03/12/2017 is:", ((string)(null)), table11, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17",
                        "01/18"});
            table12.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table12.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table12.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "0",
                        "0"});
            table12.AddRow(new string[] {
                        "Employer Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "0",
                        "0"});
            table12.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table12.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 76
testRunner.And("the provider earnings and payments break down as follows:", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
