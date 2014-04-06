namespace SegmentatorTest.Base.Seekers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmentator.Base.Iterators;
    using Segmentator.Base.Seekers;
    using Segmentator.Base.Sequencies;

    [TestFixture]
    public class SeekerSequenceTest
    {
        [Test]
        public void SeekTest()
        {
            int length = 2;
            int step = 1;

            List<string> list1 = new List<string> { "ABAC", "A", "A", "A", "ABAC", "A", "ABC", "AC", "ABC", "AG", "ABC", "A", "AB", "A", "ABC", "ABAC", "A" };
            List<string> list2 = new List<string> { "ABAC", "A" };
            SeekerSequence seek = new SeekerSequence(new StartIterator(new ComplexChain(list1), length, step));
            Assert.True(seek.Seek(list2) == 3);
        } 
    }
}