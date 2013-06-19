using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestBinaryGeometricMean
    {
        private List<Chain> Chains;
        private Dictionary<String, IBaseObject> Elements;
            
        [SetUp]
        public void Init()
        {
            Chains = ChainsForCalculation.Chains;
            Elements = ChainsForCalculation.Elements;
        }

        [TestCase(0, "c", "a", 1.732, 1)]
        public void TestSpatialDependence(int index, string firstElement, string secondElement,
                                          double firstValue, double secondValue)
        {
            BinaryGeometricMean calculator = new BinaryGeometricMean();

            Assert.AreEqual(firstValue, Math.Round(calculator.Calculate(Chains[index], Elements[firstElement], Elements[secondElement], LinkUp.End), 3));
            Assert.AreEqual(secondValue, calculator.Calculate(Chains[index], Elements[secondElement], Elements[firstElement], LinkUp.End));
        }
    }
}