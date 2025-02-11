﻿namespace Libiada.Core.Iterators;

/// <summary>
/// The cut rule for sequence.
/// Contains start and end positions for all subsequences.
/// </summary>
public abstract class CutRule
{
    /// <summary>
    /// The starts.
    /// </summary>
    protected readonly List<int> Starts = [];

    /// <summary>
    /// The stops.
    /// </summary>
    protected readonly List<int> Ends = [];

    /// <summary>
    /// Method returning iterator for this cut rule.
    /// </summary>
    /// <returns>
    /// The <see cref="CutRuleIterator"/>.
    /// </returns>
    public abstract CutRuleIterator GetIterator();
}
