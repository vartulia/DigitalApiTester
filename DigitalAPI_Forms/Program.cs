using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DigitalAPI_Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger log = new Logger(@"");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new DigitalAPItester());
            }
            catch (WebException error)
            {
                log.LogError("General Error: " + error.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception e)
            {
                log.LogError("General Error: " + e.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
    
