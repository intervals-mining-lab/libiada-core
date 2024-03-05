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
    /// The complex chain.
    /// </summary>
    private ComplexChain complexChain;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        complexChain = new ComplexChain("AACAGGTGCCCCTTATTT");
    }

    /// <summary>
    /// The has next test.
    /// </summary>
    [Test]
    public void HasNextTest()
    {
        int lengthCut = 3;
        int step = 1;
        int countSteps = 0;

        var iterator = new EndIterator(complexChain, lengthCut, step);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps = countSteps + 1;
        }

        Assert.AreEqual(countSteps, iterator.MaxShifts);

        countSteps = 0;
        iterator = new EndIterator(complexChain, lengthCut, step + 1);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps = countSteps + 1;
        }

        Assert.True(countSteps == iterator.MaxShifts);
    }

    /// <summary>
    /// The next test.
    /// </summary>
    [Test]
    public void NextTest()
    {
        List<string> cut;
        string[] triplesForStepOne =
            {
                "AAC", "ACA", "CAG", "AGG",
                "GGT", "GTG", "TGC", "GCC",
                "CCC", "CCC", "CCT", "CTT",
                "TTA", "TAT", "ATT", "TTT"
            };
        string[] triplesForStepTwo = { "AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT" };
        int lengthCut = 3;
        int step = 1;

        var iterator = new EndIterator(complexChain, lengthCut, step);

        for (int i = iterator.MaxShifts - 1; i >= 0; i--)
        {
            cut = iterator.Next();
            Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
        }

        iterator = new EndIterator(complexChain, lengthCut, step + 1);

        for (int i = iterator.MaxShifts - 1; i >= 0; i--)
        {
            cut = iterator.Next();
            Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
        }
    }

    /// <summary>
    /// The reset test.
    /// </summary>
    [Test]
    public void ResetTest()
    {
        int lengthCut = 2;
        int step = 1;
        int index = 0;
        int position = 6;
        var list1 = new List<string>
            {
                "ABABAB",
                "ABATAT",
                "TABABAB",
                "ABTABAB",
                "ABABAB",
                "ABABAB",
                "ABABAB"
            };
        var chain = new ComplexChain(list1);
        var iterator = new EndIterator(chain, lengthCut, step);
        while (iterator.HasNext())
        {
            iterator.Next();
            index = index + 1;
        }

        iterator.Reset();

        Assert.True(iterator.Position() == position);
    }

    /// <summary>
    /// The get max shifts test.
    /// </summary>
    [Test]
    public void GetMaxShiftsTest()
    {
        int lengthCut = 3;
        int step = 1;
        int maxShifts = 16;
        EndIterator iterator = new EndIterator(complexChain, lengthCut, step);
        Assert.True(iterator.MaxShifts == maxShifts);
    }

    /// <summary>
    /// The move test.
    /// </summary>
    [Test]
    public void MoveTest()
    {
        int len = 2;
        int step = 1;
        int from = 1, to = 3;
        var list1 = new List<string>
            {
                "ABABAB",
                "ABATAT",
                "TABABAB",
                "ABTABAB",
                "ABABAB",
                "ABABAB",
                "ABABAB"
            };
        List<string> list = list1.GetRange(@from, to - @from);
        var chain = new ComplexChain(list1);
        var iterator = new EndIterator(chain, len, step);
        iterator.Move(2);
        List<string> result = iterator.Next();
        for (int i = 0; i < list.Count; i++)
        {
            Assert.True(list[i].Equals(result[i]));
        }
    }
}
