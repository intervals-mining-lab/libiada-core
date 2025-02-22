namespace Libiada.Segmenter.Base.Seekers.Converters;

using Libiada.Core.Core.SimpleTypes;

using Sequences;

/// <summary>
/// Filters a sequence of signs in compliance with set rules.
/// The filter handles only words
/// </summary>
public class Filter
{
    /// <summary>
    /// The sequence.
    /// </summary>
    protected readonly ComplexSequence Sequence;

    /// <summary>
    /// The replacement.
    /// </summary>
    protected string replacement = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="Filter"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public Filter(ComplexSequence sequence)
    {
        Sequence = sequence.Clone();
    }

    /// <summary>
    /// Removes all specified entry letters in any word
    /// </summary>
    /// <param name="str">specified substring</param>
    /// <returns>number of hints</returns>
    public int FilterOut(string str)
    {
        int len = Sequence.ToString().Length;
        for (int index = Sequence.Length; --index >= 0;)
        {
            Sequence[index] = new ValueString(Sequence[index].ToString().Replace(str, replacement));
            if (Sequence[index].ToString().Length == 0)
            {
                Sequence.Remove(index, 1);
            }
        }

        return Hints(len, str);
    }

    /// <summary>
    /// Replaces all specified entry letters in any word
    /// </summary>
    /// <param name="str">specified substring</param>
    /// <param name="replacement">something that must be replaced</param>
    /// <returns>number of hints</returns>
    public int Replace(string str, string replacement)
    {
        this.replacement = replacement;
        int hits = FilterOut(str);
        this.replacement = string.Empty;

        return hits;
    }

    /// <summary>
    ///Get sequence method.
    /// </summary>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public ComplexSequence GetSequence()
    {
        return Sequence.Clone();
    }

    /// <summary>
    /// The hints.
    /// </summary>
    /// <param name="len">
    /// The len.
    /// </param>
    /// <param name="str">
    /// The string.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    private int Hints(int len, string str)
    {
        double per = (len - Sequence.ToString().Length) / (double)(str.Length - replacement.Length);
        return (int)per;
    }
}
