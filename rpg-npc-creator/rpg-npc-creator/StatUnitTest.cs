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
        [TestCase(ExpectedResult = 1)]
        public int CreateNewStatWithoutValue()
        {
            Stat NewStat = new Stat();
            int NewValue = NewStat.Value;
            return (NewValue);
        }
        [TestCase(ExpectedResult = 0)]
        public int CreateNewStatWithMaxValue()
        {
            // This should return an error because MaxInt is too large for this stat
            Stat NewStat = new Stat(Int32.MaxValue);
            int NewValue = NewStat.Value;
            return (NewValue);
        }
        [TestCase(2147483646, ExpectedResult = 2147483646)]
        public int CreateNewStatWithOneUnderMaxValue(int OneMinusMaxInt)
        {
            Stat NewStat = new Stat(OneMinusMaxInt);
            int NewValue = NewStat.Value;
            return (NewValue);
        }
    }
}