namespace LibiadaCore.Tests.Misc.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    using NUnit.Framework;

    /// <summary>
    /// The iterator end test.
    /// </summary>
    [TestFixture]
    public class IteratorEndTests
    {
        /// <summary>
        /// The chain to iterate.
        /// </summary>
        private Chain chainToIterate;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            chainToIterate = new Chain("121331212231");
        }

        /// <summary>
        /// The read window mode test.
        /// </summary>
        [Test]
        public void ReadWindowModeTest()
        {
            int length = 3;
            int step = 1;
            var iterator = new IteratorEnd(chainToIterate, length, step);

            // 12 - 3 + 1
            var message2 = new List<Chain>
                { 
                    // 121331212|231|
                    new Chain("231"),

                    // 12133121|223|1
                    new Chain("223"),
                
                    // 1213312|122|31
                    new Chain("122"),

                    // 121331|212|231
                    new Chain("212"),

                    // 12133|121|2231
                    new Chain("121"),

                    // 1213|312|12231
                    new Chain("312"),

                    // 121|331|212231
                    new Chain("331"),

                    // 12|133|1212231
                    new Chain("133"),

                    // 1|213|31212231
                    new Chain("213"),

                    // |121|331212231 
                    new Chain("121") 
                };

            int i = 0;
            while (iterator.Next())
            {
                var message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i++]);
            }

            Assert.AreEqual(--i, 9);
        }

        /// <summary>
        /// The read block mode test.
        /// </summary>
        [Test]
        public void ReadBlockModeTest()
        {
            int length = 3;
            int step = 3;
            var iterator = new IteratorEnd(chainToIterate, length, step);

            var message2 = new List<Chain> 
                            { 
                                // 121331212|231|
                                new Chain("231"),

                                // 121331|212|231
                                new Chain("212"),

                                // 121|331|212231
                                new Chain("331"),

                                 // |121|331212231
                                 new Chain("121") 
                             };

            int i = 0;
            while (iterator.Next())
            {
                var message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i++]);
            }

            Assert.AreEqual(--i, 3);
        }
    }
}
