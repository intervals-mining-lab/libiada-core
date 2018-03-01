namespace LibiadaCore.Tests.Core.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.IntervalsManagers;

    using NUnit.Framework;

    /// <summary>
    /// The congeneric series manager tests.
    /// </summary>
    [TestFixture]
    public class CongenericSeriesManagerTests
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// The simple series manager test 01.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest01()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[0]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 2, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 02.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest02()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[1]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 2, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 03.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest03()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[2]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 04.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest04()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[3]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 05.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest05()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[4]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// The simple series manager test 06.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest06()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[5]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 5, 4, 3, 2, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 07.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest07()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[6]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 08.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest08()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[7]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 09.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest09()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[8]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 10.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest10()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[9]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 11.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest11()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[10]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 12.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest12()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[11]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 2, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 13.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest13()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[12]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 14.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest14()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[13]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 2, 1, 1, 2, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 15.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest15()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[14]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 16.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest16()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[15]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 17.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest17()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[16]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The simple series manager test 18.
        /// </summary>
        [Test]
        public void SimpleSeriesManagerTest18()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[17]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 1, 1, 1, 1 };
            Assert.AreEqual(expected, actual);
        }
    }
}
