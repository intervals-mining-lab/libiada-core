namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using System;

    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The value string test.
    /// </summary>
    [TestFixture]
    public class ValueStringTests
    {
        /// <summary>
        /// The null string value test.
        /// </summary>
        [Test]
        public void NullStringValueTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new ValueString(null));
        }

        /// <summary>
        /// The empty string value test.
        /// </summary>
        [Test]
        public void EmptyStringValueTest()
        {
            Assert.Throws(typeof(ArgumentException), () => new ValueString(string.Empty));
        }

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
