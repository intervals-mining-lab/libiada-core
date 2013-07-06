using System.Collections.Generic;
using NUnit.Framework;
using Segmentator.Classes.Base.Iterators;
using Segmentator.Classes.Base.Seekers;
using Segmentator.Classes.Base.Sequencies;

namespace SegmentatorTest.Classes.Base.Seekers
{
    [TestFixture]
    public class SeekerSequenceTest
    {
        [Test]
        public void TestSeek()
        {
            int length = 2;
            int step = 1;

            List<string> list1 = new List<string> {"ABAC", "A", "A", "A", "ABAC", "A", "ABC", "AC", "ABC", "AG", "ABC", "A", "AB", "A", "ABC", "ABAC", "A"};
            List<string> list2 = new List<string> {"ABAC", "A"};
            SeekerSequence seek = new SeekerSequence(new StartIterator(new ComplexChain(list1), length, step));
            Assert.True(seek.Seek(list2) == 3);

        } 
    }
}