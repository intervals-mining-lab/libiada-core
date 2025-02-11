namespace Libiada.Core.Iterators;

using Libiada.Core.Core;

/// <summary>
/// Abstract sequence iterator.
/// </summary>
public abstract class IteratorBase : IIterator
{
    /// <summary>
    /// Length of subsequence.
    /// </summary>
    protected readonly int Length;

    /// <summary>
    /// Shift of iterator.
    /// </summary>
    protected readonly int Step;

    /// <summary>
    /// Source sequence.
    /// </summary>
    protected readonly AbstractSequence Source;

    /// <summary>
    /// Initializes a new instance of the <see cref="IteratorBase"/> class.
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
    /// <exception cref="ArgumentException">
    /// Thrown if one or more arguments are invalid.
    /// </exception>
    public IteratorBase(AbstractSequence source, int length, int step)
    {
        if (source == null || length <= 0 || source.Length < length)
        {
            throw new ArgumentException("Iterator arguments are invalid.");
        }

        Length = length;
        Step = step;
        Source = source;
        MaxPosition = Source.Length - Length;
        Reset();
    }

    /// <summary>
    /// Gets or sets current position of iterator.
    /// </summary>
    public int Position { get; protected set; }

    /// <summary>
    /// Gets max position of iterator.
    /// </summary>
    protected int MaxPosition { get; private set; }

    /// <summary>
    /// Moves iterator to the next position.
    /// </summary>
    /// <returns>
    /// Returns false if end of the sequence is reached. Otherwise returns true.
    /// </returns>
    public abstract bool Next();

    /// <summary>
    /// Returns current value of iterator.
    /// </summary>
    /// <returns>
    /// Current subsequence.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if current position is invalid.
    /// </exception>
    public virtual AbstractSequence Current()
    {
        if (Position < 0 || Position > MaxPosition)
        {
            throw new InvalidOperationException("Iterator position is out of range.");
        }

        Sequence result = new(Length);

        for (int i = 0; i < Length; i++)
        {
            result[i] = Source[Position + i];
        }

        return result;
    }

    /// <summary>
    /// Returns iterator to the starting position.
    /// Before reading first value.
    /// <see cref="IteratorBase.Next()"/>
    /// method should be called.
    /// </summary>
    public abstract void Reset();
}
