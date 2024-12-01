namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.DataTransformers;

[TestFixture]
public class PermutationGeneratorTests
{
    private static readonly int[][] Expected1 =
    [
        [0, 1],
        [1, 0],
    ];

    private static readonly int[][] Expected2 =
    [
        [0, 1, 2],
        [0, 2, 1],
        [1, 0, 2],
        [1, 2, 0],
        [2, 0, 1],
        [2, 1, 0],
    ];

    [Test]
    public void GetOrdersForTwoElementsTest()
    {
        int[][] result = PermutationGenerator.GetOrders(2);

        Assert.That(result, Has.Length.EqualTo(Expected1.Length));
        for (int i = 0; i < Expected1.Length; i++)
        {
            int[] expected = Expected1[i];
            Assert.That(result[i], Has.Length.EqualTo(expected.Length));
            for (int j = 0; j < expected.Length; j++)
            {
                Assert.That(result[i].SequenceEqual(expected));
            }
        }
    }

    [Test]
    public void GetOrdersForThreeElementsTest()
    {
        int[][] result = PermutationGenerator.GetOrders(3);
        Assert.That(result, Has.Length.EqualTo(Expected2.Length));
        for (int i = 0; i < Expected2.Length; i++)
        {
            int[] expected = Expected2[i];
            Assert.That(result[i], Has.Length.EqualTo(expected.Length));
            for (int j = 0; j < expected.Length; j++)
            {
                Assert.That(result[i].SequenceEqual(expected));
            }
        }
    }
}
