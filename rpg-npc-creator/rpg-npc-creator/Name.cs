using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_npc_creator
{
    // Add a name to the NPCs
    public class Name
    {
        string NpcName;

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
    }
    // Create an interface to the Name
    public interface IName
    {
        string NpcName { get; }
    }
}
