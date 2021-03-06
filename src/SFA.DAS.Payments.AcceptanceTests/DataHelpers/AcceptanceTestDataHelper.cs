﻿using System;
using System.Data.SqlClient;
using Dapper;
using ProviderPayments.TestStack.Core;

namespace SFA.DAS.Payments.AcceptanceTests.DataHelpers
{
    internal static class AcceptanceTestDataHelper
    {
        internal static void CreateTestRun(string runId, DateTime startDate, string machineName, EnvironmentVariables environmentVariables)
        {
            using (var connection = new SqlConnection(environmentVariables.DedsDatabaseConnectionString))
            {
                connection.Execute("INSERT INTO AT.TestRuns (RunId,StartDtTm,MachineName) VALUES (@runId,@startDate,@machineName)",
                    new { runId, startDate, machineName });
            }
        }

        internal static void Log(string runId, string scenarioTitle, int level, DateTime date, string message, Exception exception, EnvironmentVariables environmentVariables)
        {
            using (var connection = new SqlConnection(environmentVariables.DedsDatabaseConnectionString))
            {
                connection.Execute("INSERT INTO AT.Logs " +
                                   "(RunId,LogLevel,LogDtTm,LogMessage,ExceptionDetails,ScenarioTitle) " +
                                   "VALUES " +
                                   "(@runId,@level,@date,@message,@exception,@scenarioTitle)",
                    new { runId, level, date, message, exception = exception?.ToString(), scenarioTitle });
            }
        }

        internal static void ClearCollectionPeriodMapping(EnvironmentVariables environmentVariables)
        {
            using (var connection = new SqlConnection(environmentVariables.DedsDatabaseConnectionString))
            {
                connection.Execute("DELETE FROM Collection_Period_Mapping");
            }
        }

        internal static void ClearOldDedsIlrSubmissions(EnvironmentVariables environmentVariables)
        {
            using (var connection = new SqlConnection(environmentVariables.DedsDatabaseConnectionString))
            {
                connection.Execute("DELETE FROM Valid.LearningProvider");
                connection.Execute("DELETE FROM Valid.LearningDelivery");
                connection.Execute("DELETE FROM Valid.LearningDeliveryFAM");
                connection.Execute("DELETE FROM Valid.TrailblazerApprenticeshipFinancialRecord");

                connection.Execute("DELETE FROM Rulebase.AEC_ApprenticeshipPriceEpisode_Period");
                connection.Execute("DELETE FROM Rulebase.AEC_ApprenticeshipPriceEpisode_PeriodisedValues");
                connection.Execute("DELETE FROM Rulebase.AEC_ApprenticeshipPriceEpisode");


                connection.Execute("DELETE FROM dbo.FileDetails");
                connection.Execute("DELETE FROM dbo.DasCommitments");
                connection.Execute("DELETE FROM dbo.DasAccounts");

               
                connection.Execute("DELETE FROM DataLock.ValidationError");

                connection.Execute("DELETE FROM Valid.Learner");
            }
        }

        internal static void AddCurrentActivePeriod(int year, int month, EnvironmentVariables environmentVariables)
        {
            var periodName = "R" + (new DateTime(year, month, 1)).GetPeriodNumber().ToString("00");
            var periodKey = year + month.ToString("00");

            using (var connection = new SqlConnection(environmentVariables.DedsDatabaseConnectionString))
            {
                connection.Execute("UPDATE [Collection_Period_Mapping]  SET Collection_Open=0");

                connection.Execute("DELETE FROM [Collection_Period_Mapping]  WHERE Period=@month AND Calendar_Year=@year", new { month, year });

                connection.Execute("INSERT INTO [Collection_Period_Mapping]" +
                                   "(Period_ID, Collection_Period, Period, Calendar_Year, Collection_Open, ActualsSchemaPeriod)" +
                                   "SELECT ISNULL(MAX(Period_Id), 0) + 1, @periodName, @month, @year, 1, @periodKey FROM [Collection_Period_Mapping]",
                                   new { periodName, month, year, periodKey });
            }
        }
    }
}
