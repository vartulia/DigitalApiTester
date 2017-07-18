﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace DigitalAPI_Forms
{
    class Logger
    {

        string _logPath = string.Empty;
        const string _fName = "DigitalAPI.log";
        string _fileName = string.Empty;
        static System.Threading.Semaphore locking = new System.Threading.Semaphore(1, 1);
        string fullFileName = string.Empty;

        public Logger(string logPath)
        {
            _logPath = logPath;
        }

        public Logger(string logPath, string fileName)
        {
            _logPath = logPath;
            _fileName = fileName;
        }

        public void LogError(string logInformation, EventLogEntryType errorType)
        {
            if (string.IsNullOrEmpty(logInformation)) return;
            if (_fileName.Equals(string.Empty))
                fullFileName = _logPath + _fName;
            else
                fullFileName = _logPath + _fileName;
            StringBuilder errorInfo = new StringBuilder();

            //detete log file if greater than 1MB
            if (File.Exists(fullFileName) == true)
            {
                FileInfo into = new FileInfo(fullFileName);
                long aa = into.Length;
                if (aa >= (1024 * 1024))
                {
                    File.Delete(fullFileName);
                }
            }

            if (errorInfo.Length > 0) errorInfo.Remove(0, errorInfo.Length);
            errorInfo.Append(DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff tt ") + String.Format("{0,12}", errorType.ToString()) + " : ");
            errorInfo.Append(" " + logInformation);
            try
            {
                locking.WaitOne();
                StreamWriter Txt = null;
                if (File.Exists(fullFileName) == false)
                {
                    Txt = File.CreateText(fullFileName);
                }
                else
                {
                    Txt = File.AppendText(fullFileName);
                }
                Txt.WriteLine(errorInfo.ToString());
                Txt.Close();

            }

            catch (Exception e)
            {
                Console.WriteLine("Exception raised. " + e.Message.ToString());
            }

            finally
            {
                locking.Release();
            }

        }

    }

}
