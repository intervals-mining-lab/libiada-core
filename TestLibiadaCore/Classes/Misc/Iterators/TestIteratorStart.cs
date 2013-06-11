using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIteratorStart
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
        public void TestReadWindowMode()
        {
            int length = 3;
            int step = 1;
            IteratorBase<Chain, Chain> Iterator = new IteratorStart<Chain, Chain>(ChainToIterate, length, step);
            Chain[] Message2 = new Chain[10];
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('1'), 0);
            Message2[0].Add(new ValueChar('2'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            Message2[1] = new Chain(3);
            Message2[1].Add(new ValueChar('2'), 0);
            Message2[1].Add(new ValueChar('1'), 1);
            Message2[1].Add(new ValueChar('3'), 2);

            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('1'), 0);
            Message2[2].Add(new ValueChar('3'), 1);
            Message2[2].Add(new ValueChar('3'), 2);

            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('3'), 0);
            Message2[3].Add(new ValueChar('3'), 1);
            Message2[3].Add(new ValueChar('1'), 2);

            Message2[4] = new Chain(3);
            Message2[4].Add(new ValueChar('3'), 0);
            Message2[4].Add(new ValueChar('1'), 1);
            Message2[4].Add(new ValueChar('2'), 2);

            Message2[5] = new Chain(3);
            Message2[5].Add(new ValueChar('1'), 0);
            Message2[5].Add(new ValueChar('2'), 1);
            Message2[5].Add(new ValueChar('1'), 2);

            Message2[6] = new Chain(3);
            Message2[6].Add(new ValueChar('2'), 0);
            Message2[6].Add(new ValueChar('1'), 1);
            Message2[6].Add(new ValueChar('2'), 2);

            Message2[7] = new Chain(3);
            Message2[7].Add(new ValueChar('1'), 0);
            Message2[7].Add(new ValueChar('2'), 1);
            Message2[7].Add(new ValueChar('2'), 2);

            Message2[8] = new Chain(3);
            Message2[8].Add(new ValueChar('2'), 0);
            Message2[8].Add(new ValueChar('2'), 1);
            Message2[8].Add(new ValueChar('3'), 2);

            Message2[9] = new Chain(3);
            Message2[9].Add(new ValueChar('2'), 0);
            Message2[9].Add(new ValueChar('3'), 1);
            Message2[9].Add(new ValueChar('1'), 2);

            int i = -1;
            while (Iterator.Next())
            {
                i++;
                BaseChain Message1 = Iterator.Current();
                Assert.AreEqual(Message1, Message2[i]);
            }

            Assert.AreEqual(9, i);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestReadBlockMode()
        {
            int length = 3;
            int step = 3;
            IteratorBase<Chain, Chain> Iterator = new IteratorStart<Chain, Chain>(ChainToIterate, length, step);
            Chain[] Message2 = new Chain[4];
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('1'), 0);
            Message2[0].Add(new ValueChar('2'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            Message2[1] = new Chain(3);
            Message2[1].Add(new ValueChar('3'), 0);
            Message2[1].Add(new ValueChar('3'), 1);
            Message2[1].Add(new ValueChar('1'), 2);

            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('2'), 0);
            Message2[2].Add(new ValueChar('1'), 1);
            Message2[2].Add(new ValueChar('2'), 2);

            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('2'), 0);
            Message2[3].Add(new ValueChar('3'), 1);
            Message2[3].Add(new ValueChar('1'), 2);

            int i = -1;
            while (Iterator.Next())
            {
                i++;
                BaseChain Message1 = Iterator.Current();
                Assert.AreEqual(Message1, Message2[i]);
            }

            Assert.AreEqual(3, i);
        }
    }
}