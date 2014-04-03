using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SegmentatorTest.Classes.Base.Seekers
{
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
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void SeekTest()
        {
            int length = 1;
            int step = 1;
            String required1 = "A";
            String required2 = "C";
            String required3 = "T";
            String required4 = "G";

            Seeker seek = new Seeker(new StartIterator(chain, length, step));
            seek.Seek(new List<string> {required1});
            Assert.True(seek.Arrangement.Count == 4);

            seek.Seek(new List<string> {required2});
            Assert.True(seek.Arrangement.Count == 5);

            seek.Seek(new List<string> {required3});
            Assert.True(seek.Arrangement.Count == 6);

            seek.Seek(new List<string> {required4});
            Assert.True(seek.Arrangement.Count == 3);
        }

        [Test]
        public void SeekTwoTest()
        {
            int length = 1;
            int step = 1;
            String required1 = "AA";
            String required2 = "C";
            String required3 = "TTA";
            List<string> list = new List<string> {"AA", "AAAT", "AJJTTA"};

            Seeker seek = new Seeker(new StartIterator(new ComplexChain(list), length, step));
            seek.Seek(new List<string> {required1});
            Assert.True(seek.Arrangement.Count == 1);

            seek.Seek(new List<string> {required2});
            Assert.True(seek.Arrangement.Count == 0);

            seek.Seek(new List<string> {required3});
            Assert.True(seek.Arrangement.Count == 0);

        }

        [Test]
        public void GetMatchTest()
        {
            int length = 1;
            int step = 1;
            String required1 = "A";
            Seeker seek = new Seeker(new StartIterator(chain, length, step));
            seek.Seek(new List<string> { required1 });
            Assert.True(seek.Arrangement.Count == 4);
        }
    }
}