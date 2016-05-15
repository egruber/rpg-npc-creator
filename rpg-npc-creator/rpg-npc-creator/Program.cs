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
            Console.WriteLine("Creating a new NPC");
            var NewName = new Name();
            NewName.Set("Words");
            var NewStatValue = new Stat();
            NewStatValue.Set(2);

            var NewNpc = new Npc(NewName,NewStatValue);

            string serializedNpc = JsonConvert.SerializeObject(NewStatValue);
            Console.WriteLine(serializedNpc);

            // Call the Logger
            Logger Log = new Logger();
            Console.ReadKey();
            
        }
    }
}
