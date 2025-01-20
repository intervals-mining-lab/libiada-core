namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// The null cycle space reorganizer.
/// </summary>
public class NullCycleSpaceReorganizer : SpaceReorganizer
{
    // TODO: check if this class is needed of if it does what it say it does.

    /// <summary>
    /// Markov chain level.
    /// </summary>
    private readonly int level;

    /// <summary>
    /// Initializes a new instance of the <see cref="NullCycleSpaceReorganizer"/> class.
    /// </summary>
    /// <param name="level">
    /// Level of markov chain.
    /// </param>
    public NullCycleSpaceReorganizer(int level)
    {
        this.level = level;
    }

    /// <summary>
    /// Reorganizes source sequence.
    /// </summary>
    /// <param name="source">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// <see cref="AbstractSequence"/>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if level is less than 0.
    /// </exception>
    public override AbstractSequence Reorganize(AbstractSequence source)
    {
        if (level < 0)
        {
            throw new InvalidOperationException("Markov chain level can't be less than 0");
        }

        if (level == 0)
        {
            return source;
        }

        Sequence result = new();
        result.ClearAndSetNewLength(source.Length + level);
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = source[i];
        }

        IteratorStart iterator = new(source, level, 1);
        iterator.Reset();
        iterator.Next();
        AbstractSequence addition = iterator.Current();
        for (int i = 0; i < addition.Length; i++)
        {
            result[source.Length + i] = addition[i];
        }

        return result;
    }
}
