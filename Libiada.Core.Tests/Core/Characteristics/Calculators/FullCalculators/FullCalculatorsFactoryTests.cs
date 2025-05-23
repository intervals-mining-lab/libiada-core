﻿namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using System.ComponentModel;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The full calculators factory tests.
/// </summary>
[TestFixture(TestOf = typeof(FullCalculatorsFactory))]
public class FullCalculatorsFactoryTests
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
    [TestCase(FullCharacteristic.AlphabetCardinality, typeof(AlphabetCardinality))]
    [TestCase(FullCharacteristic.AlphabeticAverageRemoteness, typeof(AlphabeticAverageRemoteness))]
    [TestCase(FullCharacteristic.AlphabeticDepth, typeof(AlphabeticDepth))]
    [TestCase(FullCharacteristic.ArithmeticMean, typeof(ArithmeticMean))]
    [TestCase(FullCharacteristic.ATSkew, typeof(ATSkew))]
    [TestCase(FullCharacteristic.AverageRemoteness, typeof(AverageRemoteness))]
    [TestCase(FullCharacteristic.AverageRemotenessATSkew, typeof(AverageRemotenessATSkew))]
    [TestCase(FullCharacteristic.AverageRemotenessVariance, typeof(AverageRemotenessVariance))]
    [TestCase(FullCharacteristic.AverageRemotenessGCRatio, typeof(AverageRemotenessGCRatio))]
    [TestCase(FullCharacteristic.AverageRemotenessGCSkew, typeof(AverageRemotenessGCSkew))]
    [TestCase(FullCharacteristic.AverageRemotenessGCToATRatio, typeof(AverageRemotenessGCToATRatio))]
    [TestCase(FullCharacteristic.AverageRemotenessKurtosis, typeof(AverageRemotenessKurtosis))]
    [TestCase(FullCharacteristic.AverageRemotenessKurtosisCoefficient, typeof(AverageRemotenessKurtosisCoefficient))]
    [TestCase(FullCharacteristic.AverageRemotenessMKSkew, typeof(AverageRemotenessMKSkew))]
    [TestCase(FullCharacteristic.AverageRemotenessRYSkew, typeof(AverageRemotenessRYSkew))]
    [TestCase(FullCharacteristic.AverageRemotenessSkewness, typeof(AverageRemotenessSkewness))]
    [TestCase(FullCharacteristic.AverageRemotenessSkewnessCoefficient, typeof(AverageRemotenessSkewnessCoefficient))]
    [TestCase(FullCharacteristic.AverageRemotenessStandardDeviation, typeof(AverageRemotenessStandardDeviation))]
    [TestCase(FullCharacteristic.AverageRemotenessSWSkew, typeof(AverageRemotenessSWSkew))]
    [TestCase(FullCharacteristic.AverageWordLength, typeof(AverageWordLength))]
    [TestCase(FullCharacteristic.CuttingLength, typeof(CuttingLength))]
    [TestCase(FullCharacteristic.CuttingLengthVocabularyEntropy, typeof(CuttingLengthVocabularyEntropy))]
    [TestCase(FullCharacteristic.Depth, typeof(Depth))]
    [TestCase(FullCharacteristic.DescriptiveInformation, typeof(DescriptiveInformation))]
    [TestCase(FullCharacteristic.ElementsCount, typeof(ElementsCount))]
    [TestCase(FullCharacteristic.IdentifyingInformationVariance, typeof(IdentifyingInformationVariance))]
    [TestCase(FullCharacteristic.IdentifyingInformationKurtosis, typeof(IdentifyingInformationKurtosis))]
    [TestCase(FullCharacteristic.IdentifyingInformationKurtosisCoefficient, typeof(IdentifyingInformationKurtosisCoefficient))]
    [TestCase(FullCharacteristic.IdentifyingInformationSkewness, typeof(IdentifyingInformationSkewness))]
    [TestCase(FullCharacteristic.IdentifyingInformationSkewnessCoefficient, typeof(IdentifyingInformationSkewnessCoefficient))]
    [TestCase(FullCharacteristic.IdentifyingInformationStandardDeviation, typeof(IdentifyingInformationStandardDeviation))]
    [TestCase(FullCharacteristic.GCRatio, typeof(GCRatio))]
    [TestCase(FullCharacteristic.GCSkew, typeof(GCSkew))]
    [TestCase(FullCharacteristic.GCToATRatio, typeof(GCToATRatio))]
    [TestCase(FullCharacteristic.GeometricMean, typeof(GeometricMean))]
    [TestCase(FullCharacteristic.IdentifyingInformation, typeof(IdentifyingInformation))]
    [TestCase(FullCharacteristic.IntervalsCount, typeof(IntervalsCount))]
    [TestCase(FullCharacteristic.IntervalsSum, typeof(IntervalsSum))]
    [TestCase(FullCharacteristic.Length, typeof(Length))]
    [TestCase(FullCharacteristic.MKSkew, typeof(MKSkew))]
    [TestCase(FullCharacteristic.Periodicity, typeof(Periodicity))]
    [TestCase(FullCharacteristic.Probability, typeof(Probability))]
    [TestCase(FullCharacteristic.Regularity, typeof(Regularity))]
    [TestCase(FullCharacteristic.RemotenessVariance, typeof(RemotenessVariance))]
    [TestCase(FullCharacteristic.RemotenessKurtosis, typeof(RemotenessKurtosis))]
    [TestCase(FullCharacteristic.RemotenessKurtosisCoefficient, typeof(RemotenessKurtosisCoefficient))]
    [TestCase(FullCharacteristic.RemotenessSkewness, typeof(RemotenessSkewness))]
    [TestCase(FullCharacteristic.RemotenessSkewnessCoefficient, typeof(RemotenessSkewnessCoefficient))]
    [TestCase(FullCharacteristic.RemotenessStandardDeviation, typeof(RemotenessStandardDeviation))]
    [TestCase(FullCharacteristic.RYSkew, typeof(RYSkew))]
    [TestCase(FullCharacteristic.SWSkew, typeof(SWSkew))]
    [TestCase(FullCharacteristic.Uniformity, typeof(Uniformity))]
    [TestCase(FullCharacteristic.VariationsCount, typeof(VariationsCount))]
    [TestCase(FullCharacteristic.Volume, typeof(Volume))]
    public void CreateCalculatorTest(FullCharacteristic type, Type calculator)
    {
        Assert.That(FullCalculatorsFactory.CreateCalculator(type), Is.TypeOf(calculator));
    }

    /// <summary>
    /// The wrong calculator type test.
    /// </summary>
    [Test]
    public void WrongCalculatorTypeTest()
    {
        Assert.Throws<InvalidEnumArgumentException>(() => FullCalculatorsFactory.CreateCalculator(0));
    }
}
