using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using rpg_npc_creator;

namespace NUnit.Framework.Tests
{
    class NameUnitTests
    {
        [TestCase("NewName", ExpectedResult = "NewName")]
        public string CreateNewName(string Name)
        {
            Name NewNpc = new Name(Name);
            string CreatedName = NewNpc.getName();
            return (CreatedName);
        }
    }
}
