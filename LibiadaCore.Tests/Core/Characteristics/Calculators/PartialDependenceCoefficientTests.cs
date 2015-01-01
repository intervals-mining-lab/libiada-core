namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The partial dependence coefficient test.
    /// </summary>
    [TestFixture]
    public class PartialDependenceCoefficientTests : BinaryCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("PartialDependenceCoefficient");
        }

        /// <summary>
        /// The k 1 test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="firstValue">
        /// The first value.
        /// </param>
        /// <param name="secondValue">
        /// The second value.
        /// </param>
        [TestCase(1, 0, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(3, 0, 0.5461)]
        [TestCase(4, 0.75, 0)]
        [TestCase(5, 0.9091, 0)]
        [TestCase(6, -11, 0)]
        [TestCase(7, -0.2197, 0.1556)]
        [TestCase(8, 0.3563, 0.0747)]
        [TestCase(9, 0.0227, 0.3074)]
        [TestCase(10, 0.6139, 0.4019)]
        [TestCase(11, 0.6898, 0.0592)]
        [TestCase(12, 0.2929, 0.25)]
        [TestCase(13, 0.5347, 0.4955)]
        [TestCase(14, 0.7741, 0.2092)]
        [TestCase(15, 0.2143, 0.875)]
        [TestCase(16, 0.4369, 0.3469)]
        [TestCase(17, 0.6072, 0.3757)]
        public void K1Test(int index, double firstValue, double secondValue)
        {
            CalculationTest(index, firstValue, secondValue);
        }

        /// <summary>
        /// The get k 1 test.
        /// </summary>
        [Test]
        public void GetK1Test()
        {
            List<List<double>> result = Calculator.CalculateAll(Chains[1], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);

            result = Calculator.CalculateAll(Chains[10], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.614, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.402, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            result = Calculator.CalculateAll(Chains[18], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.4055, Math.Round(result[0][1], 4));
            Assert.AreEqual(0.197, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.4375, Math.Round(result[1][0], 4));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.349, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.375, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.388, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);
        }
    }
}
