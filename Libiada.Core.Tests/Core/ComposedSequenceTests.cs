namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The sequence test.
/// </summary>
[TestFixture]
public class ComposedSequenceTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private readonly List<ComposedSequence> sequences = SequencesStorage.CompusedSequences;

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = SequencesStorage.Elements;

    /// <summary>
    /// The similar sequences get test.
    /// </summary>
    [Test]
    public void SimilarCongenericSequencesGetTest()
    {
        CongenericSequence congenericSequenceA = new([2, 8], elements["A"], 10);

        CongenericSequence createdCongenericSequence = sequences[2].CongenericSequence(elements["A"]);

        Assert.That(createdCongenericSequence, Is.EqualTo(congenericSequenceA));
    }

    /// <summary>
    /// ComposedSequence Test
    /// </summary>
    [Test]
    public void ComposedSequenceTest()
    {
        short[] source = [1, 2, 3, 2, 2, 4, 5, 1];
        ComposedSequence actual = new(source);
        Alphabet alphabet = [new ValueInt(1), new ValueInt(2) , new ValueInt(3) , new ValueInt(4), new ValueInt(5)];
        Assert.That(actual.Alphabet, Is.EqualTo(alphabet));

        int[] order = [1, 2, 3, 2, 2, 4, 5, 1];
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
        for (int i = 0; i < sequences[0].Alphabet.Cardinality; i++)
        {
            int[] actualIntervals = sequences[0].CongenericSequence(i).GetArrangement(Link.Both);
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
    /// <param name="sequenceIndex">
    /// The sequence index.
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
    public void GetElementPositionTest(int expected, int sequenceIndex, string element, int occurrence)
    {
        int actual = sequences[sequenceIndex].GetOccurrence(elements[element], occurrence);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
