using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Serializing objects in Json
using Newtonsoft.Json;

namespace rpg_npc_creator
{

    class Program
    {
        static void Main(string[] args)
        {
            // Call the Logger
            Logger Log = new Logger();

            Npc BlankNpc = new Npc();

            BlankNpc.Serialization();

            foreach (Stat StatInBlock in BlankNpc.StatBlock)
            {
                StatInBlock.SetGrowth(2.0);
            }
            BlankNpc.SetLevel(3);
            BlankNpc.PrintStats();

            // End Program with visible output
            Console.ReadKey();
            
        }
    }
}
