﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Seekers;
using Segmentation.Classes.Base.Sequencies;

namespace TestSegmentation.Classes.Base.Seekers
{
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
        public void testSeek()
        {
            int length = 1;
            int step = 1;
            Seeker seek = null;
            List<String> list = null;
            String required1 = "A";
            String required2 = "C";
            String required3 = "T";
            String required4 = "G";

            seek = new Seeker(new StartIterator(chain, length, step));
            seek.seek(new List<string> {required1});
            Assert.True(seek.arrangement().Count == 4);

            seek.seek(new List<string> {required2});
            Assert.True(seek.arrangement().Count == 5);

            seek.seek(new List<string> {required3});
            Assert.True(seek.arrangement().Count == 6);

            seek.seek(new List<string> {required4});
            Assert.True(seek.arrangement().Count == 3);
        }

        [Test]
        public void testSeek2()
        {
            int length = 1;
            int step = 1;
            Seeker seek = null;
            List<String> list = null;
            String required1 = "AA";
            String required2 = "C";
            String required3 = "TTA";
            list = new List<string> {"AA", "AAAT", "AJJTTA"};

            seek = new Seeker(new StartIterator(new ComplexChain(list), length, step));
            seek.seek(new List<string> {required1});
            Assert.True(seek.arrangement().Count == 1);

            seek.seek(new List<string> {required2});
            Assert.True(seek.arrangement().Count == 0);

            seek.seek(new List<string> {required3});
            Assert.True(seek.arrangement().Count == 0);

        }

        [Test]
        public void testGetMatch()
        {
            int length = 1;
            int step = 1;
            Seeker seek = null;
            String required1 = "A";
            seek = new Seeker(new StartIterator(chain, length, step));
            seek.seek(new List<string> { required1 });
            Assert.True(seek.arrangement().Count == 4);
        }
    }
}