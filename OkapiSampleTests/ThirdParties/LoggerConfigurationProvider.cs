using Okapi.Logs;
using Serilog;

namespace OkapiSampleTests.ThirdParties
{
    internal class LoggerConfigurationProvider : ILoggerConfigurationProvider
    {
        public LoggerConfiguration GetLoggerConfiguration()
        {
            return new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("C://DEV//NET//log.txt");
        }
    }
}