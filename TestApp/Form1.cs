using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NDM
{
    public partial class MainForm : Form
    {
        private AppSettings settings;
        private TCPServer server;
        private ListBoxLogger log;
        private Scheduler scheduler;


        public MainForm()
        {
            InitializeComponent();

            settings = new RegistryAppSettings("NDM");
            settings.DefaultDirectory = @"C:\Users\bengelbr\Downloads";

            log = new ListBoxLogger(listLog);
            log.LogMessage("Application started");

            server = new TCPServer((uint)Convert.ToInt32(textPort.Text));
            server.OnLog += ServerLog;

            log.LogMessage("Bind to port " + textPort.Text + " on localhost [" + getLocalIP() + "]");

            scheduler = Scheduler.Instance;
            scheduler.OnLog += ScheduleLog;
            scheduler.DownloadDir = @"C:\Users\bengelbr\Downloads";
            scheduler.Start();
            log.LogMessage("Scheduler started");
        }


        /// <summary>
        /// Determine localhost's IP address
        /// </summary>
        private string getLocalIP()
        {
            string r = "127.0.0.1";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    r = ip.ToString();
            }

            return r;
        }


        /// <summary>
        /// Event Handler for log messages from TCPServer and TCPServerClient
        /// </summary>
        public void ServerLog(TCPServer t, LogEventArgs e)
        {
            log.LogMessage(e.Text);
        }


        /// <summary>
        /// Event Handler for log messages from Scheduler
        /// </summary>
        public void ScheduleLog(Scheduler t, LogEventArgs e)
        {
            log.LogMessage(e.Text);
        }


        private void bntExit_Click(object sender, EventArgs e)
        {
            log.LogMessage("Application ended");
            Close();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            log.LogMessage("Start listener");
            server.Start();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            log.LogMessage("Stop listener");
            server.Stop();
        }
    }
}
