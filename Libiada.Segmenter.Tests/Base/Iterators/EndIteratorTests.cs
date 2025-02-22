namespace Libiada.Segmenter.Tests.Base.Iterators;

using Segmenter.Base.Iterators;
using Segmenter.Base.Sequences;
using Segmenter.Extended;

/// <summary>
/// The end iterator test.
/// </summary>
[TestFixture]
public class EndIteratorTests
{
    /// <summary>
    /// The complex sequence.
    /// </summary>
    private ComplexSequence complexSequence;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        complexSequence = new ComplexSequence("AACAGGTGCCCCTTATTT");
    }

    /// <summary>
    /// The has next test.
    /// </summary>
    [Test]
    public void HasNextTest()
    {
        const int lengthCut = 3;
        const int step = 1;
        int countSteps = 0;

        EndIterator iterator = new(complexSequence, lengthCut, step);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps++;
        }

        Assert.That(iterator.MaxShifts, Is.EqualTo(countSteps));

        countSteps = 0;
        iterator = new EndIterator(complexSequence, lengthCut, step + 1);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps++;
        }

        Assert.That(iterator.MaxShifts, Is.EqualTo(countSteps));
    }

    /// <summary>
    /// The next test.
    /// </summary>
    [Test]
    public void NextTest()
    {
        List<string> cut;
        string[] triplesForStepOne =
            [
                "AAC", "ACA", "CAG", "AGG",
                "GGT", "GTG", "TGC", "GCC",
                "CCC", "CCC", "CCT", "CTT",
                "TTA", "TAT", "ATT", "TTT"
            ];
        string[] triplesForStepTwo = ["AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT"];
        const int lengthCut = 3;
        const int step = 1;

        EndIterator iterator = new(complexSequence, lengthCut, step);

        for (int i = iterator.MaxShifts - 1; i >= 0; i--)
        {
            cut = iterator.Next();
            Assert.That(Helper.ToString(cut), Is.EqualTo(triplesForStepOne[i]));
        }

        iterator = new EndIterator(complexSequence, lengthCut, step + 1);

        for (int i = iterator.MaxShifts - 1; i >= 0; i--)
        {
            cut = iterator.Next();
            Assert.That(Helper.ToString(cut), Is.EqualTo(triplesForStepTwo[i]));
        }
    }

    /// <summary>
    /// The reset test.
    /// </summary>
    [Test]
    public void ResetTest()
    {
        const int lengthCut = 2;
        const int step = 1;
        int index = 0;
        const int position = 6;
        List<string> list1 =
            [
                "ABABAB",
                "ABATAT",
                "TABABAB",
                "ABTABAB",
                "ABABAB",
                "ABABAB",
                "ABABAB"
            ];
        ComplexSequence sequence = new(list1);
        EndIterator iterator = new(sequence, lengthCut, step);
        while (iterator.HasNext())
        {
            iterator.Next();
            index++;
        }

        iterator.Reset();

        Assert.That(iterator.Position(), Is.EqualTo(position));
    }

    /// <summary>
    /// The get max shifts test.
    /// </summary>
    [Test]
    public void GetMaxShiftsTest()
    {
        const int lengthCut = 3;
        const int step = 1;
        const int maxShifts = 16;
        EndIterator iterator = new(complexSequence, lengthCut, step);
        Assert.That(iterator.MaxShifts, Is.EqualTo(maxShifts));
    }

    /// <summary>
    /// The move test.
    /// </summary>
    [Test]
    public void MoveTest()
    {
        const int len = 2;
        const int step = 1;
        const int from = 1, to = 3;
        List<string> list1 =
            [
                "ABABAB",
                "ABATAT",
                "TABABAB",
                "ABTABAB",
                "ABABAB",
                "ABABAB",
                "ABABAB"
            ];
        List<string> list = list1.GetRange(@from, to - @from);
        ComplexSequence sequence = new(list1);
        EndIterator iterator = new(sequence, len, step);
        iterator.Move(2);
        List<string> result = iterator.Next();
        for (int i = 0; i < list.Count; i++)
        {
            Assert.That(list[i], Is.EqualTo(result[i]));
        }
    }
}
