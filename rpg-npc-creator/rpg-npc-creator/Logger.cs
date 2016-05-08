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
        private string FileLocation;

        public enum LogLevels
        {
            DEBUG,INFO,WARN,ERROR
        }

        public Logger()
        {
            // Default constructor
            DateTime CurrentDate = new DateTime.Now;
            string NewFileLocation = CurrentDate.ToString("MM, DD, YYYY") + ".log";

            // Check that the directory exists
            string LogFileLocation = Directory.GetCurrentDirectory();
            

            //if (File.Exists("logfiles\\" + NewFileLocation))
            //{
                // Add an iterator and increase it until we end up with a new 


            //}
            //else
            //{

            //}
        }
    }
}
