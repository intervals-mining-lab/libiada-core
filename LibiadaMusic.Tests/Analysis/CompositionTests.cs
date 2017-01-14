namespace LibiadaMusic.Tests.Analysis
{
    using LibiadaMusic.Analysis;

    using NUnit.Framework;

    /// <summary>
    /// The composition tests.
    /// </summary>
    [TestFixture]
    public class CompositionTests
    {
        /// <summary>
        /// The composition test.
        /// </summary>
        [Test]
        public void CompositionTest()
        {
            var com = new Composition();
            double e = 0.3;
            Assert.AreNotEqual(e, com.Entropy);
        }
    }
}
