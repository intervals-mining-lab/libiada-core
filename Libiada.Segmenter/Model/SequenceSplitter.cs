namespace Libiada.Segmenter.Model;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;

/// <summary>
/// Used as a base for all kinds of word splitters for a sequence
/// </summary>
public abstract class SequenceSplitter
{
    /// <summary>
    /// The alphabet.
    /// </summary>
    protected FrequencyDictionary alphabet;

    /// <summary>
    /// The convoluted.
    /// </summary>
    protected ComplexSequence convoluted;

    /// <summary>
    /// Gets the frequency dictionary.
    /// </summary>
    public FrequencyDictionary FrequencyDictionary
    {
        get { return alphabet; }
    }

    /// <summary>
    /// The cut.
    /// </summary>
    /// <param name="par">
    /// The par.
    /// </param>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public abstract ComplexSequence Cut(Dictionary<string, object> par);
}
