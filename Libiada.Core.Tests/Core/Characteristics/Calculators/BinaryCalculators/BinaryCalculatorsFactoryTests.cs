namespace LibiadaCore.Tests.Core.Characteristics.Calculators.BinaryCalculators
{
    using System;
    using System.ComponentModel;

    using LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The binary calculators factory tests.
    /// </summary>
    [TestFixture(TestOf = typeof(BinaryCalculatorsFactory))]
    public class BinaryCalculatorsFactoryTests
    {
        /// <summary>
        /// Calculator creation test.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="calculator">
        /// The calculator.
        /// </param>
        [TestCase(BinaryCharacteristic.GeometricMean, typeof(GeometricMean))]
        [TestCase(BinaryCharacteristic.InvolvedPartialDependenceCoefficient, typeof(InvolvedPartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.MutualDependenceCoefficient, typeof(MutualDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.NormalizedPartialDependenceCoefficient, typeof(NormalizedPartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.PartialDependenceCoefficient, typeof(PartialDependenceCoefficient))]
        [TestCase(BinaryCharacteristic.Redundancy, typeof(Redundancy))]
        public void CreateCalculatorTest(BinaryCharacteristic type, Type calculator)
        {
            Assert.IsInstanceOf(calculator, BinaryCalculatorsFactory.CreateCalculator(type));
        }

        /// <summary>
        /// The wrong calculator type test.
        /// </summary>
        [Test]
        public void WrongCalculatorTypeTest()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => BinaryCalculatorsFactory.CreateCalculator(0));
        }
    }
}
