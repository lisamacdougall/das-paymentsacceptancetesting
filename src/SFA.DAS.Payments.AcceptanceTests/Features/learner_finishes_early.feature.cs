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
    [NUnit.Framework.DescriptionAttribute("Provider earnings and payments where learner completes earlier than planned and i" +
        "s funded by levy")]
    public partial class ProviderEarningsAndPaymentsWhereLearnerCompletesEarlierThanPlannedAndIsFundedByLevyFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "learner_finishes_early.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Provider earnings and payments where learner completes earlier than planned and i" +
                    "s funded by levy", "    The earnings and payment rules for early completions are the same as for lear" +
                    "ners finishing on time, except that the completion payment is earned earlier.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 5
    #line 6
        testRunner.Given("The learner is programme only DAS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
        testRunner.And("the agreed price is 15000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
        testRunner.And("the apprenticeship funding band maximum is 17000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
        testRunner.And("levy balance > agreed price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Earnings for a DAS learner, levy available, learner finishes early")]
        public virtual void EarningsForADASLearnerLevyAvailableLearnerFinishesEarly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Earnings for a DAS learner, levy available, learner finishes early", ((string[])(null)));
#line 11
    this.ScenarioSetup(scenarioInfo);
#line 5
    this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table1.AddRow(new string[] {
                        "01/09/2017",
                        "08/09/2018",
                        "08/08/2018",
                        "completed"});
#line 12
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18"});
            table2.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "4000",
                        "0"});
            table2.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "4000",
                        "0"});
            table2.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "4000"});
            table2.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "4000"});
            table2.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "4000",
                        "0"});
            table2.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0"});
#line 15
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion