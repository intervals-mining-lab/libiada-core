namespace Libiada.Segmenter.Base.Iterators;

using Segmenter.Base.Sequences;

/// <summary>
/// An iterator shifts its pointer through a sequence right to left
/// until it reach the beginning of the sequence.
/// </summary>
public sealed class EndIterator : BaseIterator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndIterator"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="length">
    /// Length of a word (window of cutting)
    /// </param>
    /// <param name="step">
    /// The number of elements through which the pointer will jump at the next iteration
    /// </param>
    public EndIterator(ComplexSequence sequence, int length, int step) : base(sequence, length, step)
    {
        CursorPosition = sequence.Length - windowLength + 1;
    }

    /// <summary>
    /// The has next.
    /// </summary>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool HasNext()
    {
        return (CursorPosition - step) >= 0;
    }

    /// <summary>
    /// The next.
    /// </summary>
    /// <returns>
    /// The <see cref="List{string}"/>.
    /// </returns>
    public override List<string> Next()
    {
        CursorPosition -= step;
        try
        {
            currentCut = sequence.Substring(CursorPosition, CursorPosition + windowLength);
        }
        catch (Exception)
        {
        }

        return currentCut;
    }

    /// <summary>
    /// The reset.
    /// </summary>
    public override void Reset()
    {
        CursorPosition = MaxShifts;
    }

    /// <summary>
    /// The position.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int Position()
    {
        return CursorPosition;
    }

    /// <summary>
    /// The current.
    /// </summary>
    /// <returns>
    /// The <see cref="List{string}"/>.
    /// </returns>
    public override List<string> Current()
    {
        return currentCut;
    }

    /// <summary>
    /// The move.
    /// </summary>
    /// <param name="position">
    /// The position.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Move(int position)
    {
        if ((position >= 0) && (sequence.Length >= windowLength + position))
        {
            CursorPosition = position;
            return true;
        }

        return false;
    }
}
