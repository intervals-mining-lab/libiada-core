namespace LibiadaCore.Tests.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Iterators;

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
            chainToIterate = new Chain("121331212231");
        }

        /// <summary>
        /// The write test.
        /// </summary>
        [Test]
        public void WriteTest()
        {
            var messages = new List<ValueString>(12)
                               {
                                   new ValueString('1'),
                                   new ValueString('2'),
                                   new ValueString('1'),
                                   new ValueString('3'),
                                   new ValueString('3'),
                                   new ValueString('1'),
                                   new ValueString('2'),
                                   new ValueString('1'),
                                   new ValueString('2'),
                                   new ValueString('2'),
                                   new ValueString('3'),
                                   new ValueString('1')
                               };

            var toWrite = new Chain(12);
            var iteratorWrite = new IteratorWritableStart(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.WriteValue(messages[i++]);
            }

            Assert.AreEqual(chainToIterate, toWrite);
        }
    }
}
