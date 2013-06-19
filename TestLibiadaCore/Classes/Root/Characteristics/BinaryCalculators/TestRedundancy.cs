using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestRedundancy
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
        [TestCase(3, 0, 0.7282)]
        [TestCase(4, 0.75, 0)]
        [TestCase(5, 0.9091, 0)]
        [TestCase(6, -11, 0)]
        [TestCase(7, -0.5492, 0.9333)]
        [TestCase(8, 0.3563, 0.2615)]
        [TestCase(9, 0.0227, 0.9222)]
        [TestCase(10, 0.6139, 0.5358)]
        [TestCase(11, 0.6898, 0.079)]
        [TestCase(12, 0.2929, 0.5)]
        [TestCase(13, 0.5347, 0.6607)]
        [TestCase(14, 0.7741, 0.2789)]
        [TestCase(15, 0.8571, 0.875)]
        [TestCase(16, 0.4369, 0.6938)]
        [TestCase(17, 0.6072, 0.5636)]
        public void RedundancyTest(int index, double firstValue, double secondValue)
        {
            Redundancy calculator = new Redundancy();

            // ----------- цепочки из работы Морозенко

            Chain chain = new Chain(2);
            chain.Add(Elements["a"], 0);
            chain.Add(Elements["b"], 1);
            Assert.AreEqual(firstValue, Math.Round(calculator.Calculate(Chains[index], Elements["a"], Elements["b"], LinkUp.End), 4));
            Assert.AreEqual(secondValue, Math.Round(calculator.Calculate(Chains[index], Elements["b"], Elements["a"], LinkUp.End), 4));
        }
    }
}