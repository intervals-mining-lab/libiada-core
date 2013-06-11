using System;
using LibiadaCore.Classes.Root;
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
        public void Init()
        {
            ChainsForTests mother = new ChainsForTests();
            TestUChain = mother.TestUniformChain();
            TestChain = mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            AverageRemoteness averageRemoteness = new AverageRemoteness();

            double interval1 = 4;
            double interval2 = 1;
            double interval3 = 3;
            double interval4 = 3;

            double pIntervalsCount = 3;

            double deltaG = Math.Pow(interval1*interval2*interval3, 1/pIntervalsCount);
            double pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, averageRemoteness.Calculate(TestUChain, LinkUp.Start));


            pIntervalsCount = 3;

            deltaG = Math.Pow(interval2*interval3*interval4, 1/pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, averageRemoteness.Calculate(TestUChain, LinkUp.End));


            pIntervalsCount = 4;

            deltaG = Math.Pow(interval1*interval2*interval3*interval4, 1/pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, averageRemoteness.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            AverageRemoteness averageRemoteness = new AverageRemoteness();

            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alphabet.Power);


            double remoutness11 = Math.Log(1, 2);
            double remoutness12 = Math.Log(1, 2);
            double remoutness13 = Math.Log(4, 2);
            double remoutness14 = Math.Log(4, 2);
            double remoutness15 = Math.Log(1, 2);

            double sumAStart = remoutness11 + remoutness12 + remoutness13 + remoutness14;
            double sumAEnd = remoutness12 + remoutness13 + remoutness14 + remoutness15;
            double sumABoth = remoutness11 + remoutness12 + remoutness13 + remoutness14 + remoutness15;

            double remoutness21 = Math.Log(3, 2);
            double remoutness22 = Math.Log(1, 2);
            double remoutness23 = Math.Log(3, 2);
            double remoutness24 = Math.Log(4, 2);

            double sumBStart = remoutness21 + remoutness22 + remoutness23;
            double sumBEnd = remoutness22 + remoutness23 + remoutness24;
            double sumBBoth = remoutness21 + remoutness22 + remoutness23 + remoutness24;

            double remoutness31 = Math.Log(5, 2);
            double remoutness32 = Math.Log(3, 2);
            double remoutness33 = Math.Log(1, 2);
            double remoutness34 = Math.Log(2, 2);

            double subCStart = remoutness31 + remoutness32 + remoutness33;
            double subCEnd = remoutness32 + remoutness33 + remoutness34;
            double subCBoth = remoutness31 + remoutness32 + remoutness33 + remoutness34;

            double sumStart = sumAStart + sumBStart + subCStart;
            double n = 10;

            Assert.AreEqual(sumStart / n, averageRemoteness.Calculate(TestChain, LinkUp.Start));

            double sumEnd = sumAEnd + sumBEnd + subCEnd;
            Assert.AreEqual(sumEnd / n, averageRemoteness.Calculate(TestChain, LinkUp.End));

            double nBoth = 13;
            double sumBoth = sumABoth + sumBBoth + subCBoth;
            Assert.AreEqual(sumBoth / nBoth, averageRemoteness.Calculate(TestChain, LinkUp.Both));
        }
    }
}