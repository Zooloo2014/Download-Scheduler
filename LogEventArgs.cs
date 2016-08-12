using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDM
{
    public class LogEventArgs : EventArgs
    {
        public string Text { get; private set; }
        
        
        public LogEventArgs(string s)
        {
            Text = s;
        }
    }
}
