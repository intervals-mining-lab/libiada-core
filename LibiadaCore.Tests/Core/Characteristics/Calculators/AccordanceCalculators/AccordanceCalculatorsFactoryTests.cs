﻿namespace LibiadaCore.Tests.Core.Characteristics.Calculators.AccordanceCalculators
{
    using System;
    using System.ComponentModel;

    using LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The accordance calculators factory tests.
    /// </summary>
    [TestFixture(TestOf = typeof(AccordanceCalculatorsFactory))]
    public class AccordanceCalculatorsFactoryTests
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
        [TestCase(AccordanceCharacteristic.MutualComplianceDegree, typeof(MutualComplianceDegree))]
        [TestCase(AccordanceCharacteristic.PartialComplianceDegree, typeof(PartialComplianceDegree))]
        public void CreateCalculatorTest(AccordanceCharacteristic type, Type calculator)
        {
            Assert.IsInstanceOf(calculator, AccordanceCalculatorsFactory.CreateCalculator(type));
        }

        /// <summary>
        /// The wrong calculator type test.
        /// </summary>
        [Test]
        public void WrongCalculatorTypeTest()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => AccordanceCalculatorsFactory.CreateCalculator(0));
        }
    }
}
