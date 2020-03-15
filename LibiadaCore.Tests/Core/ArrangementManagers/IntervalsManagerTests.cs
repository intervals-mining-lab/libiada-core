namespace LibiadaCore.Tests.Core.ArrangementManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.ArrangementManagers;

    using NUnit.Framework;

    /// <summary>
    /// The congeneric intervals manager test.
    /// </summary>
    [TestFixture]
    public class IntervalsManagerTests
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// The intervals.
        /// </summary>
        private readonly List<Dictionary<Link, List<int>>> allIntervals = ChainsStorage.Intervals;

        /// <summary>
        /// The congeneric intervals manager creation none link test.
        /// </summary>
        /// <param name="index">
        /// Congeneric sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        [TestCase(0, Link.Start)]
        [TestCase(0, Link.End)]
        [TestCase(0, Link.Both)]
        [TestCase(0, Link.Cycle)]
        [TestCase(0, Link.None)]

        [TestCase(1, Link.Start)]
        [TestCase(1, Link.End)]
        [TestCase(1, Link.Both)]
        [TestCase(1, Link.Cycle)]
        [TestCase(1, Link.None)]

        [TestCase(2, Link.Start)]
        [TestCase(2, Link.End)]
        [TestCase(2, Link.Both)]
        [TestCase(2, Link.Cycle)]
        [TestCase(2, Link.None)]

        [TestCase(3, Link.Start)]
        [TestCase(3, Link.End)]
        [TestCase(3, Link.Both)]
        [TestCase(3, Link.Cycle)]
        [TestCase(3, Link.None)]

        [TestCase(4, Link.Start)]
        [TestCase(4, Link.End)]
        [TestCase(4, Link.Both)]
        [TestCase(4, Link.Cycle)]
        [TestCase(4, Link.None)]

        [TestCase(5, Link.Start)]
        [TestCase(5, Link.End)]
        [TestCase(5, Link.Both)]
        [TestCase(5, Link.Cycle)]
        [TestCase(5, Link.None)]
        public void IntervalsManagerCreationNoneLinkTest(int index, Link link)
        {
            var intervalsManager = new IntervalsManager(congenericChains[index]);
            var intervals = allIntervals[index][link];

            Assert.AreEqual(intervalsManager.GetArrangement(link).Length, intervals.Count);

            for (int i = 0; i < intervals.Count; i++)
            {
                Assert.AreEqual(intervals[i], intervalsManager.GetArrangement(link)[i]);
            }
        }
    }
}
