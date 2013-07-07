using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class IteratorStartTest
    {
        private Chain ChainToIterate;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainToIterate = new Chain(12);
            ChainToIterate.Add(new ValueChar('1'), 0);
            ChainToIterate.Add(new ValueChar('2'), 1);
            ChainToIterate.Add(new ValueChar('1'), 2);

            ChainToIterate.Add(new ValueChar('3'), 3);
            ChainToIterate.Add(new ValueChar('3'), 4);
            ChainToIterate.Add(new ValueChar('1'), 5);

            ChainToIterate.Add(new ValueChar('2'), 6);
            ChainToIterate.Add(new ValueChar('1'), 7);
            ChainToIterate.Add(new ValueChar('2'), 8);

            ChainToIterate.Add(new ValueChar('2'), 9);
            ChainToIterate.Add(new ValueChar('3'), 10);
            ChainToIterate.Add(new ValueChar('1'), 11);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ReadWindowModeTest()
        {
            int length = 3;
            int step = 1;
            IteratorBase<Chain, Chain> iterator = new IteratorStart<Chain, Chain>(ChainToIterate, length, step);
            Chain[] message2 = new Chain[10];
            message2[0] = new Chain(3);
            message2[0].Add(new ValueChar('1'), 0);
            message2[0].Add(new ValueChar('2'), 1);
            message2[0].Add(new ValueChar('1'), 2);

            message2[1] = new Chain(3);
            message2[1].Add(new ValueChar('2'), 0);
            message2[1].Add(new ValueChar('1'), 1);
            message2[1].Add(new ValueChar('3'), 2);

            message2[2] = new Chain(3);
            message2[2].Add(new ValueChar('1'), 0);
            message2[2].Add(new ValueChar('3'), 1);
            message2[2].Add(new ValueChar('3'), 2);

            message2[3] = new Chain(3);
            message2[3].Add(new ValueChar('3'), 0);
            message2[3].Add(new ValueChar('3'), 1);
            message2[3].Add(new ValueChar('1'), 2);

            message2[4] = new Chain(3);
            message2[4].Add(new ValueChar('3'), 0);
            message2[4].Add(new ValueChar('1'), 1);
            message2[4].Add(new ValueChar('2'), 2);

            message2[5] = new Chain(3);
            message2[5].Add(new ValueChar('1'), 0);
            message2[5].Add(new ValueChar('2'), 1);
            message2[5].Add(new ValueChar('1'), 2);

            message2[6] = new Chain(3);
            message2[6].Add(new ValueChar('2'), 0);
            message2[6].Add(new ValueChar('1'), 1);
            message2[6].Add(new ValueChar('2'), 2);

            message2[7] = new Chain(3);
            message2[7].Add(new ValueChar('1'), 0);
            message2[7].Add(new ValueChar('2'), 1);
            message2[7].Add(new ValueChar('2'), 2);

            message2[8] = new Chain(3);
            message2[8].Add(new ValueChar('2'), 0);
            message2[8].Add(new ValueChar('2'), 1);
            message2[8].Add(new ValueChar('3'), 2);

            message2[9] = new Chain(3);
            message2[9].Add(new ValueChar('2'), 0);
            message2[9].Add(new ValueChar('3'), 1);
            message2[9].Add(new ValueChar('1'), 2);

            int i = -1;
            while (iterator.Next())
            {
                i++;
                BaseChain message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i]);
            }

            Assert.AreEqual(9, i);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ReadBlockModeTest()
        {
            int length = 3;
            int step = 3;
            IteratorBase<Chain, Chain> iterator = new IteratorStart<Chain, Chain>(ChainToIterate, length, step);
            Chain[] message2 = new Chain[4];
            message2[0] = new Chain(3);
            message2[0].Add(new ValueChar('1'), 0);
            message2[0].Add(new ValueChar('2'), 1);
            message2[0].Add(new ValueChar('1'), 2);

            message2[1] = new Chain(3);
            message2[1].Add(new ValueChar('3'), 0);
            message2[1].Add(new ValueChar('3'), 1);
            message2[1].Add(new ValueChar('1'), 2);

            message2[2] = new Chain(3);
            message2[2].Add(new ValueChar('2'), 0);
            message2[2].Add(new ValueChar('1'), 1);
            message2[2].Add(new ValueChar('2'), 2);

            message2[3] = new Chain(3);
            message2[3].Add(new ValueChar('2'), 0);
            message2[3].Add(new ValueChar('3'), 1);
            message2[3].Add(new ValueChar('1'), 2);

            int i = -1;
            while (iterator.Next())
            {
                i++;
                BaseChain message1 = iterator.Current();
                Assert.AreEqual(message1, message2[i]);
            }

            Assert.AreEqual(3, i);
        }
    }
}