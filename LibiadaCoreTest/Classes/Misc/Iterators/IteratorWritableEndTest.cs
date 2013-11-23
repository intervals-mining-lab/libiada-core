using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class IteratorWritableEndTest
    {
        private Chain chainToIterate;

        [SetUp]
        public void Init()
        {
            chainToIterate = new Chain("121331212231");
        }

        [Test]
        public void WriteTest()
        {
            List<ValueChar> messages = new List<ValueChar>()
                {
                    new ValueChar('1'), new ValueChar('3'), new ValueChar('2'),
                    new ValueChar('2'), new ValueChar('1'), new ValueChar('2'),
                    new ValueChar('1'), new ValueChar('3'), new ValueChar('3'),
                    new ValueChar('1'), new ValueChar('2'), new ValueChar('1')
                };
            
            Chain toWrite = new Chain(12);
            IteratorWritableEnd<Chain, Chain> iteratorWrite = new IteratorWritableEnd<Chain, Chain>(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.SetCurrent(messages[i++]);
            }

            Assert.AreEqual(chainToIterate, toWrite);
        }
    }
}