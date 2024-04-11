namespace Libiada.SequenceGenerator.Tests;

/// <summary>
/// The order generator tests.
/// </summary>
[TestFixture]
public class OrderGeneratorTests
{
    /// <summary>
    /// The generator test.
    /// </summary>
    [Test]
    public void GeneratorTest()
    {
        List<int[]> expected =
        [
            [1, 1, 1],
            [1, 1, 2],
            [1, 2, 1],
            [1, 2, 2]
        ];

        OrderGenerator orderGenerator = new();
        List<int[]> actual = orderGenerator.GenerateOrders(3, 2);
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// The complete generator test.
    /// </summary>
    [Test]
    public void CompleteGeneratorTest()
    {
        List<int[]> expected =
        [
            [1, 1, 1],
            [1, 1, 2],
            [1, 2, 1],
            [1, 2, 2],
            [1, 2, 3]
        ];

        OrderGenerator orderGenerator = new();
        List<int[]> actual = orderGenerator.GenerateOrders(3);
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// The strict generator test.
    /// </summary>
    [Test]
    public void StrictGeneratorTest()
    {
        List<int[]> expected =
        [
            [1, 1, 2, 3],
            [1, 2, 1, 3],
            [1, 2, 2, 3],
            [1, 2, 3, 1],
            [1, 2, 3, 2],
            [1, 2, 3, 3]
        ];

        OrderGenerator orderGenerator = new();
        List<int[]> actual = orderGenerator.StrictGenerateOrders(4, 3);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void OrderValid()
    {
        const int expectedLength = 4;
        const int expectedAlphabetCardinality = 3;
        OrderGenerator orderGenerator = new();
        List<int[]> actual = orderGenerator.StrictGenerateOrders(expectedLength, expectedAlphabetCardinality);
        Assert.That(actual.TrueForAll(o => o.Length == expectedLength),"Invalid length");
        Assert.That(actual.TrueForAll(o => o.Max() == expectedAlphabetCardinality), "Invlaid alphabet cardinality");
        foreach (int[] order in actual)
        {
            int currentMax = 1;
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] > currentMax)
                {
                    Assert.Fail("Invalid order");
                }
                else if (order[i] == currentMax)
                {
                    currentMax++;
                }
            }
        }
    }
}
