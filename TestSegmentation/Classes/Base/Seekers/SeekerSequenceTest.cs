using System;
using System.Collections.Generic;
using NUnit.Framework;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Seekers;
using Segmentation.Classes.Base.Sequencies;

namespace TestSegmentation.Classes.Base.Seekers
{
    [TestFixture]
    public class SeekerSequenceTest
    {
        [Test]
        public void TestSeek()
        {
            int length = 2;
            int step = 1;
            SeekerSequence seek = null;
            List<String> list1 = null;
            List<String> list2 = null;
            StartIterator iterator = null;

            list1 = new List<string> {"ABAC", "A", "A", "A", "ABAC", "A", "ABC", "AC", "ABC", "AG", "ABC", "A", "AB", "A", "ABC", "ABAC", "A"};
            list2 = new List<string> {"ABAC", "A"};
            seek = new SeekerSequence(new StartIterator(new ComplexChain(list1), length, step));
            Assert.True(seek.Seek(list2) == 3);

        } 
    }
}