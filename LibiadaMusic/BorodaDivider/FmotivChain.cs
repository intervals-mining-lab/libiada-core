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

        public FmotivChain()
        {
            FmotivList = new List<Fmotiv>();
        }

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
