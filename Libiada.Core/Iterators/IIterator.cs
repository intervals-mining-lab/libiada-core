namespace Libiada.Core.Iterators;

using Libiada.Core.Core;

/// <summary>
/// Interface of sequence iterators.
/// </summary>
public interface IIterator
{
    /// <summary>
    /// Moves iterator to the next position.
    /// </summary>
    /// <returns>
    /// Returns false if end of the sequence is reached. Otherwise returns true.
    /// </returns>
    bool Next();

    /// <summary>
    /// Returns current value of iterator.
    /// </summary>
    /// <returns>
    /// Current subsequence.
    /// </returns>
    AbstractSequence Current();

    /// <summary>
    /// Returns iterator to the starting position.
    /// Before reading first value.
    /// <see cref="IIterator.Next()"/>
    /// method should be called.
    /// </summary>
    void Reset();
}
