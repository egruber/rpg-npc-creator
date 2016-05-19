using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rpg_npc_creator
{
    // Add a name to the NPCs
    [JsonObject(MemberSerialization.OptIn)]
    public class Name
    {
        [JsonProperty]
        string NpcName { get; set; }

        public void Set(string Name)
        {
            this.NpcName = Name;
            Console.WriteLine("Name is now: " + Name);
        }
        public Name()
        {
            NpcName = "Nameless";
            Console.WriteLine("New nameless NPC created");
        }
        public Name(string IncomingName)
        {
            NpcName = IncomingName;
            Console.WriteLine("New NPC created with name: " + IncomingName);
        }
        public void Serialization()
        {
            Logger Log = new Logger();
            Log.Info("Serializing NPC");
            string output = JsonConvert.SerializeObject(this);
            Log.Info("Serialization complete.");
        }
    }
}
