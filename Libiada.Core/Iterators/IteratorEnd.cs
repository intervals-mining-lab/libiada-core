namespace Libiada.Core.Iterators;

using Libiada.Core.Core;

/// <summary>
/// Iterator that moves from the end of chain to its beginning.
/// </summary>
public class IteratorEnd : IteratorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IteratorEnd"/> class.
    /// </summary>
    /// <param name="source">
    /// Source chain.
    /// </param>
    /// <param name="length">
    /// Length of subsequence.
    /// </param>
    /// <param name="step">
    /// Shift of iterator.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if one or more arguments are invalid.
    /// </exception>
    public IteratorEnd(AbstractChain source, int length, int step) : base(source, length, step)
    {
    }

    /// <summary>
    /// Moves iterator to the next position.
    /// </summary>
    /// <returns>
    /// Returns false if end of the chain is reached. Otherwise returns true.
    /// </returns>
    public override bool Next()
    {
        Position -= Step;
        return Position >= 0;
    }

    /// <summary>
    /// Returns iterator to the starting position.
    /// Before reading first value.
    /// <see cref="IteratorEnd.Next()"/>
    /// method should be called.
    /// </summary>
    public override void Reset()
    {
        Position = Source.Length - Length + Step;
    }
}
