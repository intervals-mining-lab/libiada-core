using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.BorodaDivider
{
    /// <summary>
    /// класс для хранения последовательности ф-мотив
    /// </summary>
    public class FmotivChain : IBaseObject
    {
        /// <summary>
        /// порядковый номер - идентификатор цепочки ф-мотивов
        /// </summary>
        private int id;

        /// <summary>
        /// название моно дорожки для которой выделяются ф-мотивы
        /// </summary>
        private string name;

        /// <summary>
        /// список ф-мотив
        /// </summary>
        private List<Fmotiv> fmotivlist;

        public FmotivChain()
        {
            this.fmotivlist = new List<Fmotiv>();
        }

        public List<Fmotiv> FmotivList
        {
            get { return fmotivlist; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        #region IBaseMethods

        /*private FmotivChain()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }*/

        public IBaseObject Clone()
        {
            FmotivChain Temp = new FmotivChain();
            foreach (Fmotiv fmotiv in fmotivlist)
            {
                Temp.fmotivlist.Add((Fmotiv) fmotiv.Clone());
            }
            Temp.id = this.id;
            Temp.name = this.name;

            return Temp;
        }

        public bool Equals(object obj)
        {
            if (this.name != ((FmotivChain) obj).Name)
            {
                return false;
            }
            if (this.id != ((FmotivChain) obj).Id)
            {
                return false;
            }

            if (this.FmotivList.Count != ((FmotivChain) obj).FmotivList.Count)
            {
                return false;
            }
            for (int i = 0; i < this.FmotivList.Count; i++)
            {
                if (!this.FmotivList[i].Equals(((FmotivChain) obj).FmotivList[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public IBin GetBin()
        {
            FmotivChainBin Temp = new FmotivChainBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class FmotivChainBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new FmotivChain();
            }
        }

        #endregion
    }
}
