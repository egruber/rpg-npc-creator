using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_npc_creator
{
    // Using an Abstract Factory design pattern
    public abstract class BuilderNpc
    {
        public virtual void AddName()
        {

        }
        public virtual void AddRace()
        {

        }

        public interface NPC
        {
            name npcName { get; }
            race npcRace { get; }
        }
    }
    
    // Class for Names
    public class name
    {
        private string firstName;
        private string lastName;

        public void setFirstName(string data)
        {
            firstName = data;
        }
        public void setLastName(string data)
        {
            lastName = data;
        }
    }

    // This is an actual NPC, comprised of all the parts put together by the builder
    public class Npc
    {
        private name NpcName;
    }
    public class race
    {
        private enum Races
        { 
            Human, Elf, Dwarf
        };
    }

    class Program
    {
        static void Main(string[] args)
        {
            // So lets call a new NPC
            AbstractNpcFactory factory = null;
            string TypeOfNpc = "nonCombat";

            if(TypeOfNpc == "nonCombat")
            {
                factory = new BuilderNpc();
            }

            // Now create the parts of an NPC
            factory.AddName();
        }
    }
}
