﻿using System;
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
        [TestCase("Inbound Name", ExpectedResult = "Inbound Name")]
        public string CreateNewName(string Name)
        {
            Name NewNpc = new Name(Name);
            string CreatedName = NewNpc.getName();
            return (CreatedName);
        }
        [TestCase(ExpectedResult = "Nameless")]
        public string DefaultNameConstructor()
        {
            Name NewNpc = new Name();
            string CreatedName = NewNpc.getName();
            return (CreatedName);
        }
        [TestCase(ExpectedResult = "Nameless")]
        public string DefaultNameConstructorFromNpcCreation()
        {
            Npc NewNpc = new Npc();
            string CreatedName = NewNpc.NpcName.getName();
            return (CreatedName);
        }
    }
}
