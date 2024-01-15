namespace Libiada.SequenceGenerator.Tests;

using NUnit.Framework;

/// <summary>
/// The order iterator tests.
/// </summary>
[TestFixture]
public class OrderIteratorTests
{
    /// <summary>
    /// The iterator test.
    /// </summary>
    /// <param name="expected">
    /// The expected.
    /// </param>
    /// <param name="iterations">
    /// The iterations.
    /// </param>
    [TestCase(new[] { 1, 1, 1 }, 0)]
    [TestCase(new[] { 1, 1, 2 }, 1)]
    [TestCase(new[] { 1, 2, 1 }, 2)]
    [TestCase(new[] { 1, 2, 2 }, 3)]
    public void IteratorTest(int[] expected, int iterations)
    {
        var iterator = new OrderIterator(3, 2);
        for (int i = 0; i < iterations; i++)
        {
            iterator.IterateOrderCounter();
        }

        int[] actual = iterator.Iterator;
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// The enumerator test.
    /// </summary>
    [Test]
    public void EnumeratorTest()
    {
        var iterator = new OrderIterator(3, 2);
        var expected = new[]
        {
            new[] { 1, 1, 1 },
            new[] { 1, 1, 2 },
            new[] { 1, 2, 1 },
            new[] { 1, 2, 2 }
        };

        int i = 0;
        foreach (var actual in iterator)
        {
            Assert.AreEqual(expected[i], actual);
            i++;
        }

        Assert.AreEqual(expected.Length, i);
    }
}
