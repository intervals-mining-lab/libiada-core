namespace LibiadaCore.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// класс для хранения последовательности ф-мотив
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
        public List<Fmotif> FmotifsList { get; private set; }

        /// <summary>
        /// Gets or sets name of mono track.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets fmotiv id.
        /// </summary>
        public int Id { get; set; }

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

            clone.Id = Id;
            clone.Name = Name;

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
            var other = (FmotifChain)obj;
            if (Name != other.Name || Id != other.Id)
            {
                return false;
            }

            return FmotifsList.SequenceEqual(other.FmotifsList);
        }
    }
}
