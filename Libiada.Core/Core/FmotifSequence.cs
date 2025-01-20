namespace Libiada.Core.Core;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Class storing Fmotifs sequence
/// </summary>
public class FmotifSequence : IBaseObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FmotifSequence"/> class.
    /// </summary>
    public FmotifSequence()
    {
        FmotifsList = [];
    }

    public FmotifSequence(List<Fmotif> fmotifsList)
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
        FmotifSequence clone = new();
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
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is FmotifSequence fmotifSequence && FmotifsList.SequenceEqual(fmotifSequence.FmotifsList);
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
