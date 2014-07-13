namespace LibiadaCore.Tests.Misc.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.Iterators;

    using NUnit.Framework;

    /// <summary>
    /// The iterator writable end test.
    /// </summary>
    [TestFixture]
    public class IteratorWritableEndTests
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
            this.chainToIterate = new Chain("121331212231");
        }

        /// <summary>
        /// The write test.
        /// </summary>
        [Test]
        public void WriteTest()
        {
            var messages = new List<ValueChar> 
                {
                    new ValueChar('1'), new ValueChar('3'), new ValueChar('2'),
                    new ValueChar('2'), new ValueChar('1'), new ValueChar('2'),
                    new ValueChar('1'), new ValueChar('3'), new ValueChar('3'),
                    new ValueChar('1'), new ValueChar('2'), new ValueChar('1')
                };
            
            var toWrite = new Chain(12);
            var iteratorWrite = new IteratorWritableEnd(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.WriteValue(messages[i++]);
            }

            Assert.AreEqual(this.chainToIterate, toWrite);
        }
    }
}