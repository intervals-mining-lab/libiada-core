namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    /// <summary>
    /// The iterator start test.
    /// </summary>
    [TestFixture]
    public class IteratorStartTests
    {
        /// <summary>
        /// The chain to iterate.
        /// </summary>
        private Chain chainToIterate;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
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
            var iterator = new IteratorStart<Chain, Chain>(chainToIterate, length, step);
            var message2 = new List<Chain>
                               {
                                   new Chain("121"),
                                   new Chain("213"),
                                   new Chain("133"),
                                   new Chain("331"),
                                   new Chain("312"),
                                   new Chain("121"),
                                   new Chain("212"),
                                   new Chain("122"),
                                   new Chain("223"),
                                   new Chain("231")
                               };

            int i = 0;
            while (iterator.Next())
            {
                BaseChain message1 = iterator.Current();
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
            var iterator = new IteratorStart<Chain, Chain>(chainToIterate, length, step);
            var message2 = new List<Chain> { new Chain("121"), new Chain("331"), new Chain("212"), new Chain("231") };

            int i = 0;
            while (iterator.Next())
            {
                BaseChain message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i++]);
            }

            Assert.AreEqual(--i, 3);
        }
    }
}