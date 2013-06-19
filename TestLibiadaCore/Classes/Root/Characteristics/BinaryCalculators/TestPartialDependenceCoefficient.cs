using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestPartialDependenceCoefficient
    {
        private List<Chain> Chains;
        private Dictionary<String, IBaseObject> Elements;

        [SetUp]
        public void Init()
        {
            Chains = ChainsForCalculation.Chains;
            Elements = ChainsForCalculation.Elements;
        }

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
        public void TestK1(int index, double firstValue, double secondValue)
        {
            PartialDependenceCoefficient calculator = new PartialDependenceCoefficient();

            Assert.AreEqual(firstValue, Math.Round(calculator.Calculate(Chains[index], Elements["a"], Elements["b"], LinkUp.End), 4));
            Assert.AreEqual(secondValue, Math.Round(calculator.Calculate(Chains[index], Elements["b"], Elements["a"], LinkUp.End), 4));
        }

        [Test]
        public void TestGetK1()
        {
            PartialDependenceCoefficient calculator = new PartialDependenceCoefficient();

            List<List<double>> result;

            result = calculator.Calculate(Chains[1], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[10], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.614, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.402, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[18], LinkUp.End);

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