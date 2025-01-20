namespace Libiada.Core.Music;

using Libiada.Core.Core;

/// <summary>
/// The boroda divider.
/// </summary>
public class BorodaDivider
{
    /// <summary>
    /// The divide.
    /// </summary>
    /// <param name="scoreTrack">
    /// The score track.
    /// </param>
    /// <param name="paramPauseTreatment">
    /// The param pause treatment.
    /// </param>
    /// <param name="sequentialTransfer">
    /// The sequential transfer parameter.
    /// </param>
    /// <returns>
    /// The <see cref="List{Libiada.Core.Core.FmotifSequence}"/>.
    /// </returns>
    public List<FmotifSequence> Divide(ScoreTrack scoreTrack, PauseTreatment pauseTreatment, bool sequentialTransfer)
    {
        List<FmotifSequence> sequences = [];

        foreach (CongenericScoreTrack congenericTrack in scoreTrack.CongenericScoreTracks)
        {
            FmotifSequence fmotifSequence = (FmotifSequence)Divide(congenericTrack, pauseTreatment, sequentialTransfer).Clone();
            sequences.Add(fmotifSequence);
        }

        return sequences;
    }

    /// <summary>
    /// The divide.
    /// </summary>
    /// <param name="congenericTrack">
    /// The congeneric track.
    /// </param>
    /// <param name="paramPauseTreatment">
    /// The param pause treatment.
    /// параметр как учитывать паузу :
    /// игнорировать, звуковой след предыдущего звука, вырожденныый звук
    /// </param>
    /// <param name="sequentialTransfer">
    /// The sequential transfer parameter.
    /// как сравнивать ф-мотивы с секвентым переносом, либо нет
    /// </param>
    /// <returns>
    /// The <see cref="FmotifSequence"/>.
    /// </returns>
    public FmotifSequence Divide(CongenericScoreTrack congenericTrack, PauseTreatment pauseTreatment, bool sequentialTransfer)
    {
        // сохраняем имя цепи фмотивов как имя монотрека
        PriorityDiscover priorityDiscover = new();
        FmotifDivider fmotifDivider = new();
        FmotifIdentifier fmotifIdentifier = new();

        // подсчет приоритетов
        priorityDiscover.Calculate(congenericTrack);

        // разбиение
        FmotifSequence sequence = fmotifDivider.GetDivision(congenericTrack, pauseTreatment);

        // нахождение одинаковых
        return fmotifIdentifier.GetIdentification(sequence, sequentialTransfer);
    }
}
