using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using rpg_npc_creator;

namespace NUnit.Framework.Tests
{
    class StatUnitTest
    {
        [TestCase(1, ExpectedResult = 1)]
        public int CreateNewStatWithValue(int IncomingValue)
        {
            Stat NewStat = new Stat(IncomingValue);
            int NewValue = NewStat.Value;
            return (NewValue);
        }
    }
}
