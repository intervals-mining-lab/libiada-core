namespace Libiada.Segmenter.Interfaces;

using System.Collections.Generic;

/// <summary>
/// Provides search an entry one object to other
/// </summary>
public abstract class Seeker
{
    /// <summary>
    /// The step.
    /// </summary>
    public static readonly int Step = 1;

    /// <summary>
    /// Returns number of hits required word from a sequence
    /// </summary>
    /// <param name="required">searchable word</param>
    /// <returns>number of hits</returns>
    public abstract int Seek(List<string> required);
}
