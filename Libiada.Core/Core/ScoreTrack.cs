namespace Libiada.Core.Core;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Represents complete music track (text / sequence).
/// </summary>
public class ScoreTrack : IBaseObject
{
    // TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа,
    // PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы

    /// <summary>
    /// Gets congeneric tracks list.
    /// </summary>
    public readonly List<CongenericScoreTrack> CongenericScoreTracks = new List<CongenericScoreTrack>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreTrack"/> class.
    /// </summary>
    /// <param name="congenericScoreTracks">
    /// The congeneric score tracks.
    /// </param>
    public ScoreTrack(List<CongenericScoreTrack> congenericScoreTracks)
    {
        foreach (CongenericScoreTrack congenericScoreTrack in congenericScoreTracks)
        {
            // создаем список монотреков, посредством клонирования каждого монотрека.
            CongenericScoreTracks.Add((CongenericScoreTrack)congenericScoreTrack.Clone());
        }

        // ПОЛИФОНИЧЕСКАЯ ВСТАВКА
        var temp = (CongenericScoreTrack)MergedTracks(CongenericScoreTracks).Clone();
        CongenericScoreTracks.Clear();
        CongenericScoreTracks.Add(temp);
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone()
    {
        return new ScoreTrack(CongenericScoreTracks);
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
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is ScoreTrack other && CongenericScoreTracks.SequenceEqual(other.CongenericScoreTracks);
    }

    /// <summary>
    /// Calculates hash code using <see cref="CongenericScoreTracks"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = -2011207718;
            foreach (CongenericScoreTrack scoreTrack in CongenericScoreTracks)
            {
                hashCode = (hashCode * -1521134295) + scoreTrack.GetHashCode();
            }

            return hashCode;
        }
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

        return new CongenericScoreTrack(tempList);
    }
}
