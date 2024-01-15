namespace Libiada.SequenceGenerator.Tests;

/// <summary>
/// The sequence iterator tests.
/// </summary>
[TestFixture]
public class SequenceIteratorTests
{
    /// <summary>
    /// The iterator test.
    /// </summary>
    /// <param name="expected">
    /// The expected order.
    /// </param>
    /// <param name="iterations">
    /// The iterations count.
    /// </param>
    [TestCase(new[] { 1, 1, 1 }, 0)]
    [TestCase(new[] { 2, 1, 1 }, 1)]
    [TestCase(new[] { 1, 2, 1 }, 2)]
    [TestCase(new[] { 2, 2, 1 }, 3)]
    [TestCase(new[] { 1, 1, 2 }, 4)]
    [TestCase(new[] { 2, 1, 2 }, 5)]
    [TestCase(new[] { 1, 2, 2 }, 6)]
    [TestCase(new[] { 2, 2, 2 }, 7)]
    public void IteratorTest(int[] expected, int iterations)
    {
        var iterator = new SequenceIterator(3, 2);
        for (int i = 0; i < iterations; i++)
        {
            iterator.IterateSequencesCounter();
        }

        var actual = iterator.Iterator;
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// The enumerator test.
    /// </summary>
    [Test]
    public void EnumeratorTest()
    {
        var iterator = new SequenceIterator(3, 2);
        int[][] expected =
        {
            new[] { 1, 1, 1 },
            new[] { 2, 1, 1 },
            new[] { 1, 2, 1 },
            new[] { 2, 2, 1 },
            new[] { 1, 1, 2 },
            new[] { 2, 1, 2 },
            new[] { 1, 2, 2 },
            new[] { 2, 2, 2 }
        };
        int i = 0;

        foreach (int[] actual in iterator)
        {
            Assert.AreEqual(expected[i], actual);
            i++;
        }
    }
}
