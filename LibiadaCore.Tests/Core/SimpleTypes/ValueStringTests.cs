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
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringValueTest()
        {
            new ValueString(null);
        }

        /// <summary>
        /// The empty string value test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStringValueTest()
        {
            new ValueString(string.Empty);
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
