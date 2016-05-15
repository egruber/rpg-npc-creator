using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_npc_creator
{
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
