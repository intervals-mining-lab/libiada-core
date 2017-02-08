namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The cut length vocabulary entropy test.
    /// </summary>
    [TestFixture]
    public class CuttingLengthVocabularyEntropyTests : FullCalculatorsTests
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 3)]
        [TestCase(0, Link.Cycle, 3)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
