namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core;

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

            double intervalsCount = 3;
            double deltaG = Math.Pow(interval1 * interval2 * interval3, 1 / intervalsCount);
            double averageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.Start, averageRemoteness);

            intervalsCount = 3;
            deltaG = Math.Pow(interval2 * interval3 * interval4, 1 / intervalsCount);
            averageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.End, averageRemoteness);

            intervalsCount = 4;
            deltaG = Math.Pow(interval1 * interval2 * interval3 * interval4, 1 / intervalsCount);
            averageRemoteness = Math.Log(deltaG, 2);
            CongenericChainCharacteristicTest(0, Link.Both, averageRemoteness);
        }
    }
}
