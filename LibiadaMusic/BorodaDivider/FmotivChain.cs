using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.BorodaDivider
{
    public class FmotivChain : IBaseObject // класс для хранения последовательности ф-мотив
    {
        // класс для хранения цепочки ф-мотивов
        private int id; // порядковый номер - идентификатор цепочки ф-мотивов
        private string name; // название моно дорожки для которой выделяются ф-мотивы
        private List<Fmotiv> fmotivlist; // список ф-мотив

        public FmotivChain()
        {
            fmotivlist = new List<Fmotiv>();
        }

        public List<Fmotiv> FmotivList
        {
            get { return fmotivlist; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #region IBaseMethods

        public IBaseObject Clone()
        {
            var temp = new FmotivChain();
            foreach (Fmotiv fmotiv in fmotivlist)
            {
                temp.fmotivlist.Add((Fmotiv) fmotiv.Clone());
            }
            temp.id = id;
            temp.name = name;

            return temp;
        }

        public override bool Equals(object obj)
        {
            if (name != ((FmotivChain) obj).name)
            {
                return false;
            }
            if (id != ((FmotivChain) obj).id)
            {
                return false;
            }

            if (FmotivList.Count != ((FmotivChain) obj).FmotivList.Count)
            {
                return false;
            }
            for (int i = 0; i < FmotivList.Count; i++)
            {
                if (!FmotivList[i].Equals(((FmotivChain) obj).FmotivList[i]))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
