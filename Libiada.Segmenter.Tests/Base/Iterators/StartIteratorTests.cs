﻿namespace Libiada.Segmenter.Tests.Base.Iterators;

using Segmenter.Base.Iterators;
using Segmenter.Base.Sequences;
using Segmenter.Extended;

/// <summary>
/// The start iterator test.
/// </summary>
[TestFixture]
public class StartIteratorTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private ComplexSequence sequence;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        sequence = new ComplexSequence("AACAGGTGCCCCTTATTT");
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

        StartIterator iterator = new(sequence, lengthCut, step);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps++;
        }

        Assert.That(countSteps, Is.EqualTo(iterator.MaxShifts));

        countSteps = 0;
        iterator = new StartIterator(sequence, lengthCut, step + 1);
        while (iterator.HasNext())
        {
            iterator.Next();
            countSteps++;
        }

        Assert.That(countSteps, Is.EqualTo(iterator.MaxShifts));
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
                "AAC", "ACA", "CAG", "AGG", "GGT", "GTG", "TGC", "GCC", "CCC", "CCC", "CCT",
                "CTT", "TTA", "TAT", "ATT", "TTT"
            ];
        string[] triplesForStepTwo = ["AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT"];
        const int lengthCut = 3;
        const int step = 1;

        StartIterator iterator = new(sequence, lengthCut, step);

        for (int i = 0; i < iterator.MaxShifts; i++)
        {
            cut = iterator.Next();
            Assert.That(Helper.ToString(cut), Is.EqualTo(triplesForStepOne[i]));
        }

        iterator = new StartIterator(sequence, lengthCut, step + 1);

        for (int i = 0; i < iterator.MaxShifts; i++)
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
        const int length = 2;
        const int step = 1;
        StartIterator iterator = new(sequence, length, step);
        if (iterator.Move(3))
        {
            iterator.Reset();
        }

        Assert.That(iterator.CursorPosition, Is.EqualTo(-step));
    }

    /// <summary>
    /// The move test.
    /// </summary>
    [Test]
    public void MoveTest()
    {
        int length = 2;
        int step = 1;
        int position = 3;
        StartIterator iterator = new(sequence, length, step);
        iterator.Move(position);
        Assert.That(iterator.CursorPosition, Is.EqualTo(position));

        position = 100;
        iterator.Move(position);
        Assert.That(iterator.CursorPosition, Is.Not.EqualTo(position));

        position = sequence.Length / 2;
        iterator.Move(position);
        Assert.That(iterator.CursorPosition, Is.EqualTo(position));

        position = -1;
        iterator.Move(position);
        Assert.That(iterator.CursorPosition, Is.Not.EqualTo(position));

        length = 3;
        step = 2;
        position = 3;
        const string triple = "GTG";
        iterator = new StartIterator(sequence, length, step);
        iterator.Move(position);
        iterator.Next();
        Assert.That(Helper.ToString(iterator.Current()), Is.EqualTo(triple));
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
        StartIterator iterator = new(sequence, lengthCut, step);
        Assert.That(iterator.MaxShifts, Is.EqualTo(maxShifts));
    }

    /// <summary>
    /// The get position test.
    /// </summary>
    [Test]
    public void GetPositionTest()
    {
        const int lengthCut = 2;
        const int step = 1;
        StartIterator iterator = new(sequence, lengthCut, step);
        iterator.Next();
        Assert.That(iterator.CursorPosition, Is.EqualTo(0));
        iterator.Next();
        Assert.That(iterator.CursorPosition, Is.EqualTo(1));
        for (int index = 2; index < iterator.MaxShifts; index++)
        {
            iterator.Next();
        }

        Assert.That(iterator.CursorPosition, Is.EqualTo(16));
    }
}
