namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The chain test.
/// </summary>
[TestFixture]
public class ChainTests
{
    /// <summary>
    /// The chain.
    /// </summary>
    private readonly List<Chain> chains = ChainsStorage.Chains;

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

    /// <summary>
    /// The similar chains get test.
    /// </summary>
    [Test]
    public void SimilarChainsGetTest()
    {
        var congenericChainA = new CongenericChain([2, 8], elements["A"], 10);

        var chainCreatedCongenericChain = chains[2].CongenericChain(elements["A"]);

        Assert.That(chainCreatedCongenericChain, Is.EqualTo(congenericChainA));
    }

    /// <summary>
    ///Chain Test
    /// </summary>
   [Test]
    public void ChainTest()
    {
        short[] source = [1, 2, 3, 2, 2, 4, 5, 1];
        var actual = new Chain(source);
        var alphabet = new Alphabet() {new ValueInt(1), new ValueInt(2) , new ValueInt(3) , new ValueInt(4), new ValueInt(5) };
        Assert.That(actual.Alphabet, Is.EqualTo(alphabet));

        var order = new int[] { 1, 2, 3, 2, 2, 4, 5, 1 };
        Assert.That(actual.Order, Is.EqualTo(order));
    }


    /// <summary>
    /// The intervals test.
    /// </summary>
    [Test]
    public void IntervalsTest()
    {
        List<List<int>> intervals =
            [
                [1, 1, 4, 4, 1],
                [3, 1, 3, 4],
                [5, 3, 1, 2]
            ];
        for (int i = 0; i < chains[0].Alphabet.Cardinality; i++)
        {
            var actualIntervals = chains[0].CongenericChain(i).GetArrangement(Link.Both);
            for (int j = 0; j < actualIntervals.Length; j++)
            {
                Assert.That(actualIntervals[j], Is.EqualTo(intervals[i][j]), $"{j} and {i} intervals of sequence are not equal");
            }
        }
    }

    /// <summary>
    /// The get element position test.
    /// </summary>
    /// <param name="expected">
    /// The expected position.
    /// </param>
    /// <param name="chainIndex">
    /// The chain index.
    /// </param>
    /// <param name="element">
    /// The element.
    /// </param>
    /// <param name="occurrence">
    /// The occurrence number.
    /// </param>
    [TestCase(2, 2, "A", 1)]
    [TestCase(8, 2, "A", 2)]
    [TestCase(-1, 2, "A", 3)]
    [TestCase(0, 2, "C", 1)]
    [TestCase(1, 2, "C", 2)]
    [TestCase(3, 2, "C", 3)]
    [TestCase(5, 2, "C", 4)]
    [TestCase(9, 2, "C", 5)]
    [TestCase(-1, 2, "C", 6)]
    [TestCase(4, 2, "G", 1)]
    [TestCase(-1, 2, "G", 2)]
    [TestCase(-1, 2, "G", 3)]
    [TestCase(6, 2, "T", 1)]
    [TestCase(7, 2, "T", 2)]
    [TestCase(-1, 2, "T", 3)]
    public void GetElementPositionTest(int expected, int chainIndex, string element, int occurrence)
    {
        var actual = chains[chainIndex].GetOccurrence(elements[element], occurrence);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
