namespace LibiadaMusic.ScoreModel
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    /// <summary>
    /// полный музыкальный текст/трек
    /// </summary>
    public class ScoreTrack : IBaseObject
    {
        // TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа, 
        // PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreTrack"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="congenericScoreTracks">
        /// The congeneric score tracks.
        /// </param>
        public ScoreTrack(string name, List<CongenericScoreTrack> congenericScoreTracks)
        {
            Name = name; // присваиваем имя музыкального трека
            CongenericScoreTracks = new List<CongenericScoreTrack>();
            for (int i = 0; i < congenericScoreTracks.Count; i++)
            {
                // создаем список монотреков, по средствам клонирования каждого монотрека.
                CongenericScoreTracks.Add((CongenericScoreTrack)congenericScoreTracks[i].Clone());
            }

            // ПОЛИФОНИЧЕСКАЯ ВСТАВКА
            var temp = (CongenericScoreTrack)MergedTracks(CongenericScoreTracks).Clone();
            CongenericScoreTracks.Clear();
            CongenericScoreTracks.Add(temp);
        }

        /// <summary>
        /// Gets name of music track.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets congeneric tracks list.
        /// </summary>
        public List<CongenericScoreTrack> CongenericScoreTracks { get; private set; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new ScoreTrack(Name, CongenericScoreTracks);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            bool equalCongenericScoreTracks = CongenericScoreTracks.Count == ((ScoreTrack)obj).CongenericScoreTracks.Count;

            for (int i = 0; i < CongenericScoreTracks.Count; i++)
            {
                if (!CongenericScoreTracks[i].Equals(((ScoreTrack)obj).CongenericScoreTracks[i]))
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

        /// <summary>
        /// The merged tracks.
        /// </summary>
        /// <param name="tracks">
        /// The tracks.
        /// </param>
        /// <returns>
        /// The <see cref="CongenericScoreTrack"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private CongenericScoreTrack MergedTracks(List<CongenericScoreTrack> tracks)
        {
            // список склеенных дорожек
            var temp = (CongenericScoreTrack)tracks[0].Clone();

            // список склеенных тактов
            var tempList = new List<Measure>(temp.MeasureList); 
            for (int i = 1; i < tracks.Count; i++)
            {
                if (tempList.Count != tracks[i].MeasureList.Count)
                {
                    throw new Exception("ScoreTrack: invalid measure count");
                }

                for (int j = 0; j < temp.MeasureList.Count; j++)
                {
                    // склеивание j-тых тактов
                    var tempMeasure = (Measure)tracks[i].MeasureList[j].Clone();
                    tempMeasure.MergeMeasures(tempList[j]);
                    tempList.RemoveAt(j);
                    tempList.Insert(j, tempMeasure);
                }
            }

            return new CongenericScoreTrack(temp.Name, tempList);
        }
    }
}
