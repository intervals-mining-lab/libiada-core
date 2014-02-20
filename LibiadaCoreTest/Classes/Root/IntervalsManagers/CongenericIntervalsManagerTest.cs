using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.IntervalsManagers;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCoreTest.Classes.Root.IntervalsManagers
{
    using NUnit.Framework;

    [TestFixture]
    class CongenericIntervalsManagerTest
    {
        private CongenericChain chain;

        [SetUp]
        public void SetUp()
        {
            chain = new CongenericChain(15, new ValueChar('a'));
            chain.Add(new ValueChar('a'), 3);
            chain.Add(new ValueChar('a'), 5);
            chain.Add(new ValueChar('a'), 6);
            chain.Add(new ValueChar('a'), 11);
        }

        [Test]
        public void CongenericIntervalsManagerCreationNoneLinkTest()
        {
            CongenericIntervalsManager manager = new CongenericIntervalsManager(chain);
            List<int> actual = manager.GetIntervals(Link.None);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(2, actual[0]);
            Assert.AreEqual(1, actual[1]);
            Assert.AreEqual(5, actual[2]);
        }

        [Test]
        public void CongenericIntervalsManagerCreationStartLinkTest()
        {
            CongenericIntervalsManager manager = new CongenericIntervalsManager(chain);
            List<int> actual = manager.GetIntervals(Link.Start);

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(3, actual[0]);
            Assert.AreEqual(2, actual[1]);
            Assert.AreEqual(1, actual[2]);
            Assert.AreEqual(5, actual[3]);
        }

        [Test]
        public void CongenericIntervalsManagerCreationEndLinkTest()
        {
            CongenericIntervalsManager manager = new CongenericIntervalsManager(chain);
            List<int> actual = manager.GetIntervals(Link.End);

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(2, actual[0]);
            Assert.AreEqual(1, actual[1]);
            Assert.AreEqual(5, actual[2]);
            Assert.AreEqual(4, actual[3]);
        }

        [Test]
        public void CongenericIntervalsManagerCreationBothLinkTest()
        {
            CongenericIntervalsManager manager = new CongenericIntervalsManager(chain);
            List<int> actual = manager.GetIntervals(Link.Both);

            Assert.AreEqual(5, actual.Count);
            Assert.AreEqual(3, actual[0]);
            Assert.AreEqual(2, actual[1]);
            Assert.AreEqual(1, actual[2]);
            Assert.AreEqual(5, actual[3]);
            Assert.AreEqual(4, actual[4]);
        }

        [Test]
        public void CongenericIntervalsManagerCreationCycleLinkTest()
        {
            CongenericIntervalsManager manager = new CongenericIntervalsManager(chain);
            List<int> actual = manager.GetIntervals(Link.Cycle);

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(2, actual[0]);
            Assert.AreEqual(1, actual[1]);
            Assert.AreEqual(5, actual[2]);
            Assert.AreEqual(7, actual[3]);
        }
    }
}
