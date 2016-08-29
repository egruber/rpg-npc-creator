using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rpg_npc_creator
{
    // Add a concrete NPC for us to actually build
    [JsonObject(MemberSerialization.OptIn)]
    public class Npc
    {
        [JsonProperty]
        public List<Stat> StatBlock { get; set; }
        [JsonProperty]
        public Name NpcName { get; set; }
        [JsonProperty]
        public int Level { get; set; }
        // TODO: Refactor "Height" into a "Characteristics" hash
        [JsonProperty]
        public int Height { get; set; }

        public void Set(Name NewName)
        {
            this.NpcName = NewName;
            this.GenerateStats();
        }

        // Constructors
        public Npc()
        {
            this.GenerateStats();
            this.NpcName = new Name();
            this.Level = 1;
            this.Height = 1;
        }
        public Npc(Name NewName)
        {
            this.NpcName = NewName;
            this.GenerateStats();
            this.Level = 1;
            this.Height = 1;
        }
        // NPC Serialization
        public void Serialization()
        {
            Logger Log = new Logger();
            Log.Info("Serializing NPC");
            string output = JsonConvert.SerializeObject(this);
            Log.Info("Serialization complete.");
            Log.Info(output);
        }

        // Set the Level and call the correct number of LevelUps or LevelDowns
        public void SetLevel(int IncomingLevel)
        {
            if(IncomingLevel >= 1 && IncomingLevel <= Int32.MaxValue)
            {
                // If the Level we are going to is larger than the current level of the NPC
                if (IncomingLevel > this.Level)
                {
                    // Level up while the the iterator is smaller than the target level 
                    for (int i = this.Level; i < IncomingLevel; i++)
                    {
                        // Level up 
                        this.LevelUp();
                    }
                }
                // If the Level the NPC is going to is less than the current level
                else if(IncomingLevel < this.Level )
                {
                    // Level Down while the iterator is larger than the target level
                    for (int i = this.Level; i > IncomingLevel; i--)
                    {
                        this.LevelDown();
                    }
                }
                else
                {
                    // Do nothing because the level is the same 

                }

                // So long as the level is sane
                // Set it
                this.Level = IncomingLevel;
            }
            else
            {
                Console.WriteLine("Invalid Level: "+IncomingLevel);
            }

        }

        // All NPCs start at level 1. They can have their level increased through the LevelUp() method, which can only be called by this class
        // Optionally, multiple level ups can be performed sequentially by passing an integer value to the LevelUp() method
        private void LevelUp(int NumberOfLevels = 1)
        {
            this.Level = this.Level + NumberOfLevels;
            foreach(Stat LevelUpStat in StatBlock)
            {
                Console.WriteLine("Calling Grow on: "+LevelUpStat.Name);
                LevelUpStat.Grow();
            }
        }
        private void LevelDown(int NumberOfLevels = 1)
        {
            this.Level = this.Level - NumberOfLevels;
        }

        // Method for generating a stat block
        private void GenerateStats()
        {
            // Create the List
            this.StatBlock = new List<Stat>();
            this.StatBlock.Add(new Stat("Strength"));
            this.StatBlock.Add(new Stat("Dexterity"));
            this.StatBlock.Add(new Stat("Constitution"));
            this.StatBlock.Add(new Stat("Intelligence"));
            this.StatBlock.Add(new Stat("Wisdom"));
            this.StatBlock.Add(new Stat("Charisma"));
        }
        public void PrintStats()
        {
            foreach (Stat CurrentStat in StatBlock)
            {
                Console.WriteLine(CurrentStat.Name + ": "+CurrentStat.Value);
            }
        }

    }
}
