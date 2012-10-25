using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;

namespace MDA.OIP.BorodaDivider
{
    /// <summary>
    /// класс для хранения последовательности ф-мотив
    /// </summary>
    public class FmotivChain : Chain
    {
        /// <summary>
        /// название моно дорожки для которой выделяются ф-мотивы
        /// </summary>
        private string name;


        public FmotivChain()
        {
           
        }

        public FmotivChain(int length):base(length)
        {
            
        }

        public FmotivChain(List<IBaseObject> chain):base(chain)
        {
            
        }

        public FmotivChain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }



        #region IBaseMethods

        public IBaseObject Clone()
        {
            FmotivChain Temp = new FmotivChain(this.Length);
            for (int i = 0; i < this.Length; i++)
            {
                Temp.Add(this[i], i);
            }
            Temp.name = this.name;

            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.name != ((FmotivChain) obj).Name)
            {
                return false;
            }

            if (this.Length != ((FmotivChain) obj).Length)
            {
                return false;
            }
            for (int i = 0; i < this.Length; i++)
            {
                if (!((Fmotiv)this[i]).Equals(((FmotivChain) obj)[i]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
