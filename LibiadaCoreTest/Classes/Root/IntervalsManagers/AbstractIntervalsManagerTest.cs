namespace LibiadaCoreTest.Classes.Root.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.IntervalsManagers;

    using NUnit.Framework;

    /// <summary>
    /// The abstract intervals manager test.
    /// </summary>
    public abstract class AbstractIntervalsManagerTest
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
            this.intervalsManager = new CongenericIntervalsManager(this.congenericChains[index]);
            var intervals = this.allIntervals[index][link];
            
            Assert.AreEqual(this.intervalsManager.GetIntervals(link).Count, intervals.Count);

            for (int i = 0; i < intervals.Count; i++)
            {
                Assert.AreEqual(intervals[i], this.intervalsManager.GetIntervals(link)[i]);
            }
        }
    }
}