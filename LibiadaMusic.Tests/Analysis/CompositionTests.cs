namespace LibiadaMusic.Tests.Analysis
{
    using LibiadaMusic.Analysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompositionTests
    {
        [TestMethod]
        public void CompositionTest()
        {
            var com = new Composition();
            double e = 0.3;
            Assert.AreNotEqual(e, com.Entropy);
        }
    }
}
