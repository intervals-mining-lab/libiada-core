namespace LibiadaCore.Tests.Core.IntervalsManagers
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using LibiadaCore.Core;
    using LibiadaCore.Core.IntervalsManagers;
    [TestFixture]
    public class CongenericSeriesManagerTests
    {
        private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;
        
        [Test]
        public void SimpleSeriesManagerTest()
        {
            CongenericSeriesManager manager = new CongenericSeriesManager(congenericChains[0]);
            var actual = manager.GetIntervals(Link.NotApplied);
            var expected = new[] { 2, 1 };
            Assert.AreEqual(expected, actual);
        } 
        
    }
}
