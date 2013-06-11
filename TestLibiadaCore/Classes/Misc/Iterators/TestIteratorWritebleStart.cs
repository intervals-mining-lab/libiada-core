using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIteratorWritebleStart
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
        public void TestWrite()
        {
            ValueChar[] Messages = new ValueChar[12];
            Messages[0] = new ValueChar('1');
            Messages[1] = new ValueChar('2');
            Messages[2] = new ValueChar('1');

            Messages[3] = new ValueChar('3');
            Messages[4] = new ValueChar('3');
            Messages[5] = new ValueChar('1');

            Messages[6] = new ValueChar('2');
            Messages[7] = new ValueChar('1');
            Messages[8] = new ValueChar('2');

            Messages[9] = new ValueChar('2');
            Messages[10] = new ValueChar('3');
            Messages[11] = new ValueChar('1');

            Chain ToWrite = new Chain(12);
            IteratorWritableStart<Chain, Chain> IteratorWrite = new IteratorWritableStart<Chain, Chain>(ToWrite);
            int i = -1;
            while (IteratorWrite.Next())
            {
                i++;
                IteratorWrite.SetCurrent(Messages[i]);
            }

            Assert.AreEqual(ChainToIterate, ToWrite);
        }
    }
}