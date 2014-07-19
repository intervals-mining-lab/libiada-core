namespace Segmenter.Tests.Base.Seekers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Iterators;
    using Segmenter.Base.Seekers;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// The seeker sequence test.
    /// </summary>
    [TestFixture]
    public class SeekerSequenceTest
    {
        /// <summary>
        /// The seek test.
        /// </summary>
        [Test]
        public void SeekTest()
        {
            int length = 2;
            int step = 1;

            var list1 = new List<string> { "ABAC", "A", "A", "A", "ABAC", "A", "ABC", "AC", "ABC", "AG", "ABC", "A", "AB", "A", "ABC", "ABAC", "A" };
            var list2 = new List<string> { "ABAC", "A" };
            var seek = new SeekerSequence(new StartIterator(new ComplexChain(list1), length, step));
            Assert.True(seek.Seek(list2) == 3);
        } 
    }
}