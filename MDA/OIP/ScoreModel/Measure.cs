using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class Measure : IBaseObject // такт
    {
        private List<Note> notelist; // список нот, класса Note
        private Attributes attributes; // атрибуты

        public Measure(List<Note> notelist, Attributes attributes)
        {
            this.notelist = new List<Note>();
            for (int i= 0; i < notelist.Count; i++) // создаем список нот, по средствам клонирования каждой ноты.
            {
               this.notelist.Add((Note) notelist[i].Clone());
            }
            this.attributes = (Attributes) attributes.Clone(); 
        }
        public List<Note> Notelist
        {
            get
            {
                return notelist;
            }
        }
        public Attributes Attributes
        {
            get
            {
                return attributes;
            }
        }
        
        #region IBaseMethods

        private Measure()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Measure Temp = new Measure(this.notelist, this.attributes);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            bool equalNoteList = true;

            if (this.Notelist.Count!= ((Measure)obj).Notelist.Count) {equalNoteList = false;}
            for(int i=0; i < this.Notelist.Count; i++)
            {
                if (!this.Notelist[i].Equals(((Measure)obj).Notelist[i])) {equalNoteList = false;}
            }
            if ( this.Attributes.Equals(((Measure)obj).Attributes) && equalNoteList )
            {
                return true;
            }
            return false;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }

        public IBin GetBin()
        {
            MeasureBin Temp = new MeasureBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class MeasureBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Measure();
            }
        }

        #endregion
    }
}
