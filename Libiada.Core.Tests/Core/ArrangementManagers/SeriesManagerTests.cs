﻿namespace Libiada.Core.Tests.Core.ArrangementManagers;

using Libiada.Core.Core;
using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// The congeneric series manager tests.
/// </summary>
[TestFixture]
public class SeriesManagerTests
{
    /// <summary>
    /// The congeneric sequences.
    /// </summary>
    private readonly List<CongenericSequence> congenericSequences = SequencesStorage.CongenericSequences;

    /// <summary>
    /// The simple series manager tests.
    /// </summary>
    /// <param name="index">
    /// The index of congeneric sequence.
    /// </param>
    /// <param name="expected">
    /// The expected series.
    /// </param>
    [TestCase(0, new[] { 2, 1, 1 })]
    [TestCase(1, new[] { 1, 2, 1, 1 })]
    [TestCase(2, new[] { 1 })]
    [TestCase(3, new[] { 1 })]
    [TestCase(4, new[] { 1, 1, 1 })]
    [TestCase(5, new[] { 5, 4, 3, 2, 1 })]
    [TestCase(6, new[] { 1, 1 })]
    [TestCase(7, new[] { 1, 1 })]
    [TestCase(8, new[] { 1, 1, 1, 1, 1 })]
    [TestCase(9, new[] { 1, 1, 1, 1, 1 })]
    [TestCase(10, new[] { 1, 1, 1, 1 })]
    [TestCase(11, new[] { 2, 1, 1 })]
    [TestCase(12, new[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
    [TestCase(13, new[] { 1, 2, 1, 1, 2, 1, 1, 1 })]
    [TestCase(14, new[] { 1, 1, 1, 1 })]
    [TestCase(15, new[] { 1, 1, 1, 1 })]
    [TestCase(16, new[] { 1, 1, 1, 1 })]
    [TestCase(17, new[] { 1, 1, 1, 1 })]
    public void SimpleSeriesManagerTests(int index, int[] expected)
    {
        SeriesManager manager = new(congenericSequences[index]);
        int[] actual = manager.GetArrangement(Link.NotApplied);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
