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

            Console.WriteLine("Creating a new NPC");
            var NewName = new Name();
            NewName.Set("Words");
            var NewStatValue = new Stat();

            NewStatValue.Set(1,"Strength");

            var NewNpc = new Npc(NewName,NewStatValue);
            Npc BlankNpc = new Npc();

            string serializedNpc = JsonConvert.SerializeObject(BlankNpc);
            Console.WriteLine(serializedNpc);

            string serializedStat = JsonConvert.SerializeObject(NewStatValue);
            Console.WriteLine(serializedStat);

            // End Program with visible output
            Console.ReadKey();
            
        }
    }
}
