namespace LibiadaCore.Tests.Core
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The abstract chain tests.
    /// </summary>
    [TestFixture]
    public class AbstractChainTests
    {
        /// <summary>
        /// The to string test.
        /// </summary>
        [Test]
        public void ToStringTest()
        {
            var stringExpected = "abcabccc";
            var chain = new Chain(stringExpected);
            Assert.AreEqual(stringExpected, chain.ToString());
            var baseChain = new BaseChain(stringExpected);
            Assert.AreEqual(stringExpected, baseChain.ToString());
        }

        /// <summary>
        /// The to string delimiter test.
        /// </summary>
        [Test]
        public void ToStringDelimiterTest()
        {
            var source = "abcabccc";
            var chain = new Chain(source);
            var baseChain = new BaseChain(source);

            var expected = "a b c a b c c c";
            Assert.AreEqual(expected, chain.ToString(" "));
            Assert.AreEqual(expected, baseChain.ToString(" "));

            expected = "acbcccacbcccccc";
            Assert.AreEqual(expected, chain.ToString("c"));
            Assert.AreEqual(expected, baseChain.ToString("c"));
        }

        /// <summary>
        /// The to string long delimiter test.
        /// </summary>
        [Test]
        public void ToStringLongDelimiterTest()
        {
            var source = "abcabccc";
            var chain = new Chain(source);
            var baseChain = new BaseChain(source);

            var expected = "a - b - c - a - b - c - c - c";
            Assert.AreEqual(expected, chain.ToString(" - "));
            Assert.AreEqual(expected, baseChain.ToString(" - "));

            expected = "a, b, c, a, b, c, c, c";
            Assert.AreEqual(expected, chain.ToString(", "));
            Assert.AreEqual(expected, baseChain.ToString(", "));
        }
    }
}
