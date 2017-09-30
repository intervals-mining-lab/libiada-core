using NUnit.Framework;
using SequenceGenerator;

namespace SequenceGeneretor.Tests
{
    [TestFixture]
    public class SequenceIteratorTests
    {
        [TestCase(new[] { 0, 0, 0 }, 0)]
        [TestCase(new[] { 1, 0, 0 }, 1)]
        [TestCase(new[] { 0, 1, 0 }, 2)]
        [TestCase(new[] { 1, 1, 0 }, 3)]
        [TestCase(new[] { 0, 0, 1 }, 4)]
        [TestCase(new[] { 1, 0, 1 }, 5)]
        [TestCase(new[] { 0, 1, 1 }, 6)]
        [TestCase(new[] { 1, 1, 1 }, 7)]
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
                    new[]{0, 0, 0},
                    new[]{1, 0, 0},
                    new[]{0, 1, 0},
                    new[]{1, 1, 0},
                    new[]{0, 0, 1},
                    new[]{1, 0, 1},
                    new[]{0, 1, 1},
                    new[]{1, 1, 1}
                    
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
