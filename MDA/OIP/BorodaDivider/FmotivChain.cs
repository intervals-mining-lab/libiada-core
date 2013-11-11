using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivChain : IBaseObject // класс для хранения последовательности ф-мотив
    {
        // класс для хранения цепочки ф-мотивов
        private int id; // порядковый номер - идентификатор цепочки ф-мотивов
        private string name; // название моно дорожки для которой выделяются ф-мотивы
        private List<Fmotiv> fmotivlist; // список ф-мотив

        public FmotivChain() 
        {
            this.fmotivlist = new List<Fmotiv>();
        }

        public List<Fmotiv> FmotivList
        {
            get
            {
                return fmotivlist;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
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
                Temp.fmotivlist.Add((Fmotiv)fmotiv.Clone());
            }
            Temp.id = this.id;
            Temp.name = this.name;

            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.name != ((FmotivChain)obj).Name) { return false; }
            if (this.id != ((FmotivChain)obj).Id) { return false; }

            if (this.FmotivList.Count!= ((FmotivChain)obj).FmotivList.Count) {return false;}
            for(int i=0; i < this.FmotivList.Count; i++)
            {
                if (!this.FmotivList[i].Equals(((FmotivChain)obj).FmotivList[i])) {return false;}
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
