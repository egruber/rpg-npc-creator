using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rpg_npc_creator
{
    // The Logger class is an object that you can log messages to, and saves out any events that happen with a log level
    class Logger
    {
        private string LogFileLocation;

        public enum LogLevels
        {
            DEBUG,INFO,WARN,ERROR
        }

        public Logger()
        {
            // Default constructor
            string CurrentDate = DateTime.Now.ToString("mmddyyyy");
            string NewFileName = CurrentDate + ".log";


            // Check that the directory exists
            string ApplicationLocation = Directory.GetCurrentDirectory();
            string LogFileDirectory = ApplicationLocation+"\\logfiles\\";

            if(!Directory.Exists(LogFileDirectory))
            {
                // Create Log file directory if it doesn't exist
                Directory.CreateDirectory(LogFileDirectory);
            }

            // In this first pass, I'm not going to create unique log files per each instance.
            // TODO: Create a new log file per call.

            // Create the true path to the log
            string LogFile = LogFileDirectory + NewFileName;

            // Since we know the true path, assign it to the private location 
            LogFileLocation = LogFile;

            // Create the file
            // TODO Create the file without overwriting the previous contents
            try
            {
                using (File.Create(LogFile)) { };
            }
            catch
            {
                Console.WriteLine("Caught errors");
            }

        }
        
        // Write to the log without a log level
        private void Write(Object LogItem)
        {
            // Verify the logfile exists before doing anything
            if (File.Exists(LogFileLocation) == false)
            {
                Console.WriteLine("LogFile has not been created.");
            }

            // Any log information passed without a loglevel defaults to info
            // Write the string version of the LogItem to the file
            using (StreamWriter LogMessage = File.AppendText(LogFileLocation))
            {
                string OutputLogMessage = "["+LogLevels.INFO+"] "+DateTime.Now+" "+LogItem.ToString();

                LogMessage.WriteLine(OutputLogMessage);

            }
        }
        
        // Write a log message with a specific log level
        private void Write(Object LogItem, LogLevels LogLevel)
        {
            // Verify the logfile exists before doing anything
            if (File.Exists(LogFileLocation) == false)
            {
                Console.WriteLine("LogFile has not been created.");
            }

            // Write the string version of the LogItem to the file
            using (StreamWriter LogMessage = File.AppendText(LogFileLocation))
            {
                string OutputLogMessage = "[" + LogLevel + "] " + DateTime.Now + " " + LogItem.ToString();

                LogMessage.WriteLine(OutputLogMessage);

            }
        }

        // Avoid writing without a log level by only exposing the log-level'd write methods
        public void Warn(Object LogItem)
        {
            this.Write(LogItem, LogLevels.WARN);
        }
        public void Debug(Object LogItem)
        {
            this.Write(LogItem, LogLevels.DEBUG);
        }
        public void Info(Object LogItem)
        {
            this.Write(LogItem, LogLevels.INFO);
        }
        public void Error(Object LogItem)
        {
            this.Write(LogItem, LogLevels.ERROR);
        }

    }
}
