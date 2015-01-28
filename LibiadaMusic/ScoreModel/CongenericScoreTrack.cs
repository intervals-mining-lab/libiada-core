namespace LibiadaMusic.ScoreModel
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    /// <summary>
    /// The congeneric score track.
    /// монофонический (моно) трек
    /// </summary>
    public class CongenericScoreTrack : IBaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericScoreTrack"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="measureList">
        /// The measure list.
        /// </param>
        public CongenericScoreTrack(string name, List<Measure> measureList)
        {
            MeasureList = new List<Measure>();
            for (int i = 0; i < measureList.Count; i++)
            {
                // создаем список тактов, по средствам клонирования каждого такта.
                MeasureList.Add((Measure)measureList[i].Clone());
            }

            Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the measure list.
        /// </summary>
        public List<Measure> MeasureList { get; private set; }

        /// <summary>
        /// The note order.
        /// возвращает строй объектов Note, проидентифицировав их
        /// </summary>
        /// <returns>
        /// The <see cref="List{ValueNote}"/>.
        /// </returns>
        public List<ValueNote> NoteOrder()
        {
            var temp = new List<ValueNote>();

            // запись в одну цепочку
            foreach (Measure measure in MeasureList)
            {
                foreach (ValueNote note in measure.NoteList)
                {
                    temp.Add((ValueNote)note.Clone());
                }
            }

            // идентификация
            // первая нота обозначается 0
            temp[0].Id = 0;

            // счетчик для уникальных
            int n = 1; 

            // для остальных процедура цикла
            for (int i = 1; i < temp.Count; i++)
            {
                // флаг если уже идентифицированна нота
                bool identified = false;

                for (int j = 0; j < i; j++)
                {
                    if (temp[i].Equals(temp[j]))
                    {
                        // еси уже такая идентифицировалась
                        temp[i].Id = temp[j].Id;
                        identified = true;
                    }
                }

                // если ранее не встречалась эта нота, то назначим ей новый id
                if (!identified)
                {
                    // назанчим еще не использованный по возрастанию id
                    temp[i].Id = n;

                    // увеличиваем счетчик уникальных
                    n = n + 1; 
                }
            }

            return temp;
        }

        /// <summary>
        /// The note id order.
        /// возвращает строй нот (в виде цепи натуральных чисел начиная с 0)
        /// </summary>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        public int[] NoteIdOrder()
        {
            List<ValueNote> temp = NoteOrder();

            // строй из Id, а не из объектов типа Note
            var idTemp = new int[temp.Count]; 
            for (int i = 0; i < temp.Count; i++)
            {
                idTemp[i] = temp[i].Id;
            }

            return idTemp;
        }

        /// <summary>
        /// The measure order.
        /// возвращает строй объектов Measure, проидентифицировав их
        /// </summary>
        /// <returns>
        /// The <see cref="List{Measure}"/>.
        /// </returns>
        public List<Measure> MeasureOrder()
        {
            var temp = new List<Measure>();

            // запись в одну цепочку
            foreach (Measure measure in MeasureList)
            {
                temp.Add((Measure)measure.Clone());
            }

            // идентификация
            // первый такт обозначается 0
            temp[0].Id = 0;

            // счетчик для уникальных
            int n = 1; 

            // для остальных процедура цикла
            for (int i = 1; i < temp.Count; i++)
            {
                // флаг если уже идентифицирован такт
                bool identified = false;

                for (int j = 0; j < i; j++)
                {
                    if (temp[i].Equals(temp[j]))
                    {
                        // еси уже такой идентифицировался
                        temp[i].Id = temp[j].Id;
                        identified = true;
                    }
                }

                // если ранее не встречался этот такт, то назначим ему новый id
                if (!identified)
                {
                    // назанчим еще не использованный по возрастанию id
                    temp[i].Id = n;

                    // увеличиваем счетчик уникальных
                    n = n + 1; 
                }
            }

            return temp;
        }

        /// <summary>
        /// The measure id order.
        /// возвращает строй тактов (в виде цепи натуральных чисел начиная с 0)
        /// </summary>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        public int[] MeasureIdOrder()
        {
            List<Measure> temp = MeasureOrder();

            // строй из Id, а не из объектов типа Measure
            var idTemp = new int[temp.Count]; 
            for (int i = 0; i < temp.Count; i++)
            {
                idTemp[i] = temp[i].Id;
            }

            return idTemp;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new CongenericScoreTrack(Name, MeasureList);
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
            bool equalMeasureList = MeasureList.Count == ((CongenericScoreTrack)obj).MeasureList.Count;

            for (int i = 0; i < MeasureList.Count; i++)
            {
                if (!MeasureList[i].Equals(((CongenericScoreTrack)obj).MeasureList[i]))
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
    }
}
