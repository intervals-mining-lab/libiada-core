namespace Libiada.Core.Tests.Extensions;

using Libiada.Core.Extensions;

/// <summary>
/// The enum extensions tests.
/// </summary>
[TestFixture]
public class EnumExtensionsTests
{
    /// <summary>
    /// The test enum.
    /// </summary>
    private enum TestEnum : byte
    {
        /// <summary>
        /// The first.
        /// </summary>
        First = 1,

        /// <summary>
        /// The second.
        /// </summary>
        Second = 2,

        /// <summary>
        /// The third.
        /// </summary>
        Third = 3
    }

    /// <summary>
    /// Test for ToArray method.
    /// </summary>
    [Test]
    public void ToArrayTest()
    {
        TestEnum[] actual = EnumExtensions.ToArray<TestEnum>();
        var expected = new[] { TestEnum.First, TestEnum.Second, TestEnum.Third };

        Assert.AreEqual(expected, actual);
    }
}