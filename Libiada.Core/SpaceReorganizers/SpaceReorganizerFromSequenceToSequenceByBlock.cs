namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// The space reorganizer from sequence to sequence by block.
/// </summary>
public class SpaceReorganizerFromSequenceToSequenceByBlock : SpaceReorganizer
{
    /// <summary>
    /// The link.
    /// </summary>
    private readonly Link link;

    /// <summary>
    /// The block size.
    /// </summary>
    private readonly int blockSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpaceReorganizerFromSequenceToSequenceByBlock"/> class.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="blockSize">
    /// The block size.
    /// </param>
    public SpaceReorganizerFromSequenceToSequenceByBlock(Link link, int blockSize)
    {
        this.link = link;
        this.blockSize = blockSize;
    }

    /// <summary>
    /// Reorganizes <see cref="AbstractSequence"/> into <see cref="AbstractSequence"/>.
    /// </summary>
    /// <param name="source">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// The <see cref="AbstractSequence"/>.
    /// </returns>
    public override AbstractSequence Reorganize(AbstractSequence source)
    {
        Sequence result = new();
        result.ClearAndSetNewLength(source.Length / blockSize);
        IteratorBase iteratorFrom;
        IWritableIterator iteratorTo;

        if (link != Link.End)
        {
            iteratorFrom = new IteratorStart(source, blockSize, blockSize);
            iteratorTo = new IteratorWritableStart(result);
        }
        else
        {
            iteratorFrom = new IteratorEnd(source, blockSize, blockSize);
            iteratorTo = new IteratorWritableEnd(result);
        }

        while (iteratorTo.Next() && iteratorFrom.Next())
        {
            iteratorTo.WriteValue(iteratorFrom.Current());
        }

        return result;
    }
}
