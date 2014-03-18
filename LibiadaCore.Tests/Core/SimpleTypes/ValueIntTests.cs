namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The value integer test.
    /// </summary>
    [TestFixture]
    public class ValueIntTests
    {
        /// <summary>
        /// The sum test.
        /// </summary>
        [Test]
        public void SumTest()
        {
            int x = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4, x);
            ValueInt y = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4, y);
        }
    }
}