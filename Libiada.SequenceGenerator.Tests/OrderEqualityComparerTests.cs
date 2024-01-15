namespace Libiada.SequenceGenerator.Tests;

using NUnit.Framework;

/// <summary>
/// The order equality comparer tests.
/// </summary>
[TestFixture]
public class OrderEqualityComparerTests
{
    /// <summary>
    /// The equals test.
    /// </summary>
    /// <param name="first">
    /// The first.
    /// </param>
    /// <param name="second">
    /// The second.
    /// </param>
    /// <param name="expected">
    /// The expected.
    /// </param>
    [TestCase(new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, true)]
    [TestCase(new[] { 2, 1, 1 }, new[] { 1, 1, 1 }, false)]
    [TestCase(new[] { 1, 2, 1 }, new[] { 1, 2, 1 }, true)]
    [TestCase(new[] { 2, 2, 1 }, new[] { 1, 2, 1 }, false)]
    [TestCase(new[] { 1, 1, 2 }, new[] { 2, 2, 1 }, false)]
    [TestCase(new[] { 2, 1, 2 }, new[] { 2, 2, 1 }, false)]
    [TestCase(new[] { 1, 2, 2 }, new[] { 1, 2, 2 }, true)]
    [TestCase(new[] { 2, 2, 2 }, new[] { 1, 2, 2 }, false)]
    public void EqualsTest(int[] first, int[] second, bool expected)
    {
        var comparer = new OrderEqualityComparer();
        var actual = comparer.Equals(first, second);
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// GetHashCode test.
    /// </summary>
    /// <param name="obj">
    /// The obj.
    /// </param>
    /// <param name="expected">
    /// The expected.
    /// </param>
    [TestCase(new[] { 1, 1, 1 }, 207392)]
    [TestCase(new[] { 2, 1, 1 }, 207921)]
    [TestCase(new[] { 1, 2, 1 }, 207415)]
    [TestCase(new[] { 2, 2, 1 }, 207944)]
    [TestCase(new[] { 1, 1, 2 }, 207393)]
    [TestCase(new[] { 2, 1, 2 }, 207922)]
    [TestCase(new[] { 1, 2, 2 }, 207416)]
    [TestCase(new[] { 2, 2, 2 }, 207945)]
    public void GetHashCodeTest(int[] obj, int expected)
    {
        var comparer = new OrderEqualityComparer();
        var actual = comparer.GetHashCode(obj);
        Assert.AreEqual(expected, actual);
    }
}
