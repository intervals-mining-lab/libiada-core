namespace Libiada.Core.Iterators;

using Libiada.Core.Core;

/// <summary>
/// Iterator that goes from start of the sequence.
/// </summary>
public class IteratorStart : IteratorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IteratorStart"/> class.
    /// </summary>
    /// <param name="source">
    /// Source sequence.
    /// </param>
    /// <param name="length">
    /// Length of subsequence.
    /// </param>
    /// <param name="step">
    /// Shift of iterator.
    /// </param>
    public IteratorStart(AbstractSequence source, int length, int step) : base(source, length, step)
    {
    }

    /// <summary>
    /// Moves iterator to the next position.
    /// </summary>
    /// <returns>
    /// Returns false if end of the sequence is reached. Otherwise returns true.
    /// </returns>
    public override bool Next()
    {
        Position += Step;
        return Position <= MaxPosition;
    }

    /// <summary>
    /// Returns iterator to the starting position.
    /// Before reading first value.
    /// <see cref="IteratorBase.Next()"/>
    /// method should be called.
    /// </summary>
    public override void Reset()
    {
        Position = -Step;
    }
}
