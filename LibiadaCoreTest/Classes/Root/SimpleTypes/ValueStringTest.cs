namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// </summary>
    [TestFixture]
    public class ValueStringTest
    {
        /// <summary>
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            Assert.AreEqual(new ValueString("1"), new ValueString("1"));
        }
    }


}