using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class IteratorEndTest
    {
        private Chain ChainToIterate;

        [SetUp]
        public void Init()
        {
            ChainToIterate = new Chain("121331212231");
        }

        [Test]
        public void ReadWindowModeTest()
        {
            int length = 3;
            int step = 1;
            IteratorEnd<Chain, Chain> iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);
            // 12 - 3 + 1
            List<Chain> message2 = new List<Chain>()
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
                BaseChain message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i++]);
            }

            Assert.AreEqual(--i, 9);
        }

        [Test]
        public void ReadBlockModeTest()
        {
            int length = 3;
            int step = 3;
            IteratorEnd<Chain, Chain> iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);

            List<Chain> message2 = new List<Chain>()
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
                BaseChain message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i++]);
            }

            Assert.AreEqual(--i, 3);
        }
    }
}