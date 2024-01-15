namespace Libiada.Core.Core;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Class storing Fmotifs sequence
/// </summary>
public class FmotifChain : IBaseObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FmotifChain"/> class.
    /// </summary>
    public FmotifChain()
    {
        FmotifsList = new List<Fmotif>();
    }

    public FmotifChain(List<Fmotif> fmotifsList)
    {
        FmotifsList = fmotifsList;
    }

    /// <summary>
    /// Gets fmotifs list.
    /// </summary>
    public List<Fmotif> FmotifsList { get; }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone()
    {
        var clone = new FmotifChain();
        foreach (Fmotif fmotif in FmotifsList)
        {
            clone.FmotifsList.Add((Fmotif)fmotif.Clone());
        }

        return clone;
    }

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="obj">
    /// The object.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is FmotifChain fmotifChain && FmotifsList.SequenceEqual(fmotifChain.FmotifsList);
    }

    /// <summary>
    /// Calculates hash code using <see cref="FmotifsList"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = -68587965;
            foreach (Fmotif fmotif in FmotifsList)
            {
                hashCode = (hashCode * -1521134295) + fmotif.GetHashCode();
            }

            return hashCode;
        }
    }
}
