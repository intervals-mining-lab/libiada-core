namespace Segmenter.Tests.Base.Seekers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Iterators;
    using Segmenter.Base.Seekers;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// The seeker test.
    /// </summary>
    [TestFixture]
    public class SeekerTest
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private ComplexChain chain;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        /// <summary>
        /// The seek test.
        /// </summary>
        [Test]
        public void SeekTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "A";
            string required2 = "C";
            string required3 = "T";
            string required4 = "G";

            var seek = new Seeker(new StartIterator(chain, length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 4);

            seek.Seek(new List<string> { required2 });
            Assert.True(seek.Arrangement.Count == 5);

            seek.Seek(new List<string> { required3 });
            Assert.True(seek.Arrangement.Count == 6);

            seek.Seek(new List<string> { required4 });
            Assert.True(seek.Arrangement.Count == 3);
        }

        /// <summary>
        /// The seek two test.
        /// </summary>
        [Test]
        public void SeekTwoTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "AA";
            string required2 = "C";
            string required3 = "TTA";
            var list = new List<string> { "AA", "AAAT", "AJJTTA" };

            var seek = new Seeker(new StartIterator(new ComplexChain(list), length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 1);

            seek.Seek(new List<string> { required2 });
            Assert.True(seek.Arrangement.Count == 0);

            seek.Seek(new List<string> { required3 });
            Assert.True(seek.Arrangement.Count == 0);
        }

        /// <summary>
        /// The get match test.
        /// </summary>
        [Test]
        public void GetMatchTest()
        {
            int length = 1;
            int step = 1;
            string required1 = "A";
            var seek = new Seeker(new StartIterator(chain, length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 4);
        }
    }
}