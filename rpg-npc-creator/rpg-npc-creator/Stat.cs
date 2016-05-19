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
            Name = "New Stat";
            Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
        }
        public Stat(int IncomingValue)
        {
            if (IncomingValue >= sizeof(int))
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
                this.Name = "New Stat";
                Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
            }

        }
        public Stat(string IncomingName)
        {
            this.Value = 1;
            this.Name = IncomingName;
            Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
        }
        public Stat(int IncomingValue, string IncomingName)
        {
            if (IncomingValue >= sizeof(int))
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
                Name = IncomingName;
                Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
            }

        }

        // Set
        public void Set(int IncomingValue)
        {
            if(IncomingValue >= sizeof(int))
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
            }
            
        }
        public void Set(int IncomingValue, string IncomingName)
        {
            if (IncomingValue >= sizeof(int))
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
            }
            this.Name = IncomingName;
        }

        // Increase Stat Value
        public void IncreaseBy(int ValueToIncreaseBy)
        {
            if(ValueToIncreaseBy+this.Value >= sizeof(int))
            {
                Console.WriteLine("This value: "+ValueToIncreaseBy+ " is too large to add to this stat value: "+this.Value);
            }
            else
            {
                this.Value = Value + ValueToIncreaseBy;
            }
            
        }
        public void Increase()
        {
            if (this.Value++ >= sizeof(int))
            {
                Console.WriteLine("This value: " + this.Value + " is too large to increase by 1");
            }
            else
            {
                this.Value++;
            }
        }

        // Decrease Stat Value
        public void DecreaseBy(int ValueToDecreaseBy)
        {
            if (Math.Abs(ValueToDecreaseBy + this.Value) >= sizeof(int))
            {
                Console.WriteLine("This value: " + ValueToDecreaseBy + " is too large to subtract from this stat value: " + this.Value);
            }
            else
            {
                this.Value = Value + ValueToDecreaseBy;
            }

        }
        public void Decrease()
        {
            if (Math.Abs(this.Value--) >= sizeof(int))
            {
                Console.WriteLine("This value: " + this.Value + " is too large to decrease by 1");
            }
            else
            {
                this.Value++;
            }
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
