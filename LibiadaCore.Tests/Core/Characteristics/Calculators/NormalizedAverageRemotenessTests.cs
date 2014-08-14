namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The normalized average remoteness test.
    /// </summary>
    [TestFixture]
    public class NormalizedAverageRemotenessTests : CalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("NormalizedAverageRemoteness");
        }

        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        [Test]
        public void CongenericCalculationTest()
        {
            double interval1 = 4;
            double interval2 = 1;
            double interval3 = 3;
            double interval4 = 3;

            double pIntervalsCount = 3;
            double deltaG = Math.Pow(interval1 * interval2 * interval3, 1 / pIntervalsCount);
            double pAverageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.Start, pAverageRemoteness);

            pIntervalsCount = 3;
            deltaG = Math.Pow(interval2 * interval3 * interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.End, pAverageRemoteness);

            pIntervalsCount = 4;
            deltaG = Math.Pow(interval1 * interval2 * interval3 * interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.Both, pAverageRemoteness);
        }
    }
}