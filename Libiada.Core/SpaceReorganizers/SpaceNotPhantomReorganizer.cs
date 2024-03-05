namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Not phantom reorganizer.
/// </summary>
public class SpaceNotPhantomReorganizer : SpaceReorganizer
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
            IBaseObject element = (source[i] as ValuePhantom)?[0] ?? source[i];
            elements.Add(element);
        }

        return new BaseChain(elements);
    }
}
