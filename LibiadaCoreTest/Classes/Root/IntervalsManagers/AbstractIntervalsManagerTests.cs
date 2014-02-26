namespace LibiadaCoreTest.Classes.Root.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.IntervalsManagers;

    using NUnit.Framework;

    /// <summary>
    /// The abstract intervals manager test.
    /// </summary>
    public abstract class AbstractIntervalsManagerTests
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
        /// The intervals manager.
        /// </summary>
        private IntervalsManager intervalsManager;

        /// <summary>
        /// The intervals manager test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        protected void IntervalsManagerTest(int index, Link link)
        {
            intervalsManager = new CongenericIntervalsManager(congenericChains[index]);
            var intervals = allIntervals[index][link];
            
            Assert.AreEqual(intervalsManager.GetIntervals(link).Count, intervals.Count);

            for (int i = 0; i < intervals.Count; i++)
            {
                Assert.AreEqual(intervals[i], intervalsManager.GetIntervals(link)[i]);
            }
        }
    }
}