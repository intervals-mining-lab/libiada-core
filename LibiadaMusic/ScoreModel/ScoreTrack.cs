using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    /// <summary>
    /// полный музыкальный текст/трек
    /// </summary>
    public class ScoreTrack : IBaseObject
    {
        public string Name { get; private set; }

        public List<UniformScoreTrack> UniformScoreTracks { get; private set; }

        //TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа, 
        //PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы
        public ScoreTrack(string name, List<UniformScoreTrack> uniformScoreTracks)
        {
            Name = name; // присваиваем имя музыкального трека
            UniformScoreTracks = new List<UniformScoreTrack>();
            for (int i = 0; i < uniformScoreTracks.Count; i++)
                // создаем список монотреков, по средствам клонирования каждого монотрека.
            {
                UniformScoreTracks.Add((UniformScoreTrack) uniformScoreTracks[i].Clone());
            }

            // ПОЛИФОНИЧЕСКАЯ ВСТАВКА
            var temp = (UniformScoreTrack) MergedTracks(UniformScoreTracks).Clone();
            UniformScoreTracks.Clear();
            UniformScoreTracks.Add(temp);
        }

        private UniformScoreTrack MergedTracks(List<UniformScoreTrack> tracks)
        {
            var temp = (UniformScoreTrack) tracks[0].Clone(); // список склеенных дорожек
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
            return new UniformScoreTrack(temp.Name, tempList);
        }

        public IBaseObject Clone()
        {
            return new ScoreTrack(Name, UniformScoreTracks);
        }

        public override bool Equals(object obj)
        {
            bool equalUniformScoreTracks = UniformScoreTracks.Count == ((ScoreTrack) obj).UniformScoreTracks.Count;

            for (int i = 0; i < UniformScoreTracks.Count; i++)
            {
                if (!UniformScoreTracks[i].Equals(((ScoreTrack) obj).UniformScoreTracks[i]))
                {
                    equalUniformScoreTracks = false;
                }
            }
            if (equalUniformScoreTracks)
            {
                return true;
            }
            return false;
        }
    }
}
