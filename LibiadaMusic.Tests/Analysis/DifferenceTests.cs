namespace LibiadaMusic.Tests.Analysis
{
    using LibiadaMusic.Analysis;

    using NUnit.Framework;

    /// <summary>
    /// The difference tests.
    /// </summary>
    [TestFixture]
    public class DifferenceTests
    {
        /// <summary>
        /// The difference test.
        /// </summary>
        [Test]
        public void DifferenceTest()
        {
            var dif1 = new Difference();
            var dif2 = new Difference();
            Assert.AreEqual(dif1.D, dif2.D);
        }
    }
}
