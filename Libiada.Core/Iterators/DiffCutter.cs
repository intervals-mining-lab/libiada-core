﻿namespace Libiada.Core.Iterators;

/// <summary>
/// Class that cut the string into substrings using provided cut rule.
/// </summary>
public static class DiffCutter
{
    /// <summary>
    /// Divides the string into substrings.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="rule">
    /// The cut rule.
    /// </param>
    /// <returns>
    /// Substrings of the sequence.
    /// </returns>
    public static List<string> Cut(string sequence, CutRule rule)
    {
        List<string> result = [];

        rule.GetIterator();
        CutRuleIterator iterator = rule.GetIterator();

        while (iterator.Next())
        {
            string s = sequence.Substring(iterator.GetStartPosition(), iterator.GetEndPosition() - iterator.GetStartPosition());
            result.Add(s);
        }

        return result;
    }
}
