namespace LibiadaCore.Tests.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Iterators;

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
            chainToIterate = new Chain("121331212231");
        }

        /// <summary>
        /// The write test.
        /// </summary>
        [Test]
        public void WriteTest()
        {
            var messages = new List<ValueString> { '1', '3', '2', '2', '1', '2', '1', '3', '3', '1', '2', '1' };

            var toWrite = new Chain(12);
            var iteratorWrite = new IteratorWritableEnd(toWrite);
            int i = 0;
            while (iteratorWrite.Next())
            {
                iteratorWrite.WriteValue(messages[i++]);
            }

            Assert.AreEqual(chainToIterate, toWrite);
        }
    }
}
