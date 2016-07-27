using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using rpg_npc_creator;

namespace NUnit.Framework.Tests
{
    [TestFixture]

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
        [TestCase(ExpectedResult = "New Stat")]
        public string CreateNewStatWithDefaultName()
        {
            Stat NewStat = new Stat();
            string NewStatName = NewStat.Name;
            return (NewStatName);
        }
        [TestCase(ExpectedResult = "Updated Name")]
        public string CreateNewStatWithSpecifiedName()
        {
            Stat NewStat = new Stat("Updated Name");
            string NewStatName = NewStat.Name;
            return (NewStatName);
        }
        [TestCase(2, ExpectedResult = 2)]
        public int SetStatValue(int NewValue)
        {
            Stat NewStat = new Stat();
            NewStat.Set(NewValue);
            return (NewStat.Value);
        }
        [TestCase(ExpectedResult = 1)]
        public int SetStatWithMaxValue()
        {
            // This should return 1 because MaxInt is too large for this stat thus no Set should occur, so the Default value should be used
            Stat NewStat = new Stat();
            NewStat.Set(Int32.MaxValue);
            return (NewStat.Value);
        }
        [Test]
        public void SetStatWithNegativeValue()
        {
            Stat NewStat = new Stat();
            NewStat.Set(-1);
            Assert.AreEqual(-1, NewStat.Value);
        }
        [Test]
        public void SetStatDoesNotChangeStatValueIfFailsToSet()
        {
            Stat NewStat = new Stat();
            // Set up initial condition
            NewStat.Set(50);
            // Set the stat to MaxInt and it should return the value set at the start
            NewStat.Set(Int32.MaxValue);
            Assert.AreEqual(50, NewStat.Value);
        }
        [Test]
        public void IncreaseWorksOnNegativeValues()
        {
            Stat NewStat = new Stat();
            // Set up initial condition
            NewStat.Set(-1);
            NewStat.Increase();
            Assert.AreEqual(0, NewStat.Value);
        }
        [Test]
        public void DecreaseWorksOnNegativeValues()
        {
            Stat NewStat = new Stat();
            // Set up initial condition
            NewStat.Set(-1);
            NewStat.Decrease();
            Assert.AreEqual(-2, NewStat.Value);
        }
        [Test]
        public void IncreaseByWorksWithNegativeNumbers()
        {
            Stat NewStat = new Stat();
            // Set up initial condition
            NewStat.Set(-1);
            NewStat.IncreaseBy(-1);
            Assert.AreEqual(-2, NewStat.Value);
        }
        [Test]
        public void DecreaseByWorksWithNegativeNumbers()
        {
            Stat NewStat = new Stat();
            // Set up initial condition
            NewStat.Set(-1);
            NewStat.DecreaseBy(-1);
            Assert.AreEqual(0, NewStat.Value);
        }
    }
}