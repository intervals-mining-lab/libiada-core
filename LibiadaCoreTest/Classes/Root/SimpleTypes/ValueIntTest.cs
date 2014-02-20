namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// </summary>
    [TestFixture]
    public class ValueIntTest
    {
        /// <summary>
        /// </summary>
        [Test]
        public void SumTest()
        {
            int x = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4,x);
            ValueInt y = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4,y);
        }
    }
}