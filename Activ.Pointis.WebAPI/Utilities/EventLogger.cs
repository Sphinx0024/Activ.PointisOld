using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Utilities
{
    public class EventLogger
    {
        private static EventLog eventLog = null;
        private static EventLogger instance = null;
        private static readonly object padlock = new object();

        public EventLogger()
        {
        }

        public static EventLogger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EventLogger();
                        eventLog = instance.InitLog();
                    }
                    return instance;
                }
            }
        }

        private EventLog InitLog()
        {
            eventLog = new EventLog();
            //if (!System.Diagnostics.EventLog.SourceExists("ActivFidelisSync"))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource("ActivFidelisSync", "ActivFidelisSync_Log");
            //}
            //eventLog.Source = "ActivFidelisSync";
            //eventLog.Log = "ActivFidelisSync_Log";
            return eventLog;
        }

        public void WriteLog(string _Log, bool _WriteInFile = false)
        {
            //eventLog.WriteEntry(_Log);
            if (_WriteInFile == true) { WriteLogToFile(_Log); }
        }

        public void WriteLogToFile(string _Log)
        {
            _Log = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " :: " + _Log;
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath = path + "\\ActivFidelisSyncLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".log";

            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(_Log);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath)) { sw.WriteLine(_Log); }
            }

        }
    }
}