namespace Libiada.Core.Tests.Extensions;

using Libiada.Core.Extensions;

/// <summary>
/// The array manipulator tests.
/// </summary>
[TestFixture(TestOf = typeof(ArrayExtensions))]
public class ArrayExtensionsTests
{
    /// <summary>
    /// Delete element at position test.
    /// </summary>
    [Test]
    public void DeleteAtIntArrayTest()
    {
        int[] source = [1, 2, 2, 4, 4, 2, 7, 2, 3, 1];

        int[] result = source.DeleteAt(6);
        int[] expected = [1, 2, 2, 4, 4, 2, 2, 3, 1];
        Assert.That(result, Is.EqualTo(expected));

        result = result.DeleteAt(4);
        expected = [1, 2, 2, 4, 2, 2, 3, 1];
        Assert.That(result, Is.EqualTo(expected));

        result = result.DeleteAt(0);
        expected = [2, 2, 4, 2, 2, 3, 1];
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Delete element at position test.
    /// </summary>
    [Test]
    public void DeleteAtTest()
    {
        string[] source = ["test", "a", "a", "test", "test", "b", "1"];

        string[] result = source.DeleteAt(6);
        string[] expected = ["test", "a", "a", "test", "test", "b"];
        Assert.That(result, Is.EqualTo(expected));

        result = result.DeleteAt(4);
        expected = ["test", "a", "a", "test", "b"];
        Assert.That(result, Is.EqualTo(expected));

        result = result.DeleteAt(0);
        expected = ["a", "a", "test", "b"];
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// All indexes of element search test.
    /// </summary>
    [Test]
    public void AllIndexesOfIntArrayTest()
    {
        int[] source = [1, 2, 2, 4, 4, 2, 7, 2, 3, 1];

        int[] expected = [1, 2, 5, 7];
        Assert.That(source.AllIndexesOf(2), Is.EqualTo(expected));

        expected = [6];
        Assert.That(source.AllIndexesOf(7), Is.EqualTo(expected));

        expected = [];
        Assert.That(source.AllIndexesOf(11), Is.EqualTo(expected));
    }

    /// <summary>
    /// All indexes of element search test.
    /// </summary>
    [Test]
    public void AllIndexesOfTest()
    {
        string[] source = ["a", "test", "a", "aa", "test", "test", "c"];

        int[] expected = [0, 2];
        Assert.That(source.AllIndexesOf("a"), Is.EqualTo(expected));

        expected = [6];
        Assert.That(source.AllIndexesOf("c"), Is.EqualTo(expected));

        expected = [1, 4, 5];
        Assert.That(source.AllIndexesOf("test"), Is.EqualTo(expected));

        expected = [];
        Assert.That(source.AllIndexesOf("another test"), Is.EqualTo(expected));
    }

    /// <summary>
    /// Array content to string test.
    /// </summary>
    [Test]
    public void ToStringTest()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        string expected = "1 2 3 4 5 6 7 8 9 10";
        Assert.That(source.ToString(" "), Is.EqualTo(expected));

        expected = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10";
        Assert.That(source.ToString(", "), Is.EqualTo(expected));
    }

    /// <summary>
    /// Array content to string with default delimiter test.
    /// </summary>
    [Test]
    public void ToStringWithDefaultDelimiterTest()
    {
        int[] source = [1, 2, 3];

        string expected = $"1{Environment.NewLine}2{Environment.NewLine}3";
        Assert.That(source.ToStringWithDefaultDelimiter(), Is.EqualTo(expected));
    }

    /// <summary>
    /// Array content to string without delimiter test.
    /// </summary>
    [Test]
    public void ToStringWithoutDelimiterTest()
    {
        int[] source = [1, 2, 3, 2, 2];

        const string expected = "12322";
        Assert.That(source.ToStringWithoutDelimiter(), Is.EqualTo(expected));
    }

    /// <summary>
    /// Array rotation test.
    /// </summary>
    [Test]
    public void RotateTest()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int[] result = source.Rotate(1);
        int[] expected = [2, 3, 4, 5, 6, 7, 8, 9, 10, 1];
        Assert.That(result, Is.EqualTo(expected));

        result = source.Rotate(2);
        expected = [3, 4, 5, 6, 7, 8, 9, 10, 1, 2];
        Assert.That(result, Is.EqualTo(expected));

        result = source.Rotate(10);
        expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Array sorting check test.
    /// </summary>
    [Test]
    public void IsSortedTest()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Assert.Multiple(() =>
        {
            Assert.That(source.IsSorted());
            Assert.That(source.ToList().IsSorted());
        });

        source = [1];
        Assert.Multiple(() =>
        {
            Assert.That(source.IsSorted());
            Assert.That(source.ToList().IsSorted());
        });

        source = [1, 2, 2, 2, 2, 10, 100, 10000];
        Assert.Multiple(() =>
        {
            Assert.That(source.IsSorted());
            Assert.That(source.ToList().IsSorted());
        });

        source = [1, 2, 1, 3, 4, 10];
        Assert.Multiple(() =>
        {
            Assert.That(source.IsSorted(), Is.False);
            Assert.That(source.ToList().IsSorted(), Is.False);
        });
    }

    /// <summary>
    /// The sub-array extraction method test.
    /// </summary>
    [Test]
    public void SubArrayTest()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int[] expected = [1];
        Assert.That(source.SubArray(0, 1), Is.EqualTo(expected));
        expected = [1, 2];
        Assert.That(source.SubArray(0, 2), Is.EqualTo(expected));
        expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Assert.That(source.SubArray(0, 10), Is.EqualTo(expected));
        expected = [2];
        Assert.That(source.SubArray(1, 1), Is.EqualTo(expected));
        expected = [2, 3, 4, 5, 6, 7, 8, 9, 10];
        Assert.That(source.SubArray(1, 9), Is.EqualTo(expected));
    }
}
