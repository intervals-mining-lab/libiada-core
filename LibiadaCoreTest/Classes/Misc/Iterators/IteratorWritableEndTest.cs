using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class IteratorWritableEndTest
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
        public void WriteTest()
        {
            ValueChar[] messages = new ValueChar[12];
            messages[11] = new ValueChar('1');
            messages[10] = new ValueChar('2');
            messages[9] = new ValueChar('1');

            messages[8] = new ValueChar('3');
            messages[7] = new ValueChar('3');
            messages[6] = new ValueChar('1');

            messages[5] = new ValueChar('2');
            messages[4] = new ValueChar('1');
            messages[3] = new ValueChar('2');

            messages[2] = new ValueChar('2');
            messages[1] = new ValueChar('3');
            messages[0] = new ValueChar('1');

            Chain toWrite = new Chain(12);
            IteratorWritableEnd<Chain, Chain> iteratorWrite = new IteratorWritableEnd<Chain, Chain>(toWrite);
            int i = -1;
            while (iteratorWrite.Next())
            {
                i++;
                iteratorWrite.SetCurrent(messages[i]);
            }

            Assert.AreEqual(ChainToIterate, toWrite);
        }
    }
}