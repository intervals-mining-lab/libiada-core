namespace LibiadaCore.Tests.Core.Characteristics.BinaryCalculators
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.BinaryCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The mutual dependence coefficient test.
    /// </summary>
    [TestFixture]
    public class MutualDependenceCoefficientTests : BinaryCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            Calculator = new MutualDependenceCoefficient();
        }

        /// <summary>
        /// The k 3 test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 0)]
        [TestCase(7, 0)]
        [TestCase(8, 0.1495)]
        [TestCase(9, 0.0788)]
        [TestCase(10, 0.4967)]
        [TestCase(11, 0.2022)]
        [TestCase(12, 0.2706)]
        [TestCase(13, 0.5147)]
        [TestCase(14, 0.4024)]
        [TestCase(15, 0.3464)]
        [TestCase(16, 0.3853)]
        [TestCase(17, 0.4776)]
        [TestCase(19, 0)]
        public void K3Test(int index, double value)
        {
            CalculationTest(index, value, value);
        }

        /// <summary>
        /// The get k 3 test.
        /// </summary>
        [Test]
        public void GetK3Test()
        {
            List<List<double>> result = Calculator.Calculate(Chains[1], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);

            result = Calculator.Calculate(Chains[10], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.497, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.497, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            result = Calculator.Calculate(Chains[18], Link.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.397, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.236, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.397, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.360, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.236, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.360, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);
        }
    }
}