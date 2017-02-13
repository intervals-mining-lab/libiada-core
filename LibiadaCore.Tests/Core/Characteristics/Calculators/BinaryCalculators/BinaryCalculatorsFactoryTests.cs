using System;
using LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.BinaryCalculators
{
    [TestFixture(TestOf = typeof(BinaryCalculatorsFactory))]
    public class BinaryCalculatorsFactoryTests
    {
        [TestCase(BinaryCharacteristic.GeometricMean, typeof(GeometricMean))]
        [TestCase(BinaryCharacteristic.InvolvedPartialDependenceCoefficient, typeof(InvolvedPartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.MutualDependenceCoefficient, typeof(MutualDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.NormalizedPartialDependenceCoefficient,typeof(NormalizedPartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.PartialDependenceCoefficient, typeof(PartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.Redundancy, typeof(Redundancy))]
        public void CreateCalculatorTest(BinaryCharacteristic type, Type calculator)
        {
            Assert.IsInstanceOf(calculator, BinaryCalculatorsFactory.CreateCalculator(type));
        }

        [Test]
        public void WrongCalculatorTypeTest()
        {
            Assert.Throws<ArgumentException>(() => BinaryCalculatorsFactory.CreateCalculator(0));
        }
    }
}