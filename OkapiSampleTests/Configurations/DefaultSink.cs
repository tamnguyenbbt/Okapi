using System;
using Serilog.Core;
using Serilog.Events;

namespace OkapiTests
{
    class DefaultSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
