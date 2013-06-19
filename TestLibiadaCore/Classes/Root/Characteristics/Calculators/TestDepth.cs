using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestDepth : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            Depth calc = new Depth();
            const int interval1 = 4;
            const int interval3 = 3;
            const int interval4 = 3;
            const int interval2 = 1;

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, Math.Log(interval1, 2) + Math.Log(interval3, 2) + Math.Log(interval2, 2));
            TestUniformChainCharacteristic(0, calc, LinkUp.End, Math.Log(interval2, 2) + Math.Log(interval3, 2) + Math.Log(interval4, 2));
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, Math.Log(interval1, 2) + Math.Log(interval3, 2) + Math.Log(interval4, 2) + Math.Log(interval2, 2));
        }

        [Test]
        public void TestChainCalculation()
        {
            Depth calc = new Depth();

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
            double sumEnd = sumAEnd + sumBEnd + subCEnd;
            double sumBoth = sumABoth + sumBBoth + subCBoth;

            TestChainCharacteristic(0, calc, LinkUp.Start, sumStart);
            TestChainCharacteristic(0, calc, LinkUp.End, sumEnd);
            TestChainCharacteristic(0, calc, LinkUp.Both, sumBoth);
        }
    }
}