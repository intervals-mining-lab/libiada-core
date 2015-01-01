namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The null value test.
    /// </summary>
    [TestFixture]
    public class NullValueTests
    {
        /// <summary>
        /// The instance not null test.
        /// </summary>
        [Test]
        public void InstanceNotNullTest()
        {
            Assert.IsNotNull(NullValue.Instance());
        }

        /// <summary>
        /// The instance single tone test.
        /// </summary>
        [Test]
        public void InstanceSingleToneTest()
        {
            Assert.AreSame(NullValue.Instance(), NullValue.Instance());
        }
    }
}
