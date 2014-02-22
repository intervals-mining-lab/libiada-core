namespace LibiadaCoreTest.Classes.Root.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.IntervalsManagers;

    using NUnit.Framework;

    public abstract  class AbstractIntervalsManagerTest
    {
        protected List<CongenericChain> CongenericChains = ChainsStorage.CongenericChains;
        protected IntervalsManager IntervalsManager;
        protected List<Dictionary<Link, List<int>>> Intervals = ChainsStorage.Intervals;

        public void IntervalsManagerTest(int index, Link link)
        {
            IntervalsManager = new CongenericIntervalsManager(CongenericChains[index]);
            var intervals = Intervals[index][link];
            
            Assert.AreEqual(IntervalsManager.GetIntervals(link).Count, intervals.Count);

            for (int i = 0; i < intervals.Count; i++)
            {
                Assert.AreEqual(intervals[i], IntervalsManager.GetIntervals(link)[i]);
            }
        }
    }
}