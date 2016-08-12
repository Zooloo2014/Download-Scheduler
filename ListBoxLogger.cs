using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDM
{
    class ListBoxLogger : ILogger
    {
        ListBox listBox;

        
        public ListBoxLogger(ListBox listBox)
        {
            this.listBox = listBox;
        }


        public void LogMessage(string msg)
        {
            MethodInvoker logDelegate = delegate
            {
                listBox.Items.Add(String.Format("{0:yyyy-MM-dd} {0:hh:mm:ss tt} - ", DateTime.Now) + msg);
            };

            if (listBox.InvokeRequired)
                listBox.Invoke(logDelegate);
            else
                logDelegate();
        }
    }
}
