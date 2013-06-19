using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestDescriptiveInformation : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            DescriptiveInformation calc = new DescriptiveInformation();

            const double length = 10;
            const double elementsCount = 3;
            const double arithmeticMean = length/elementsCount;
            const double propability = elementsCount/length;
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, Math.Pow(arithmeticMean, propability) * Math.Pow(1 / (1 - propability), 1 - propability));
            TestUniformChainCharacteristic(0, calc, LinkUp.End, Math.Pow(arithmeticMean, propability) * Math.Pow(1 / (1 - propability), 1 - propability));
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, Math.Pow(arithmeticMean, propability) * Math.Pow(1 / (1 - propability), 1 - propability));
        }

        [Test]
        public void TestChainCalculation()
        {
            DescriptiveInformation calc = new DescriptiveInformation();

            const double length = 10;
            const double elementsACount = 4;
            const double elementsBCount = 3;
            const double elementsCCount = 3;

            const double arithmeticMeanA = length/elementsACount;
            const double arithmeticMeanB = length/elementsBCount;
            const double arithmeticMeanC = length/elementsCCount;

            const double propabilityA = elementsACount/length;
            const double propabilityB = elementsBCount/length;
            const double propabilityC = elementsCCount/length;

            double DA = Math.Pow(arithmeticMeanA, propabilityA);
            double DB = Math.Pow(arithmeticMeanB, propabilityB);
            double DC = Math.Pow(arithmeticMeanC, propabilityC);

            double DTheoretical = DA*DB*DC;

            TestChainCharacteristic(0, calc, LinkUp.Start, DTheoretical);
            TestChainCharacteristic(0, calc, LinkUp.End, DTheoretical);
            TestChainCharacteristic(0, calc, LinkUp.Both, DTheoretical);
        }
    }
}