﻿namespace SequenceGenerator.Tests
{
    using System.Collections.Generic;

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
    }
}