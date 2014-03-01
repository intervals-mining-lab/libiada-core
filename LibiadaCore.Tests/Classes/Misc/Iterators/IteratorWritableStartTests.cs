namespace LibiadaCore.Tests.Classes.Misc.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The iterator writable start test.
    /// </summary>
    [TestFixture]
    public class IteratorWritableStartTests
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
            var messages = new List<ValueChar>(12)
                               {
                                   new ValueChar('1'),
                                   new ValueChar('2'),
                                   new ValueChar('1'),
                                   new ValueChar('3'),
                                   new ValueChar('3'),
                                   new ValueChar('1'),
                                   new ValueChar('2'),
                                   new ValueChar('1'),
                                   new ValueChar('2'),
                                   new ValueChar('2'),
                                   new ValueChar('3'),
                                   new ValueChar('1')
                               };

            var toWrite = new Chain(12);
            var iteratorWrite = new IteratorWritableStart<Chain, Chain>(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.WriteValue(messages[i++]);
            }

            Assert.AreEqual(this.chainToIterate, toWrite);
        }
    }
}