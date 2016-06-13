using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

namespace rpg_npc_creator
{
    // TODO Support Logger as a client to this class so all the interactions with the objects in this class are handled better than console output
    // Add a stat to the NPC
    [JsonObject(MemberSerialization.OptIn)]
    public class Stat
    {
        [JsonProperty]
        public int Value { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        private double Growth { get; set; }

        // Constructors
        public Stat()
        {
            Value = 1;
            Name = "New Stat";
            Growth = 1.0;
            Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
        }
        public Stat(int IncomingValue)
        {
            if (IncomingValue >= Int32.MaxValue)
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
                this.Name = "New Stat";
                this.Growth = 1.0;
                Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
            }

        }
        public Stat(string IncomingName)
        {
            this.Value = 1;
            this.Name = IncomingName;
            this.Growth = 1.0;
            Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
        }
        public Stat(int IncomingValue, string IncomingName)
        {
            if (IncomingValue >= Int32.MaxValue)
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
                Name = IncomingName;
                this.Growth = 1.0;
                Console.WriteLine("New stat " + Name + " created with value " + Value + ".");
            }

        }

        // Set
        public void Set(int IncomingValue)
        {
            if(IncomingValue >= Int32.MaxValue)
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
            if (IncomingValue >= Int32.MaxValue)
            {
                Console.WriteLine("This value: " + IncomingValue + " is too large to set to this stat");
            }
            else
            {
                this.Value = IncomingValue;
            }
            this.Name = IncomingName;
        }

        // Use a slightly different naming convention for Growth setting since it's a characteristic of the Stat
        // Note the Growth CAN be negative values.
        public void SetGrowth(double IncomingGrowth)
        {
            if (IncomingGrowth >= sizeof(double))
            {
                Console.WriteLine("This value: " + IncomingGrowth + " is too large.");
            }
            else
            {
                this.Growth = IncomingGrowth;
            }
        }
        // Increase Stat Value
        public void IncreaseBy(int ValueToIncreaseBy)
        {
            if(ValueToIncreaseBy+this.Value >= Int32.MaxValue)
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
            if (this.Value++ >= Int32.MaxValue)
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
            if (Math.Abs(ValueToDecreaseBy + this.Value) >= Int32.MaxValue)
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
            if (Math.Abs(this.Value--) >= Int32.MaxValue)
            {
                Console.WriteLine("This value: " + this.Value + " is too large to decrease by 1");
            }
            else
            {
                this.Value++;
            }
        }

        // Stat Serialization
        public void Serialization()
        {
            Logger Log = new Logger();
            Log.Info("Serializing Stat");
            string output = JsonConvert.SerializeObject(this);
            Log.Info("Serialization complete.");
        }

        // Stat growth is dependent on a growth value.  
        // This method is called during a level up to apply a stat growth to a stat
        public void Grow()
        {
            // A stat growth is representative of a chance to increase a stat at level up
            // How a stat actually is increased:
            //
            // Multiple Stat Growth by 100
            // Take a random integer up to the truncated size of the stat growth
            // Any value over 50 will net an increase in the stat
            // Subtract 50 from multiplied stat growth
            // Repeat until multiplied stat growth is less than 50.

            // First, multiple the stat growth by 100
            double ScaledStatGrowth = this.Growth * 100;
            int ConvertedGrowth = 0;
            int GrowResult = 0;

            try
            {
                ConvertedGrowth = Convert.ToInt32(ScaledStatGrowth);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Resulting growth exceeded size of int. Capping at sizeof Int32 for growth.");
                ConvertedGrowth = Int32.MaxValue;
            }

            // Only continue while the converted growth is over or equal to 50
            while(ConvertedGrowth >= 25)
            {
                GrowResult = RandomNumber(0, ConvertedGrowth);
                if(GrowResult >= 25)
                {
                    this.Increase();
                }
                else
                {
                    break;
                }
                ConvertedGrowth = ConvertedGrowth - GrowResult;
            }

        }

        // Function to get random number. 
        // Pulled from: http://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
        // It's really annoying how the standard C# random number generator works. 
        // This is now generating good, clean, random values on the growth

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
