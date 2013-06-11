using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestGeometricMean
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainsForTests mother = new ChainsForTests();
            TestUChain = mother.TestUniformChain();
            TestChain = mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            GeometricMean geometricMean = new GeometricMean();

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

            double multiplicatedIntervalsStart = remoutness11*remoutness12*remoutness13*remoutness14*
                                                 remoutness21*remoutness22*remoutness23*remoutness31*remoutness32*
                                                 remoutness33;

            int intervalsCountStart = 10;
            double dGTheoreticalStart = Math.Pow(multiplicatedIntervalsStart, ((double) 1)/intervalsCountStart);

            Assert.AreEqual(dGTheoreticalStart, geometricMean.Calculate(TestChain, LinkUp.Start));

            double multiplicatedIntervalsEnd = remoutness12*remoutness13*remoutness14*remoutness15*
                                               remoutness22*remoutness23*remoutness24*remoutness32*remoutness33*
                                               remoutness34;

            int intervalsCountEnd = 10;
            double dGTheoreticalEnd = Math.Pow(multiplicatedIntervalsEnd, ((double) 1)/intervalsCountEnd);

            Assert.AreEqual(dGTheoreticalEnd, geometricMean.Calculate(TestChain, LinkUp.End));


            double multiplicatedIntervalsBoth = remoutness11*remoutness12*remoutness13*remoutness14*remoutness15*
                                                remoutness21*remoutness22*remoutness23*remoutness24*remoutness31*
                                                remoutness32*remoutness33*remoutness34;

            int intervalsCountBoth = 13;
            double dGTheoreticalBoth = Math.Pow(multiplicatedIntervalsBoth, ((double) 1)/intervalsCountBoth);

            Assert.AreEqual(dGTheoreticalBoth, geometricMean.Calculate(TestChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForUniformChain()
        {
            GeometricMean geometricMean = new GeometricMean();
            Depth depth = new Depth();
            IntervalsCount intervalsCountCalc = new IntervalsCount();

            const int interval1 = 4;
            const int interval2 = 1;
            const int interval3 = 3;
            const int interval4 = 3;

            double V = interval1*interval2*interval3*interval4;
            double intervalsCount = ((double) 1)/4;
            Assert.AreEqual(Math.Pow(V, intervalsCount), geometricMean.Calculate(TestUChain, LinkUp.Both));

            Assert.AreEqual(Math.Pow(2, depth.Calculate(TestUChain, LinkUp.Both) / intervalsCountCalc.Calculate(TestUChain, LinkUp.Both)),
                            geometricMean.Calculate(TestUChain, LinkUp.Both));

            V = interval1*interval2*interval3;
            intervalsCount = ((double) 1)/3;
            Assert.AreEqual(Math.Pow(V, intervalsCount), geometricMean.Calculate(TestUChain, LinkUp.Start));

            Assert.AreEqual(Math.Pow(2, depth.Calculate(TestUChain, LinkUp.Start) / intervalsCountCalc.Calculate(TestUChain, LinkUp.Start)),
                            geometricMean.Calculate(TestUChain, LinkUp.Start));

            V = interval2*interval3*interval4;
            intervalsCount = ((double) 1)/3;
            Assert.AreEqual(Math.Pow(V, intervalsCount), geometricMean.Calculate(TestUChain, LinkUp.End));

            Assert.AreEqual(Math.Pow(2, depth.Calculate(TestUChain, LinkUp.End) / intervalsCountCalc.Calculate(TestUChain, LinkUp.End)),
                            geometricMean.Calculate(TestUChain, LinkUp.End));
        }
    }
}