using System;
using Okapi.Logs;
using Serilog;
using Serilog.Core;

namespace OkapiSampleTests.ThirdParties
{
    internal class OkapiLogger : IOkapiLogger
    {
        private readonly static Logger logger = new LoggerConfiguration().WriteTo.File("C:\\DEV\\Tam\\Okapi\\log.txt").CreateLogger();

        public void Error(string messageTemplate)
        {
            logger.Error(messageTemplate);
        }

        public void Error(string messageTemplate, Exception exception)
        {
            logger.Error(exception, messageTemplate);
        }

        public void Info(string messageTemplate)
        {
            logger.Information(messageTemplate);
        }
    }
}