using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// монофонический (моно) трек
    /// </summary>
    public class UniformScoreTrack : IBaseObject
    {
        /// <summary>
        ///  название моно дорожки (по инструменту или партии)
        /// </summary>
        private string name;

        /// <summary>
        /// список тактов моно дорожки
        /// </summary>
        private List<Measure> measurelist;

        public UniformScoreTrack(string name, List<Measure> measurelist)
        {
            this.measurelist = new List<Measure>();
            for (int i = 0; i < measurelist.Count; i++)
                // создаем список тактов, по средствам клонирования каждого такта.
            {
                this.measurelist.Add((Measure) measurelist[i].Clone());
            }
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public List<Measure> Measurelist
        {
            get { return measurelist; }
        }

        /// <summary>
        /// возвращает строй объектов Note, проидентифицировав их
        /// </summary>
        /// <returns></returns>
        public List<Note> NoteOrder()
        {
            List<Note> Temp = new List<Note>();
            //запись в одну цепочку
            foreach (Measure measure in Measurelist)
            {
                foreach (Note note in measure.NoteList)
                {
                    Temp.Add((Note) note.Clone());
                }
            }

            // идентификация
            Temp[0].Id = 0; // первая нота обозначается 0
            int n = 1; // счетчик для уникальных

            // для остальных процедура цикла
            for (int i = 1; i < Temp.Count; i++)
            {
                // флаг если уже идентифицированна нота
                bool Identifyed = false;

                for (int j = 0; j < i; j++)
                {
                    if (Temp[i].Equals(Temp[j]))
                    {
                        // еси уже такая идентифицировалась
                        Temp[i].Id = Temp[j].Id;
                        Identifyed = true;
                    }
                }
                //если ранее не встречалась эта нота, то назначим ей новый id
                if (!Identifyed)
                {
                    Temp[i].Id = n; // назанчим еще не использованный по возрастанию id
                    n = n + 1; // увеличиваем счетчик уникальных
                }
            }

            return Temp;

        }

        /// <summary>
        /// возвращает строй нот (в виде цепи натуральных чисел начиная с 0)
        /// </summary>
        /// <returns></returns>
        public int[] NoteIdOrder()
        {
            List<Note> Temp = new List<Note>();
            Temp = this.NoteOrder();

            int[] IdTemp = new int[Temp.Count]; // строй из Id, а не из объектов типа Note
            for (int i = 0; i < Temp.Count; i++)
            {
                IdTemp[i] = Temp[i].Id;
            }
            return IdTemp;
        }

        /// <summary>
        /// возвращает строй объектов Measure, проидентифицировав их
        /// </summary>
        /// <returns></returns>
        public List<Measure> MeasureOrder()
        {
            List<Measure> Temp = new List<Measure>();
            //запись в одну цепочку
            foreach (Measure measure in Measurelist)
            {
                Temp.Add((Measure) measure.Clone());
            }

            // идентификация
            Temp[0].Id = 0; // первый такт обозначается 0
            int n = 1; // счетчик для уникальных

            // для остальных процедура цикла
            for (int i = 1; i < Temp.Count; i++)
            {
                // флаг если уже идентифицирован такт
                bool Identifyed = false;

                for (int j = 0; j < i; j++)
                {
                    if (Temp[i].Equals(Temp[j]))
                    {
                        // еси уже такой идентифицировался
                        Temp[i].Id = Temp[j].Id;
                        Identifyed = true;
                    }
                }
                //если ранее не встречался этот такт, то назначим ему новый id
                if (!Identifyed)
                {
                    Temp[i].Id = n; // назанчим еще не использованный по возрастанию id
                    n = n + 1; // увеличиваем счетчик уникальных
                }
            }

            return Temp;

        }

        /// <summary>
        /// возвращает строй тактов (в виде цепи натуральных чисел начиная с 0)
        /// </summary>
        /// <returns></returns>
        public int[] MeasureIdOrder()
        {
            List<Measure> Temp = new List<Measure>();
            Temp = this.MeasureOrder();

            int[] IdTemp = new int[Temp.Count]; // строй из Id, а не из объектов типа Measure
            for (int i = 0; i < Temp.Count; i++)
            {
                IdTemp[i] = Temp[i].Id;
            }
            return IdTemp;
        }

        #region IBaseMethods

        private UniformScoreTrack()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            UniformScoreTrack Temp = new UniformScoreTrack(this.name, this.measurelist);
            return Temp;
        }

        public bool Equals(object obj)
        {
            bool equalMeasureList = true;

            if (this.Measurelist.Count != ((UniformScoreTrack) obj).Measurelist.Count)
            {
                equalMeasureList = false;
            }
            for (int i = 0; i < this.Measurelist.Count; i++)
            {
                if (!this.Measurelist[i].Equals(((UniformScoreTrack) obj).Measurelist[i]))
                {
                    equalMeasureList = false;
                }
            }
            if (equalMeasureList)
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            UniformScoreTrackBin Temp = new UniformScoreTrackBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class UniformScoreTrackBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new UniformScoreTrack();
            }
        }

        #endregion
    }
}
