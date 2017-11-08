﻿using NUnit.Framework;
using SequenceGenerator;

namespace SequenceGeneretor.Tests
{
    [TestFixture]
    public class SequenceIteratorTests
    {
        [TestCase(new[] { 1, 1, 1 }, 0)]
        [TestCase(new[] { 2, 1, 1 }, 1)]
        [TestCase(new[] { 1, 2, 1 }, 2)]
        [TestCase(new[] { 2, 2, 1 }, 3)]
        [TestCase(new[] { 1, 1, 2 }, 4)]
        [TestCase(new[] { 2, 1, 2 }, 5)]
        [TestCase(new[] { 1, 2, 2 }, 6)]
        [TestCase(new[] { 2, 2, 2 }, 7)]
        public void IteratorTest(int[] expected, int iterations)
        {
            var iterator = new SequenceIterator(3, 2);
            for(int i = 0; i < iterations; i++)
            {
                iterator.IterateSequencesCounter();
            }
            var actual = iterator.Iterator;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumeratorTest()
        {
            var iterator = new SequenceIterator(3, 2);
            var expected = new[]
                {
                    new[]{1, 1, 1},
                    new[]{2, 1, 1},
                    new[]{1, 2, 1},
                    new[]{2, 2, 1},
                    new[]{1, 1, 2},
                    new[]{2, 1, 2},
                    new[]{1, 2, 2},
                    new[]{2, 2, 2}
                    
                };
            int i = 0;
            foreach (var actual in iterator)
            {
                Assert.AreEqual(expected[i], actual);
                i++;
            }
        }
    }
}
