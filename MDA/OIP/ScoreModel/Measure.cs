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
        private int id; // уникальный идентификатор такта

        public Measure(List<Note> notelist, Attributes attributes)
        {
            if (attributes != null)
            {
                this.attributes = (Attributes)attributes.Clone();
            }

            this.notelist = new List<Note>();
            for (int i = 0; i < notelist.Count; i++) // создаем список нот, по средствам клонирования каждой ноты.
            {
                this.notelist.Add((Note)notelist[i].Clone());
            }
        }

        public int MergeMeasures(Measure measure)
        {
            int k = 0;
            List<Note> TempNoteList = new List<Note>(0);
            // проведём цикл до тех пор, пока номер текущей ноты не превышает количество нот в обоих тактах
            while ((k < this.notelist.Count) && (k < measure.notelist.Count))
                {
                    if (this.notelist[k].Duration.Equals(measure.notelist[k].Duration))
                    {
                        // ноты одинаковы по длине, можно просто склеить
                        this.notelist[k].AddPitch(measure.notelist[k].Pitch);
                    }
                    else if (this.notelist[k].Duration.Value < measure.notelist[k].Duration.Value)
                    {
                        // нота из склеенного массива короче, значит нужно вторую разделить на две и склеить
                        TempNoteList = new List<Note>(0);
                        TempNoteList.AddRange(measure.notelist[k].SplitNote(this.notelist[k].Duration));
                        measure.notelist.RemoveAt(k);
                        measure.notelist.InsertRange(k, TempNoteList);
                        this.notelist[k].AddPitch(measure.notelist[k].Pitch);
                    }
                    else
                    {
                        // нота из склеенного массива длиннее, значит надо её делить и клеить со второй
                        TempNoteList = new List<Note>(0);
                        TempNoteList.AddRange(this.notelist[k].SplitNote(measure.notelist[k].Duration));
                        this.notelist.RemoveAt(k);
                        this.notelist.InsertRange(k, TempNoteList);
                        this.notelist[k].AddPitch(measure.notelist[k].Pitch);
                    }
                    k++;
                }
            // теоретически на этом моменте у нас все ноты должны быть обработаны
            // хотя могло получиться, что в каком-то из тактов остались несклеенные ноты
            return 0;
        }

        public List<Note> NoteList
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
            set
            {
                this.attributes = value;
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

            if (this.NoteList.Count!= ((Measure)obj).NoteList.Count) 
            {
                return false;
            }
            if (!this.Attributes.Equals(((Measure)obj).Attributes))
            {
                return false;
            }
            for(int i=0; i < this.NoteList.Count; i++)
            {
                if (!this.NoteList[i].Equals(((Measure)obj).NoteList[i])) 
                {
                    return false;
                }
            }
            
            return true;
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
