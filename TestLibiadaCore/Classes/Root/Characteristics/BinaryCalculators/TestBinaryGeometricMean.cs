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
        private Dictionary<String, IBaseObject> Elements = BinaryCalculationHelper.Elements;
            
        [SetUp]
        public void Init()
        {
            Chains = BinaryCalculationHelper.Chains;
        }

        [TestCase(0, 1.7321, 1)]
        public void TestSpatialDependence(int index, double firstValue, double secondValue)
        {
            BinaryGeometricMean calculator = new BinaryGeometricMean();

            BinaryCalculationHelper.CalculationTest(calculator, index, "c", "a", firstValue);
            BinaryCalculationHelper.CalculationTest(calculator, index, "a", "c", secondValue);
        }
    }
}