using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestPeriodicity : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculationForUniformChain()
        {
            Periodicity periodicity = new Periodicity();

            double length = 10;
            double elementCount = 3;
            double arithmeticMean = length/elementCount;

            int interval1 = 4;
            int interval2 = 1;
            int interval3 = 3;
            int interval4 = 3;

            double intervalsCount = 3;
            double geometricMiddling = Math.Pow(interval1*interval2*interval3, 1/intervalsCount);

            Assert.AreEqual(geometricMiddling / arithmeticMean, periodicity.Calculate(uniformChains[0], LinkUp.Start));

            intervalsCount = 3;
            geometricMiddling = Math.Pow(interval2*interval3*interval4, 1/intervalsCount);

            Assert.AreEqual(geometricMiddling / arithmeticMean, periodicity.Calculate(uniformChains[0], LinkUp.End));

            intervalsCount = 4;
            geometricMiddling = Math.Pow(interval1*interval2*interval3*interval4, 1/intervalsCount);

            Assert.AreEqual(geometricMiddling / arithmeticMean, periodicity.Calculate(uniformChains[0], LinkUp.Both));
        }

        [Test]
        public void TestCalculationForChain()
        {
            Periodicity periodicity = new Periodicity();

            double length = 10;

            double ElementACount = 4;
            double ElementBCount = 3;
            double ElementCCount = 3;

            double arithmeticMeanA = length/ElementACount;
            double arithmeticMeanB = length/ElementBCount;
            double arithmeticMeanC = length/ElementCCount;

            double D = (arithmeticMeanC+ arithmeticMeanA+ arithmeticMeanB)/3;

            double remoutness11 = 1;
            double remoutness12 = 1;
            double remoutness13 = 4;
            double remoutness14 = 4;
            double remoutness15 = 1;

            double IntervalsACountStart = 4;
            double IntervalsACountEnd = 4;
            double IntervalsACountBoth = 5;

            double remoutness21 = 3;
            double remoutness22 = 1;
            double remoutness23 = 3;
            double remoutness24 = 4;

            double IntervalsBCountStart = 3;
            double IntervalsBCountEnd = 3;
            double IntervalsBCountBoth = 4;


            double remoutness31 = 5;
            double remoutness32 = 3;
            double remoutness33 = 1;
            double remoutness34 = 2;

            double IntervalsCCountStart = 3;
            double IntervalsCCountEnd = 3;
            double IntervalsCCountBoth = 4;

            double intervalsCountStart = IntervalsACountStart + IntervalsBCountStart + IntervalsCCountStart;
            double intervalsCountEnd = IntervalsACountEnd + IntervalsBCountEnd + IntervalsCCountEnd;
            double intervalsCountBoth = IntervalsACountBoth + IntervalsBCountBoth + IntervalsCCountBoth;

            double VStart = remoutness11*remoutness12*remoutness13*remoutness14*
                            remoutness21*remoutness22*remoutness23*
                            remoutness31*remoutness32*remoutness33;

            double VEnd = remoutness12*remoutness13*remoutness14*remoutness15*
                          remoutness22*remoutness23*remoutness24*
                          remoutness32*remoutness33*remoutness34;

            double VBoth = remoutness11*remoutness12*remoutness13*remoutness14*remoutness15*
                           remoutness21*remoutness22*remoutness23*remoutness24*
                           remoutness31*remoutness32*remoutness33*remoutness34;

            double geometricMiddlingStart = Math.Pow(VStart, 1/intervalsCountStart);

            Assert.AreEqual(geometricMiddlingStart / D, periodicity.Calculate(Chains[0], LinkUp.Start));

            double geometricMiddlingEnd = Math.Pow(VEnd, 1/intervalsCountEnd);

            Assert.AreEqual(geometricMiddlingEnd / D, periodicity.Calculate(Chains[0], LinkUp.End));

            double geometricMiddlingBoth = Math.Pow(VBoth, 1/intervalsCountBoth);

            Assert.AreEqual(geometricMiddlingBoth / D, periodicity.Calculate(Chains[0], LinkUp.Both));
        }
    }
}