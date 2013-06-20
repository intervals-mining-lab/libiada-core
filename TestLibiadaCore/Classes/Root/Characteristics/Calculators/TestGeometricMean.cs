using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestGeometricMean : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            GeometricMean calc = new GeometricMean();
            Depth depth = new Depth();
            IntervalsCount intervalsCountCalc = new IntervalsCount();

            const int interval1 = 4;
            const int interval2 = 1;
            const int interval3 = 3;
            const int interval4 = 3;

            double V = interval1 * interval2 * interval3;
            double intervalsCount = ((double)1) / 3;
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, Math.Pow(V, intervalsCount));
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, Math.Pow(2, depth.Calculate(UniformChains[0], LinkUp.Start) / intervalsCountCalc.Calculate(UniformChains[0], LinkUp.Start)));
            
            V = interval2*interval3*interval4;
            intervalsCount = ((double) 1)/3;
            TestUniformChainCharacteristic(0, calc, LinkUp.End, Math.Pow(V, intervalsCount));
            TestUniformChainCharacteristic(0, calc, LinkUp.End, Math.Pow(2, depth.Calculate(UniformChains[0], LinkUp.End) / intervalsCountCalc.Calculate(UniformChains[0], LinkUp.End)));

            V = interval1*interval2*interval3*interval4;
            intervalsCount = ((double) 1)/4;
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, Math.Pow(V, intervalsCount));
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, Math.Pow(2, depth.Calculate(UniformChains[0], LinkUp.Both) / intervalsCountCalc.Calculate(UniformChains[0], LinkUp.Both)));
        }

        [Test]
        public void TestChainCalculation()
        {
            GeometricMean calc = new GeometricMean();

            double remoutness11 = 1;
            double remoutness12 = 1;
            double remoutness13 = 4;
            double remoutness14 = 4;
            double remoutness15 = 1;

            double remoutness21 = 3;
            double remoutness22 = 1;
            double remoutness23 = 3;
            double remoutness24 = 4;

            double remoutness31 = 5;
            double remoutness32 = 3;
            double remoutness33 = 1;
            double remoutness34 = 2;

            double multiplicatedIntervalsStart = remoutness11 * remoutness12 * remoutness13 * remoutness14 *
                                                 remoutness21 * remoutness22 * remoutness23 * remoutness31 * remoutness32 *
                                                 remoutness33;
            int intervalsCountStart = 10;
            double dGTheoreticalStart = Math.Pow(multiplicatedIntervalsStart, ((double)1) / intervalsCountStart);
            TestChainCharacteristic(0, calc, LinkUp.Start, dGTheoreticalStart);

            double multiplicatedIntervalsEnd = remoutness12 * remoutness13 * remoutness14 * remoutness15 *
                                               remoutness22 * remoutness23 * remoutness24 * remoutness32 * remoutness33 *
                                               remoutness34;
            int intervalsCountEnd = 10;
            double dGTheoreticalEnd = Math.Pow(multiplicatedIntervalsEnd, ((double)1) / intervalsCountEnd);
            TestChainCharacteristic(0, calc, LinkUp.End, dGTheoreticalEnd);

            double multiplicatedIntervalsBoth = remoutness11 * remoutness12 * remoutness13 * remoutness14 * remoutness15 *
                                                remoutness21 * remoutness22 * remoutness23 * remoutness24 * remoutness31 *
                                                remoutness32 * remoutness33 * remoutness34;
            int intervalsCountBoth = 13;
            double dGTheoreticalBoth = Math.Pow(multiplicatedIntervalsBoth, ((double)1) / intervalsCountBoth);
            TestChainCharacteristic(0, calc, LinkUp.Both, dGTheoreticalBoth);
        }
    }
}