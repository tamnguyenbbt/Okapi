using System;
using Okapi.Logs;
using Serilog;
using SeriLogLogger = Serilog.Core.Logger;

namespace OkapiSampleTests.ProjectConfig
{
    internal class Logger : IOkapiLogger
    {
        private readonly static SeriLogLogger logger = new LoggerConfiguration().WriteTo.File("C:\\DEV\\Tam\\Okapi\\log.txt").CreateLogger();

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