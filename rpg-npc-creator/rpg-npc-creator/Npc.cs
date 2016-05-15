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

    }
    // Add a way to interface with the NPC 
    public interface INpc
    {
        Stat Statistic { get; set; }
        Name NpcName { get; set; }
    }
}
