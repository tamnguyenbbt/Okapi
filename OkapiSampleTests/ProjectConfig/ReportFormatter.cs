using System.IO;
using Okapi.Report;
using Okapi.TestUtils;
using Serilog;
using SeriLogLogger = Serilog.Core.Logger;

namespace OkapiSampleTests.ProjectConfig
{
    internal class ReportFormatter : IReportFormatter
    {
        private readonly static SeriLogLogger logger = new LoggerConfiguration().WriteTo.File($"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}report.txt").CreateLogger();

        public void Run(ReportData data)
        {
            string result = $"{data.TestMethod.Name} --> {data.TestResult}";
            logger.Information(result);
        }
    }
}