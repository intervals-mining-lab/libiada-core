namespace LibiadaMusic.ScoreModel
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    /// <summary>
    /// такт
    /// </summary>
    public class Measure : IBaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Measure"/> class.
        /// </summary>
        /// <param name="noteList">
        /// The note list.
        /// </param>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        public Measure(List<ValueNote> noteList, Attributes attributes)
        {
            if (attributes != null)
            {
                Attributes = (Attributes)attributes.Clone();
            }

            NoteList = new List<ValueNote>();

            // создаем список нот, по средствам клонирования каждой ноты.
            for (int i = 0; i < noteList.Count; i++) 
            {
                NoteList.Add((ValueNote)noteList[i].Clone());
            }
        }

        /// <summary>
        /// список нот, класса Note
        /// </summary>
        public List<ValueNote> NoteList { get; private set; }

        /// <summary>
        /// атрибуты
        /// </summary>
        public Attributes Attributes { get; private set; }

        /// <summary>
        /// уникальный идентификатор такта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The merge measures.
        /// </summary>
        /// <param name="measure">
        /// The measure.
        /// </param>
        public void MergeMeasures(Measure measure)
        {
            int k = 0;

            // проведём цикл до тех пор, пока номер текущей ноты не превышает количество нот в обоих тактах
            while ((k < NoteList.Count) && (k < measure.NoteList.Count))
            {
                if (NoteList[k].Duration.Equals(measure.NoteList[k].Duration))
                {
                    // ноты одинаковы по длине, можно просто склеить
                    NoteList[k].AddPitch(measure.NoteList[k].Pitch);
                }
                else
                {
                    var tempNoteList = new List<ValueNote>(0);
                    if (NoteList[k].Duration.Value < measure.NoteList[k].Duration.Value)
                    {
                        // нота из склеенного массива короче, значит нужно вторую разделить на две и склеить
                        tempNoteList.AddRange(measure.NoteList[k].SplitNote(NoteList[k].Duration));
                        measure.NoteList.RemoveAt(k);
                        measure.NoteList.InsertRange(k, tempNoteList);
                        NoteList[k].AddPitch(measure.NoteList[k].Pitch);
                    }
                    else
                    {
                        // нота из склеенного массива длиннее, значит надо её делить и клеить со второй
                        tempNoteList.AddRange(NoteList[k].SplitNote(measure.NoteList[k].Duration));
                        NoteList.RemoveAt(k);
                        NoteList.InsertRange(k, tempNoteList);
                        NoteList[k].AddPitch(measure.NoteList[k].Pitch);
                    }
                }

                k++;
            }

            // теоретически на этом моменте у нас все ноты должны быть обработаны
            // хотя могло получиться, что в каком-то из тактов остались несклеенные ноты
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var temp = new Measure(NoteList, Attributes);
            return temp;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (NoteList.Count != ((Measure)obj).NoteList.Count)
            {
                return false;
            }

            if (!Attributes.Equals(((Measure)obj).Attributes))
            {
                return false;
            }

            for (int i = 0; i < NoteList.Count; i++)
            {
                if (!NoteList[i].Equals(((Measure)obj).NoteList[i]))
                {
                    return false;
                }
            }

            return true;

            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }
    }
}
