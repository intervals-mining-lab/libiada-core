using System.Collections.Generic;

namespace LibiadaMusic.ScoreModel
{
    using LibiadaCore.Core;

    public class UniformScoreTrack : IBaseObject // монофонический (моно) трек
    {
        public string Name { get; private set; }

        public List<Measure> MeasureList { get; private set; }

        public UniformScoreTrack(string name, List<Measure> measureList)
        {
            MeasureList = new List<Measure>();
            for (int i = 0; i < measureList.Count; i++)
                // создаем список тактов, по средствам клонирования каждого такта.
            {
                MeasureList.Add((Measure) measureList[i].Clone());
            }
            Name = name;
        }

        // возвращает строй объектов Note, проидентифицировав их
        public List<ValueNote> NoteOrder()
        {
            var temp = new List<ValueNote>();
            //запись в одну цепочку
            foreach (Measure measure in MeasureList)
            {
                foreach (ValueNote note in measure.NoteList)
                {
                    temp.Add((ValueNote) note.Clone());
                }
            }

            // идентификация
            temp[0].Id = 0; // первая нота обозначается 0
            int n = 1; // счетчик для уникальных

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
                //если ранее не встречалась эта нота, то назначим ей новый id
                if (!identified)
                {
                    temp[i].Id = n; // назанчим еще не использованный по возрастанию id
                    n = n + 1; // увеличиваем счетчик уникальных
                }
            }

            return temp;

        }

        // возвращает строй нот (в виде цепи натуральных чисел начиная с 0)
        public int[] NoteIdOrder()
        {
            List<ValueNote> temp = NoteOrder();

            var idTemp = new int[temp.Count]; // строй из Id, а не из объектов типа Note
            for (int i = 0; i < temp.Count; i++)
            {
                idTemp[i] = temp[i].Id;
            }
            return idTemp;
        }

        // возвращает строй объектов Measure, проидентифицировав их
        public List<Measure> MeasureOrder()
        {
            var temp = new List<Measure>();
            //запись в одну цепочку
            foreach (Measure measure in MeasureList)
            {
                temp.Add((Measure) measure.Clone());
            }

            // идентификация
            temp[0].Id = 0; // первый такт обозначается 0
            int n = 1; // счетчик для уникальных

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
                //если ранее не встречался этот такт, то назначим ему новый id
                if (!identified)
                {
                    temp[i].Id = n; // назанчим еще не использованный по возрастанию id
                    n = n + 1; // увеличиваем счетчик уникальных
                }
            }
            return temp;
        }

        // возвращает строй тактов (в виде цепи натуральных чисел начиная с 0)
        public int[] MeasureIdOrder()
        {
            List<Measure> temp = MeasureOrder();

            var idTemp = new int[temp.Count]; // строй из Id, а не из объектов типа Measure
            for (int i = 0; i < temp.Count; i++)
            {
                idTemp[i] = temp[i].Id;
            }
            return idTemp;
        }

        public IBaseObject Clone()
        {
            return new UniformScoreTrack(Name, MeasureList);
        }

        public override bool Equals(object obj)
        {
            bool equalMeasureList = MeasureList.Count == ((UniformScoreTrack) obj).MeasureList.Count;

            for (int i = 0; i < MeasureList.Count; i++)
            {
                if (!MeasureList[i].Equals(((UniformScoreTrack) obj).MeasureList[i]))
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