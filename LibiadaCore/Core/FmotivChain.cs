namespace LibiadaCore.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

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
            foreach (Fmotif fmotiv in FmotifsList)
            {
                clone.FmotifsList.Add((Fmotif)fmotiv.Clone());
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
}
