namespace SegmentatorTest.Base.Seekers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmentator.Base.Iterators;
    using Segmentator.Base.Seekers;
    using Segmentator.Base.Sequencies;

    [TestFixture]
    public class SeekerTest
    {
        private ComplexChain chain;

        [SetUp]
        public void SetUp()
        {
            this.chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void SeekTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "A";
            string required2 = "C";
            string required3 = "T";
            string required4 = "G";

            Seeker seek = new Seeker(new StartIterator(this.chain, length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 4);

            seek.Seek(new List<string> { required2 });
            Assert.True(seek.Arrangement.Count == 5);

            seek.Seek(new List<string> { required3 });
            Assert.True(seek.Arrangement.Count == 6);

            seek.Seek(new List<string> { required4 });
            Assert.True(seek.Arrangement.Count == 3);
        }

        [Test]
        public void SeekTwoTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "AA";
            string required2 = "C";
            string required3 = "TTA";
            List<string> list = new List<string> { "AA", "AAAT", "AJJTTA" };

            Seeker seek = new Seeker(new StartIterator(new ComplexChain(list), length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 1);

            seek.Seek(new List<string> { required2 });
            Assert.True(seek.Arrangement.Count == 0);

            seek.Seek(new List<string> { required3 });
            Assert.True(seek.Arrangement.Count == 0);
        }

        [Test]
        public void GetMatchTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "A";
            Seeker seek = new Seeker(new StartIterator(this.chain, length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 4);
        }
    }
}