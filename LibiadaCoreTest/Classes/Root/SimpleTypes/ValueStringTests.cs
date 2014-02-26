namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The value string test.
    /// </summary>
    [TestFixture]
    public class ValueStringTests
    {
        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            Assert.AreEqual(new ValueString("1"), new ValueString("1"));
        }
    }
}