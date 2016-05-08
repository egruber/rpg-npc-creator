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
            string CurrentDate = DateTime.Now.ToString("mmddyyyy");
            string NewFileLocation = CurrentDate + ".log";

            // Check that the directory exists
            string ApplicationLocation = Directory.GetCurrentDirectory();

            Console.WriteLine("Current Directory: " + ApplicationLocation);
            //string ListOfDirectories = Directory.GetDirectories(ApplicationLocation);





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
