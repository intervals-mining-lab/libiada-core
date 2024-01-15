namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Space phantom reorganizer.
/// </summary>
public class SpacePhantomReorganizer : SpaceReorganizer
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
        var elements = new List<IBaseObject>();

        for (int i = 0; i < source.Length; i++)
        {
            elements.Add(source[i] as ValuePhantom ?? new ValuePhantom { source[i] });
        }

        return new BaseChain(elements);
    }
}
