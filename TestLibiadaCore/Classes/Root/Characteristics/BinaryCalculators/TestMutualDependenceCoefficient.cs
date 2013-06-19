using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestMutualDependenceCoefficient
    {
        private List<Chain> Chains;
        private Dictionary<String, IBaseObject> Elements;

        [SetUp]
        public void Init()
        {
            Chains = ChainsForCalculation.Chains;
            Elements = ChainsForCalculation.Elements;
        }

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
        public void TestK3(int index, double value)
        {
            MutualDependenceCoefficient calculator = new MutualDependenceCoefficient();

            Assert.AreEqual(value, Math.Round(calculator.Calculate(Chains[index], Elements["a"], Elements["b"], LinkUp.End), 4));
        }

        [Test]
        public void TestGetK3()
        {
            MutualDependenceCoefficient calculator = new MutualDependenceCoefficient();

            List<List<double>> result;

            result = calculator.Calculate(Chains[1], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[10], LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.497, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.497, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            result = calculator.Calculate(Chains[18], LinkUp.End);

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