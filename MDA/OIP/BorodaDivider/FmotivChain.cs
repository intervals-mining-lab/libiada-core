using System;
using System.Collections.Generic;
using System.Text;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivChain
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

        //TODO: реализовать методы IBASEOBJECT!
    }
}
