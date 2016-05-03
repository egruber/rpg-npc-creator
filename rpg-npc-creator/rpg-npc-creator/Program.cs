using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_npc_creator
{
    // Using an Abstract Factory design pattern
    public abstract class AbstractNpcFactory
    {
        public abstract stat AddStats();
        public abstract name AddName();
        public abstract backStory GenerateBackstory();
    }
    // Non-combat NPCs have different attributes than Combat NPCs
    public class NonCombatNpcFactory: AbstractNpcFactory
    {
        public override stat AddStats()
        {
            throw new NotImplementedException();
        }
        public override name AddName()
        {
            throw new NotImplementedException();
        }
        public override backStory GenerateBackstory()
        {
            throw new NotImplementedException();
        }

    }

    // Combat NPCs are created with a different set of attributes
    public class CombatNpcFactory : AbstractNpcFactory
    {
        public override name AddName()
        {
            throw new NotImplementedException();
        }

        public override stat AddStats()
        {
            throw new NotImplementedException();
        }

        public override backStory GenerateBackstory()
        {
            throw new NotImplementedException();
        }
    }
    
    // Stat Class
    public class stat
    {
        private string name;
        private int value;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }

    // Class for Names
    public class name
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
    }

    // Class for Backstory
    public class backStory
    {
        private Npc[] familyMembers;
        private string homeTown;
        private DateTime birthday;

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string HomeTown
        {
            get
            {
                return homeTown;
            }

            set
            {
                homeTown = value;
            }
        }

        public Npc[] FamilyMembers
        {
            get
            {
                return familyMembers;
            }

            set
            {
                familyMembers = value;
            }
        }
    }
       
    // This is an actual NPC, comprised of all the parts put together by the builder
    public class Npc
    {
        private name NpcName;
        private backStory NpcBackStory;
        private stat[] NpcStats;
        
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
                factory = new CombatNpcFactory();
            }
            else
            {
                factory = new NonCombatNpcFactory();
            }

            // Now create the parts of an NPC
            factory.AddName();
            factory.AddStats();
            factory.GenerateBackstory();
        }
    }
}
