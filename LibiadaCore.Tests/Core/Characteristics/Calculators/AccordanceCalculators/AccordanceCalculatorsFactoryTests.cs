using System;
using LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.AccordanceCalculators
{
    [TestFixture(TestOf = typeof(AccordanceCalculatorsFactory))]
    public class AccordanceCalculatorsFactoryTests
    {
        [TestCase(AccordanceCharacteristic.MutualComplianceDegree,typeof(MutualComplianceDegree))]
        [TestCase(AccordanceCharacteristic.PartialComplianceDegree, typeof(PartialComplianceDegree))]
        public void CreateCalculatorTest(AccordanceCharacteristic type, Type calculator)
        {
            Assert.IsInstanceOf(calculator, AccordanceCalculatorsFactory.CreateCalculator(type));
        }

        [Test]
        public void WrongCalculatorTypeTest()
        {
            Assert.Throws<ArgumentException>(() => AccordanceCalculatorsFactory.CreateCalculator(0));
        }
    }
}