using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rpg_npc_creator
{
    // TODO Support Logger as a client to this class so all the interactions with the objects in this class are handled better than console output
    // Add a stat to the NPC
    [JsonObject(MemberSerialization.OptIn)]
    public class Stat
    {
        [JsonProperty]
        private int Value { get; set; }
        
        [JsonProperty]
        private string Name { get; set; }

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
        public Stat(int IncomingValue, string IncomingName)
        {
            Value = IncomingValue;
            Name = IncomingName;

            Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
        }

        // Set
        public void Set(int IncomingValue)
        {
            this.Value = IncomingValue;
        }
        public void Set(int IncomingValue, string IncomingName)
        {
            this.Value = IncomingValue;
            this.Name = IncomingName;
        }

    }
}
