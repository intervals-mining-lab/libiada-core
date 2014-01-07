using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class IteratorWritableStartTest
    {
        private Chain chainToIterate;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            chainToIterate = new Chain("121331212231");
        }

        ///<summary>
        ///</summary>
        [Test]
        public void WriteTest()
        {
            var messages = new List<ValueChar>(12)
                {
                    new ValueChar('1'), new ValueChar('2'), new ValueChar('1'),
                    new ValueChar('3'), new ValueChar('3'), new ValueChar('1'),
                    new ValueChar('2'), new ValueChar('1'), new ValueChar('2'),
                    new ValueChar('2'), new ValueChar('3'), new ValueChar('1')
                };

            var toWrite = new Chain(12);
            var iteratorWrite = new IteratorWritableStart<Chain, Chain>(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.SetCurrent(messages[i++]);
            }

            Assert.AreEqual(chainToIterate, toWrite);
        }
    }
}