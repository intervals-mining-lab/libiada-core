using System;
using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    [TestFixture(TestOf = typeof(FullCalculatorsFactory))]
    public class FullCalculatorsFactoryTests
    {
        [TestCase(FullCharacteristic.AlphabetCardinality, typeof(AlphabetCardinality))]
        [TestCase(FullCharacteristic.AlphabeticAverageRemoteness, typeof(AlphabeticAverageRemoteness))]
        [TestCase(FullCharacteristic.AlphabeticDepth, typeof(AlphabeticDepth))]
        [TestCase(FullCharacteristic.ArithmeticMean, typeof(ArithmeticMean))]
        [TestCase(FullCharacteristic.ATSkew, typeof(ATSkew))]
        [TestCase(FullCharacteristic.AverageRemoteness, typeof(AverageRemoteness))]
        [TestCase(FullCharacteristic.AverageRemotenessATSkew, typeof(AverageRemotenessATSkew))]
        [TestCase(FullCharacteristic.AverageRemotenessDispersion, typeof(AverageRemotenessDispersion))]
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
        [TestCase(FullCharacteristic.EntropyDispersion, typeof(EntropyDispersion))]
        [TestCase(FullCharacteristic.EntropyKurtosis, typeof(EntropyKurtosis))]
        [TestCase(FullCharacteristic.EntropyKurtosisCoefficient, typeof(EntropyKurtosisCoefficient))]
        [TestCase(FullCharacteristic.EntropySkewness, typeof(EntropySkewness))]
        [TestCase(FullCharacteristic.EntropySkewnessCoefficient, typeof(EntropySkewnessCoefficient))]
        [TestCase(FullCharacteristic.EntropyStandardDeviation, typeof(EntropyStandardDeviation))]
        [TestCase(FullCharacteristic.GCRatio, typeof(GCRatio))]
        [TestCase(FullCharacteristic.GCSkew, typeof(GCSkew))]
        [TestCase(FullCharacteristic.GCToATRatio, typeof(GCToATRatio))]
        [TestCase(FullCharacteristic.GeometricMean, typeof(GeometricMean))]
        [TestCase(FullCharacteristic.IdentificationInformation, typeof(IdentificationInformation))]
        [TestCase(FullCharacteristic.IntervalsCount, typeof(IntervalsCount))]
        [TestCase(FullCharacteristic.IntervalsSum, typeof(IntervalsSum))]
        [TestCase(FullCharacteristic.Length, typeof(Length))]
        [TestCase(FullCharacteristic.MKSkew, typeof(MKSkew))]
        [TestCase(FullCharacteristic.Periodicity, typeof(Periodicity))]
        [TestCase(FullCharacteristic.Probability, typeof(Probability))]
        [TestCase(FullCharacteristic.Regularity, typeof(Regularity))]
        [TestCase(FullCharacteristic.RemotenessDispersion, typeof(RemotenessDispersion))]
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
            Assert.IsInstanceOf(calculator, FullCalculatorsFactory.CreateCalculator(type));
        }
    }
}