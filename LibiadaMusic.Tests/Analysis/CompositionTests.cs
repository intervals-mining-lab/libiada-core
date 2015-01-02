namespace LibiadaMusic.Tests.Analysis
{
    using LibiadaMusic.Analysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The composition tests.
    /// </summary>
    [TestClass]
    public class CompositionTests
    {
        /// <summary>
        /// The composition test.
        /// </summary>
        [TestMethod]
        public void CompositionTest()
        {
            var com = new Composition();
            double e = 0.3;
            Assert.AreNotEqual(e, com.Entropy);
        }
    }
}
