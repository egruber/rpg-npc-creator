using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_npc_creator
{
    // Add a concrete NPC for us to actually build
    public class Npc
    {
        private Stat Statistic;
        private Name NpcName;

        public void Set(Stat NewStatValue, Name NewName)
        {
            this.Statistic = NewStatValue;
            this.NpcName = NewName;
        }
        public void Set(Stat NewStatValue)
        {
            this.Statistic = NewStatValue;
            this.NpcName = new Name();
        }
        public void Set(Name NewName)
        {
            this.NpcName = NewName;
            this.Statistic = new Stat();
        }

        // Constructors
        public Npc()
        {
            this.Statistic = new Stat();
            this.NpcName = new Name();
            Console.WriteLine("New NPC created with default parameters");
        }
        public Npc(Stat NewStatValue)
        {
            this.Statistic = NewStatValue;
            this.NpcName = new Name();
            Console.WriteLine("New nameless NPC created");
        }
        public Npc(Name NewName)
        {
            this.Statistic = new Stat();
            this.NpcName = NewName;
            Console.WriteLine("New statless NPC created");
        }
        public Npc(Name NewName, Stat NewStatValue)
        {
            this.Statistic = NewStatValue;
            this.NpcName = NewName;
            Console.WriteLine("New NPC created!");
        }

    }
    // Add a way to interface with the NPC 
    public interface INpc
    {
        Stat Statistic { get; }
        Name NpcName { get; }
    }
    // Add a stat to the NPC
    public class Stat
    {
        int Value;

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
        int Value { get; }
    }
}
