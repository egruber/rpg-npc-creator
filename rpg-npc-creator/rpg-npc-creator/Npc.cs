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
        private Stat Statistic { get; set; }
        [JsonProperty]
        private Name NpcName { get; set; }
        [JsonProperty]
        private int Level { get; set; }

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
        }
        public Npc(Stat NewStatValue)
        {
            this.Statistic = NewStatValue;
            this.NpcName = new Name();
        }
        public Npc(Name NewName)
        {
            this.Statistic = new Stat();
            this.NpcName = NewName;
        }
        public Npc(Name NewName, Stat NewStatValue)
        {
            this.Statistic = NewStatValue;
            this.NpcName = NewName;
        }

        // Enter NPC Serialization
        public void Serialization()
        {
            Logger Log = new Logger();
            Log.Info("Serializing NPC");
            string output = JsonConvert.SerializeObject(this);
            Log.Info("Serialization complete.");
        }

        // Set the Level and call the correct number of LevelUps or LevelDowns
        public void SetLevel(int IncomingLevel)
        {
            if(IncomingLevel >= 1 && IncomingLevel <= sizeof(int))
            {
                // So long as the level is sane
                // Set it
                this.Level = IncomingLevel;

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

            }
            else
            {

            }

        }

        // All NPCs start at level 1. They can have their level increased through the LevelUp() method, which can only be called by this class
        // Optionally, multiple level ups can be performed sequentially by passing an integer value to the LevelUp() method
        private void LevelUp(int NumberOfLevels = 1)
        {
            this.Level = this.Level + NumberOfLevels;
        }
        private void LevelDown(int NumberOfLevels = 1)
        {
            this.Level = this.Level - NumberOfLevels;
        }

    }
}
