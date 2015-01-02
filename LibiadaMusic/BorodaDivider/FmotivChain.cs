namespace LibiadaMusic.BorodaDivider
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core;

    /// <summary>
    /// класс для хранения последовательности ф-мотив
    /// </summary>
    public class FmotivChain : IBaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FmotivChain"/> class.
        /// </summary>
        public FmotivChain()
        {
            FmotivList = new List<Fmotiv>();
        }

        /// <summary>
        /// список ф-мотив
        /// </summary>
        public List<Fmotiv> FmotivList { get; private set; }

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
            var clone = new FmotivChain();
            foreach (Fmotiv fmotiv in FmotivList)
            {
                clone.FmotivList.Add((Fmotiv)fmotiv.Clone());
            }

            clone.Id = Id;
            clone.Name = Name;

            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = (FmotivChain)obj;
            if (Name != other.Name || Id != other.Id)
            {
                return false;
            }

            return FmotivList.SequenceEqual(other.FmotivList);
        }
    }
}
