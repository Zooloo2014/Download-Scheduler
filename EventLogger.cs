using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NDM
{
    class EventLogger : ILogger
    {
        public EventLogger()
        {
        }


        public void LogMessage(string msg)
        {
            EventLog.WriteEntry("Logger", msg);
        }
    }
}
