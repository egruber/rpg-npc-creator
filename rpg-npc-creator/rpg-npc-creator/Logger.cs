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
            // TODO: Create a new log file per run/call.

            // Create the true path to the log
            string LogFile = LogFileDirectory + NewFileName;

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
    }
}
