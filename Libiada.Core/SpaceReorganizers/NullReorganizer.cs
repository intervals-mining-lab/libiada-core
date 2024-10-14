namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// Reorganizer that does nothing.
/// </summary>
public class NullReorganizer : SpaceReorganizer
{
    /// <summary>
    /// Reorganizes <see cref="AbstractChain"/> into <see cref="AbstractChain"/>.
    /// </summary>
    /// <param name="source">
    /// Source chain.
    /// </param>
    /// <returns>
    /// The <see cref="AbstractChain"/>.
    /// </returns>
    public override AbstractChain Reorganize(AbstractChain source)
    {
        AbstractChain? result = source.Clone() as AbstractChain;
        if (result != null)
        {
            return result;
        }

        result = new BaseChain();
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
