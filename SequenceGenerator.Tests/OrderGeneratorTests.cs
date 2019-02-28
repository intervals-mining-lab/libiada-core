namespace SequenceGenerator.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// The order generator tests.
    /// </summary>
    [TestFixture]
    public class OrderGeneratorTests
    {
        /// <summary>
        /// The generator test.
        /// </summary>
        [Test]
        public void GeneratorTest()
        {
            var expected = new List<int[]>
            {
                new[] { 1, 1, 1 },
                new[] { 1, 1, 2 },
                new[] { 1, 2, 1 },
                new[] { 1, 2, 2 }
            };

            var orderGenerator = new OrderGenerator();
            List<int[]> actual = orderGenerator.GenerateOrders(3, 2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The complete generator test.
        /// </summary>
        [Test]
        public void CompleteGeneratorTest()
        {
            var expected = new List<int[]>
            {
                new[] { 1, 1, 1 },
                new[] { 1, 1, 2 },
                new[] { 1, 2, 1 },
                new[] { 1, 2, 2 },
                new[] { 1, 2, 3 }
            };

            var orderGenerator = new OrderGenerator();
            List<int[]> actual = orderGenerator.GenerateOrders(3);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The strict generator test.
        /// </summary>
        [Test]
        public void StrictGeneratorTest()
        {
            var expected = new List<int[]>
            {
                new[] { 1, 1, 2, 3 },
                new[] { 1, 2, 1, 3 },
                new[] { 1, 2, 2, 3 },
                new[] { 1, 2, 3, 1 },
                new[] { 1, 2, 3, 2 },
                new[] { 1, 2, 3, 3 }
            };

            var orderGenerator = new OrderGenerator();
            List<int[]> actual = orderGenerator.StrictGenerateOrders(4, 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OrderValid()
        {
            var expectedLength = 4;
            var expectedAlphabetCardinality = 3;
            var orderGenerator = new OrderGenerator();
            List<int[]> actual = orderGenerator.StrictGenerateOrders(expectedLength, expectedAlphabetCardinality);
            Assert.True(actual.All(o => o.Length == expectedLength),"Invalid length");
            Assert.True(actual.All(o => o.Max() == expectedAlphabetCardinality), "Invlaid alphabet cardinality");
            var isFailed = false;
            foreach (var order in actual)
            {
                var currentMax = 1;
                for (int i = 0; i < order.Length; i++)
                {
                    if (order[i] > currentMax)
                    {
                        isFailed = true;
                        break;
                    }
                    else if (order[i] == currentMax)
                    {
                        currentMax++;
                    }
                }
                if (isFailed)
                {
                    break;
                }
            }
            Assert.False(isFailed,"Invalid order");
        }
    }
}
