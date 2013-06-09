using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestAverageRemoteness
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Characteristic ARemoteness = new Characteristic(new AverageRemoteness());

            double Interval1 = 4;
            double Interval2 = 1;
            double Interval3 = 3;
            double Interval4 = 3;

            double pIntervalsCount = 3;

            double deltaG = Math.Pow(Interval1*Interval2*Interval3, 1/pIntervalsCount);
            double pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.Start));


            pIntervalsCount = 3;

            deltaG = Math.Pow(Interval2*Interval3*Interval4, 1/pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.End));


            pIntervalsCount = 4;

            deltaG = Math.Pow(Interval1*Interval2*Interval3*Interval4, 1/pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        public void TestCalculationForChain()
        {
            Characteristic ARemoteness = new Characteristic(new AverageRemoteness());

            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alphabet.Power);


            double remoutness11 = Math.Log(1, 2);
            double remoutness12 = Math.Log(1, 2);
            double remoutness13 = Math.Log(4, 2);
            double remoutness14 = Math.Log(4, 2);
            double remoutness15 = Math.Log(1, 2);

            double SumAStart = remoutness11 + remoutness12 + remoutness13 + remoutness14;
            double SumAEnd = remoutness12 + remoutness13 + remoutness14 + remoutness15;
            double SumABoth = remoutness11 + remoutness12 + remoutness13 + remoutness14 + remoutness15;

            double remoutness21 = Math.Log(3, 2);
            double remoutness22 = Math.Log(1, 2);
            double remoutness23 = Math.Log(3, 2);
            double remoutness24 = Math.Log(4, 2);

            double SumBStart = remoutness21 + remoutness22 + remoutness23;
            double SumBEnd = remoutness22 + remoutness23 + remoutness24;
            double SumBBoth = remoutness21 + remoutness22 + remoutness23 + remoutness24;

            double remoutness31 = Math.Log(5, 2);
            double remoutness32 = Math.Log(3, 2);
            double remoutness33 = Math.Log(1, 2);
            double remoutness34 = Math.Log(2, 2);

            double SubCStart = remoutness31 + remoutness32 + remoutness33;
            double SubCEnd = remoutness32 + remoutness33 + remoutness34;
            double SubCBoth = remoutness31 + remoutness32 + remoutness33 + remoutness34;

            double SumStart = SumAStart + SumBStart + SubCStart;
            double n = 10;

            Assert.AreEqual(SumStart/n, ARemoteness.Value(TestChain, LinkUp.Start));

            double SumEnd = SumAEnd + SumBEnd + SubCEnd;
            Assert.AreEqual(SumEnd/n, ARemoteness.Value(TestChain, LinkUp.End));

            double nBoth = 13;
            double SumBoth = SumABoth + SumBBoth + SubCBoth;
            Assert.AreEqual(SumBoth/nBoth, ARemoteness.Value(TestChain, LinkUp.Both));
        }
    }
}