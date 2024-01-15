namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.DataTransformers;

[TestFixture]
public class PermutationGeneratorTests
{
    private static readonly int[][] Expected1 =
    {
        new int[] { 0, 1 },
        new int[] { 1, 0 },
    };

    private static readonly int[][] Expected2 =
    {
        new int[] { 0, 1, 2 },
        new int[] { 0, 2, 1 },
        new int[] { 1, 0, 2 },
        new int[] { 1, 2, 0 },
        new int[] { 2, 0, 1 },
        new int[] { 2, 1, 0 },
    };

    [Test]
    public void GetOrdersForTwoElementsTest()
    {
        var result = PermutationGenerator.GetOrders(2);

        Assert.That(result.Length, Is.EqualTo(Expected1.Length));
        for (int i = 0; i < Expected1.Length; i++)
        {
            var expected = Expected1[i];
            Assert.That(result[i].Length, Is.EqualTo(expected.Length));
            for (int j = 0; j < expected.Length; j++)
            {
                Assert.That(result[i].SequenceEqual(expected));
            }
        }
    }

    [Test]
    public void GetOrdersForThreeElementsTest()
    {
        var result = PermutationGenerator.GetOrders(3);
        Assert.That(result.Length, Is.EqualTo(Expected2.Length));
        for (int i = 0; i < Expected2.Length; i++)
        {
            var expected = Expected2[i];
            Assert.That(result[i].Length, Is.EqualTo(expected.Length));
            for (int j = 0; j < expected.Length; j++)
            {
                Assert.That(result[i].SequenceEqual(expected));
            }
        }
    }
}
