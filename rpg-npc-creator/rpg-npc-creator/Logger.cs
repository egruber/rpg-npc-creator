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
            string NewFileLocation = DateTime.Now.ToString();

            if (File.Exists("logfiles\\" + NewFileLocation))
            {
                // Recurisvely create new log files until one does not already exist

            }
            else
            {

            }
        }
    }
}
