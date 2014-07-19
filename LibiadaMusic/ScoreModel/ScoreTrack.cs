using System;
using System.Collections.Generic;

namespace LibiadaMusic.ScoreModel
{
    using LibiadaCore.Core;

    /// <summary>
    /// полный музыкальный текст/трек
    /// </summary>
    public class ScoreTrack : IBaseObject
    {
        /// <summary>
        /// имя музыкального текста ( муз. произведения)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// список моно треков
        /// </summary>
        public List<CongenericScoreTrack> CongenericScoreTracks { get; private set; }

        //TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа, 
        //PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы
        public ScoreTrack(string name, List<CongenericScoreTrack> congenericScoreTracks)
        {
            Name = name; // присваиваем имя музыкального трека
            CongenericScoreTracks = new List<CongenericScoreTrack>();
            for (int i = 0; i < congenericScoreTracks.Count; i++)
                // создаем список монотреков, по средствам клонирования каждого монотрека.
            {
                CongenericScoreTracks.Add((CongenericScoreTrack) congenericScoreTracks[i].Clone());
            }

            // ПОЛИФОНИЧЕСКАЯ ВСТАВКА
            var temp = (CongenericScoreTrack) MergedTracks(CongenericScoreTracks).Clone();
            CongenericScoreTracks.Clear();
            CongenericScoreTracks.Add(temp);
        }

        private CongenericScoreTrack MergedTracks(List<CongenericScoreTrack> tracks)
        {
            var temp = (CongenericScoreTrack) tracks[0].Clone(); // список склеенных дорожек
            var tempList = new List<Measure>(temp.MeasureList); //список склеенных тактов
            for (int i = 1; i < tracks.Count; i++)
            {
                if (tempList.Count != tracks[i].MeasureList.Count)
                    throw new Exception("ScoreTrack: invalid measure count");
                for (int j = 0; j < temp.MeasureList.Count; j++)
                {
                    // склеивание j-тых тактов
                    var tempMeasure = (Measure) tracks[i].MeasureList[j].Clone();
                    tempMeasure.MergeMeasures(tempList[j]);
                    tempList.RemoveAt(j);
                    tempList.Insert(j, tempMeasure);
                }
            }
            return new CongenericScoreTrack(temp.Name, tempList);
        }

        public IBaseObject Clone()
        {
            return new ScoreTrack(Name, CongenericScoreTracks);
        }

        public override bool Equals(object obj)
        {
            bool equalCongenericScoreTracks = CongenericScoreTracks.Count == ((ScoreTrack) obj).CongenericScoreTracks.Count;

            for (int i = 0; i < CongenericScoreTracks.Count; i++)
            {
                if (!CongenericScoreTracks[i].Equals(((ScoreTrack) obj).CongenericScoreTracks[i]))
                {
                    equalCongenericScoreTracks = false;
                }
            }
            if (equalCongenericScoreTracks)
            {
                return true;
            }
            return false;
        }
    }
}
