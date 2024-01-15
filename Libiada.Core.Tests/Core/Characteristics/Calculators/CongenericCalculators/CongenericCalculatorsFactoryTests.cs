namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using System;
using System.ComponentModel;

using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using NUnit.Framework;

/// <summary>
/// The congeneric calculators factory tests.
/// </summary>
[TestFixture(TestOf = typeof(CongenericCalculatorsFactory))]
public class CongenericCalculatorsFactoryTests
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
    [TestCase(CongenericCharacteristic.ArithmeticMean, typeof(ArithmeticMean))]
    [TestCase(CongenericCharacteristic.AverageRemoteness, typeof(AverageRemoteness))]
    [TestCase(CongenericCharacteristic.CuttingLength, typeof(CuttingLength))]
    [TestCase(CongenericCharacteristic.CuttingLengthVocabularyEntropy, typeof(CuttingLengthVocabularyEntropy))]
    [TestCase(CongenericCharacteristic.Depth, typeof(Depth))]
    [TestCase(CongenericCharacteristic.DescriptiveInformation, typeof(DescriptiveInformation))]
    [TestCase(CongenericCharacteristic.ElementsCount, typeof(ElementsCount))]
    [TestCase(CongenericCharacteristic.GeometricMean, typeof(GeometricMean))]
    [TestCase(CongenericCharacteristic.IdentificationInformation, typeof(IdentificationInformation))]
    [TestCase(CongenericCharacteristic.IntervalsCount, typeof(IntervalsCount))]
    [TestCase(CongenericCharacteristic.IntervalsSum, typeof(IntervalsSum))]
    [TestCase(CongenericCharacteristic.Length, typeof(Length))]
    [TestCase(CongenericCharacteristic.Periodicity, typeof(Periodicity))]
    [TestCase(CongenericCharacteristic.Probability, typeof(Probability))]
    [TestCase(CongenericCharacteristic.Regularity, typeof(Regularity))]
    [TestCase(CongenericCharacteristic.Uniformity, typeof(Uniformity))]
    [TestCase(CongenericCharacteristic.VariationsCount, typeof(VariationsCount))]
    [TestCase(CongenericCharacteristic.Volume, typeof(Volume))]
    public void CreateCalculatorTest(CongenericCharacteristic type, Type calculator)
    {
        Assert.IsInstanceOf(calculator, CongenericCalculatorsFactory.CreateCalculator(type));
    }

    /// <summary>
    /// The wrong calculator type test.
    /// </summary>
    [Test]
    public void WrongCalculatorTypeTest()
    {
        Assert.Throws<InvalidEnumArgumentException>(() => CongenericCalculatorsFactory.CreateCalculator(0));
    }
}
