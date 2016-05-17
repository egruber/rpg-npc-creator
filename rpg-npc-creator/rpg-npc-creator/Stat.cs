using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rpg_npc_creator
{
    // Add a stat to the NPC
    [JsonObject(MemberSerialization.OptIn)]
    public class Stat
    {
        [JsonProperty]
        private int Value { get; set; }
        
        [JsonProperty]
        private string Name { get; set; }

        public void Set(int NewValue)
        {
            this.Value = NewValue;
            Console.WriteLine("Stat Value is now: " + Value);
        }

        // Constructors
        public Stat()
        {
            Value = 1;
            Console.WriteLine("New Stat created with value: " + Value);
        }
        public Stat(int IncomingValue)
        {
            Value = IncomingValue;

            Console.WriteLine("New Stat created with value: " + IncomingValue);
        }
    }
    // Add an interface to a stat
    public interface IStat
    {
        int Value { get; set; }
        string Name { get; set; }
    }
}
