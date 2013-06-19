using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestNormalizedAverageRemoteness : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            NormalizedAverageRemoteness normalizedAverageRemoteness = new NormalizedAverageRemoteness();

            double interval1 = 4;
            double interval2 = 1;
            double interval3 = 3;
            double interval4 = 3;

            double pIntervalsCount = 3;

            double deltaG = Math.Pow(interval1 * interval2 * interval3, 1 / pIntervalsCount);
            double pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, normalizedAverageRemoteness.Calculate(uniformChains[0], LinkUp.Start));


            pIntervalsCount = 3;

            deltaG = Math.Pow(interval2 * interval3 * interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, normalizedAverageRemoteness.Calculate(uniformChains[0], LinkUp.End));


            pIntervalsCount = 4;

            deltaG = Math.Pow(interval1 * interval2 * interval3 * interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, normalizedAverageRemoteness.Calculate(uniformChains[0], LinkUp.Both));
        }
    }
}