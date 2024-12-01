namespace Libiada.SequenceGenerator.Tests;

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
        OrderIterator iterator = new(3, 2);
        for (int i = 0; i < iterations; i++)
        {
            iterator.IterateOrderCounter();
        }

        int[] actual = iterator.Iterator;
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// The enumerator test.
    /// </summary>
    [Test]
    public void EnumeratorTest()
    {
        OrderIterator iterator = new(3, 2);
        int[][] expected =
        [
            [1, 1, 1],
            [1, 1, 2],
            [1, 2, 1],
            [1, 2, 2]
        ];

        int i = 0;
        foreach (var actual in iterator)
        {
            Assert.That(actual, Is.EqualTo(expected[i]));
            i++;
        }

        Assert.That(i, Is.EqualTo(expected.Length));
    }
}
