namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// Reorganizer that does nothing.
/// </summary>
public class NullReorganizer : SpaceReorganizer
{
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
        AbstractSequence? result = source.Clone() as AbstractSequence;
        if (result != null)
        {
            return result;
        }

        result = new Sequence();
        result.ClearAndSetNewLength(source.Length);

        IteratorSimpleStart iteratorRead = new(source, 1);
        IteratorWritableStart iteratorWrite = new(result);
        iteratorRead.Reset();
        iteratorWrite.Reset();
        iteratorRead.Next();
        iteratorWrite.Next();

        for (int i = 0; i < source.Length; i++)
        {
            iteratorWrite.WriteValue(iteratorRead.Current());
            iteratorRead.Next();
            iteratorWrite.Next();
        }

        return result;
    }
}
