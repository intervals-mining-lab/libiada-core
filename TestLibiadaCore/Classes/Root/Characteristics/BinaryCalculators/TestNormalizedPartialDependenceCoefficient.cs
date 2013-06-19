using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestNormalizedPartialDependenceCoefficient
    {
        private List<Chain> Chains;
        private Dictionary<String, IBaseObject> Elements = BinaryCalculationHelper.Elements;

        [SetUp]
        public void Init()
        {
            Chains = BinaryCalculationHelper.Chains;
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(3, 0, 0.1214)]
        [TestCase(4, 0.3, 0)]
        [TestCase(5, 0.1515, 0)]
        [TestCase(6, -1.6923, 0)]
        [TestCase(7, -0.0303, 0.0107)]
        [TestCase(8, 0.0855, 0.012)]
        [TestCase(9, 0.0047, 0.0424)]
        [TestCase(10, 0.1754, 0.0861)]
        [TestCase(11, 0.1971, 0.0127)]
        [TestCase(12, 0.0732, 0.0312)]
        [TestCase(13, 0.1426, 0.0991)]
        [TestCase(14, 0.2693, 0.0546)]
        [TestCase(15, 0.0357, 0.1458)]
        [TestCase(16, 0.0904, 0.0478)]
        [TestCase(17, 0.1401, 0.0578)]
        public void TestNormalizedK1(int index, double firstValue, double secondValue)
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();

            BinaryCalculationHelper.CalculationTest(calculator, index, "a", "b", firstValue);
            BinaryCalculationHelper.CalculationTest(calculator, index, "b", "a", secondValue);
        }

        [Test]
        public void TestGetNormalizedK1()
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();

            List<List<double>> result;

            result = calculator.Calculate(Chains[1], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[10], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.175, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.086, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[18], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.1352, Math.Round(result[0][1], 4));
            Assert.AreEqual(0.066, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.0729, Math.Round(result[1][0], 4));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.174, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.062, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.129, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);
        }
    }
}