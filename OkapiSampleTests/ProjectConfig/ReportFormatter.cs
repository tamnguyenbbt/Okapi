using System;
using System.IO;
using System.Text;
using Okapi.Extensions;
using Okapi.Report;
using Okapi.TestUtils;
using Serilog;
using SeriLogLogger = Serilog.Core.Logger;

namespace OkapiSampleTests.ProjectConfig
{
    internal class ReportFormatter : IReportFormatter
    {
        private readonly static SeriLogLogger logger = new LoggerConfiguration()
            .WriteTo
            .File($"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Report_{DateTime.Now.GetTimestamp()}.txt").CreateLogger();

        public void Run(ReportData data)
        {
            StringBuilder reportStringBuilder = new StringBuilder();
            reportStringBuilder.Append($"TEST CASE: {data.TestMethod.Name}");

            reportStringBuilder.Append($"{Environment.NewLine}");
            reportStringBuilder.Append("\t");
            reportStringBuilder.Append($"RESULT: {data.TestResult}");

            if (data.DurationInSeconds != -1)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"DURATION: {data.DurationInSeconds} seconds");
            }

            if (data.StartDateTime != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"START TIME: {data.StartDateTime}");
            }

            reportStringBuilder.Append($"{Environment.NewLine}");
            reportStringBuilder.Append("\t");
            reportStringBuilder.Append($"END TIME: {data.EndDateTime}");

            if (data.AdditionalData.HasAny())
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"ADDITIONAL DATA: {data.AdditionalData.ConvertToString()}");
            }

            if (data.FailDetails != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"FAIL INFO: {data.FailDetails}");
            }

            if (data.Exception != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"EXCEPTION: {data.Exception}");
            }

            if (data.TestResult.Equals(TestResult.PASS))
            {
                logger.Information(reportStringBuilder.ToString());
            }
            else
            {
                logger.Error(reportStringBuilder.ToString());
            }
        }
    }
}