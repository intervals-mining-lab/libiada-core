namespace Libiada.PhantomChains;

using System;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Slice of one level in variants tree.
/// </summary>
public class Record
{
    /// <summary>
    /// Phantom value in given position of phantom sequence
    /// representing variants of content of current level in variants tree.
    /// </summary>
    public readonly ValuePhantom Content;

    /// <summary>
    /// Variants count on this level of variants tree.
    /// </summary>
    public readonly ulong Volume;

    /// <summary>
    /// Initializes a new instance of the <see cref="Record"/> class.
    /// </summary>
    /// <param name="message">
    /// Phantom message on the current position of sequence.
    /// </param>
    /// <param name="volume">
    /// Variants count for current position.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if there is no message.
    /// </exception>
    public Record(ValuePhantom message, ulong volume)
    {
        if (message == null)
        {
            throw new ArgumentNullException();
        }

        Content = message;
        Volume = volume;
    }
}
