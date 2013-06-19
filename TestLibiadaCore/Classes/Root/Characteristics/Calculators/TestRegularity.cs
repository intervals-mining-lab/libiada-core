using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestRegularity : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            Regularity calc = new Regularity();

            double Length = 10;
            double ElementCount = 3;
            double arithmeticMean = Length/ElementCount;
            double p1 = 1 - 1/arithmeticMean;
            double a1 = 1/p1;
            double d = Math.Pow(arithmeticMean, 1 / arithmeticMean) * Math.Pow(a1, p1);

            int Interval1 = 4;
            int Interval2 = 1;
            int Interval3 = 3;
            int Interval4 = 3;

            double intervalsCount = 3;
            double geometricMiddling = Math.Pow(Interval1*Interval2*Interval3, 1/intervalsCount);
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, geometricMiddling / d);

            intervalsCount = 3;
            geometricMiddling = Math.Pow(Interval2*Interval3*Interval4, 1/intervalsCount);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, geometricMiddling / d);

            intervalsCount = 4;
            geometricMiddling = Math.Pow(Interval1*Interval2*Interval3*Interval4, 1/intervalsCount);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, geometricMiddling / d);
        }

        [Test]
        public void TestChainCalculation()
        {
            Regularity calc = new Regularity();

            double Length = 10;

            double ElementACount = 4;
            double ElementBCount = 3;
            double ElementCCount = 3;

            double ArithmeticMeanA = Length/ElementACount;
            double ArithmeticMeanB = Length/ElementBCount;
            double ArithmeticMeanC = Length/ElementCCount;


            double PropabilityA = ElementACount/Length;
            double PropabilityB = ElementBCount/Length;
            double PropabilityC = ElementCCount/Length;

            double DA = Math.Pow(ArithmeticMeanA, PropabilityA);
            double DB = Math.Pow(ArithmeticMeanB, PropabilityB);
            double DC = Math.Pow(ArithmeticMeanC, PropabilityC);

            double D = DA*DB*DC;

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

            double IntervalsCountStart = IntervalsACountStart + IntervalsBCountStart + IntervalsCCountStart;
            double IntervalsCountEnd = IntervalsACountEnd + IntervalsBCountEnd + IntervalsCCountEnd;
            double IntervalsCountBoth = IntervalsACountBoth + IntervalsBCountBoth + IntervalsCCountBoth;

            double VStart = remoutness11*remoutness12*remoutness13*remoutness14*
                            remoutness21*remoutness22*remoutness23*
                            remoutness31*remoutness32*remoutness33;

            double VEnd = remoutness12*remoutness13*remoutness14*remoutness15*
                          remoutness22*remoutness23*remoutness24*
                          remoutness32*remoutness33*remoutness34;

            double VBoth = remoutness11*remoutness12*remoutness13*remoutness14*remoutness15*
                           remoutness21*remoutness22*remoutness23*remoutness24*
                           remoutness31*remoutness32*remoutness33*remoutness34;

            double geometricMiddlingStart = Math.Pow(VStart, 1/IntervalsCountStart);
            double geometricMiddlingEnd = Math.Pow(VEnd, 1/IntervalsCountEnd);
            double geometricMiddlingBoth = Math.Pow(VBoth, 1/IntervalsCountBoth);

            TestChainCharacteristic(0, calc, LinkUp.Start, geometricMiddlingStart / D);
            TestChainCharacteristic(0, calc, LinkUp.End, geometricMiddlingEnd / D);
            TestChainCharacteristic(0, calc, LinkUp.Both, geometricMiddlingBoth / D);
        }
    }
}