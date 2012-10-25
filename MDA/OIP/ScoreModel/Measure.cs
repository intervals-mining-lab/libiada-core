using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// такт
    /// </summary>
    public class Measure : IBaseObject
    {
        /// <summary>
        /// список нот, класса Note
        /// </summary>
        private List<ValueNote> notelist;

        /// <summary>
        /// атрибуты
        /// </summary>
        private Attributes attributes;

        /// <summary>
        /// уникальный идентификатор такта
        /// </summary>
        private int id;

        public Measure(List<ValueNote> notelist, Attributes attributes)
        {
            if (attributes != null)
            {
                this.attributes = (Attributes) attributes.Clone();
            }

            this.notelist = new List<ValueNote>();
            for (int i = 0; i < notelist.Count; i++) // создаем список нот, по средствам клонирования каждой ноты.
            {
                this.notelist.Add((ValueNote) notelist[i].Clone());
            }
        }

        public List<ValueNote> NoteList
        {
            get { return notelist; }
        }

        public Attributes Attributes
        {
            get { return attributes; }
            set { this.attributes = value; }
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary> 
        private Measure()
        {
             
        }

        public IBaseObject Clone()
        {
            Measure Temp = new Measure(this.notelist, this.attributes);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            bool equalNoteList = true;

            if (this.NoteList.Count != ((Measure) obj).NoteList.Count)
            {
                return false;
            }
            if (!this.Attributes.Equals(((Measure) obj).Attributes))
            {
                return false;
            }
            for (int i = 0; i < this.NoteList.Count; i++)
            {
                if (!this.NoteList[i].Equals(((Measure) obj).NoteList[i]))
                {
                    return false;
                }
            }

            return true;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }

        #endregion
    }
}
