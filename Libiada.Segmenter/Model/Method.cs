namespace Libiada.Segmenter.Model;

/// <summary>
/// Defines how to calculate some of the characteristics for the sequence:
/// use of a given sequence of characters as one character (convoluted sequence)
/// or as a word consists of the characters.
/// </summary>
public enum Method
{
    /// <summary>
    /// The convoluted.
    /// </summary>
    Convoluted,

    /// <summary>
    /// The not convoluted.
    /// </summary>
    NotConvoluted
}
