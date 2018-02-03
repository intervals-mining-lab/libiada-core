namespace LibiadaCore.Music
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

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
        /// <param name="paramEqualFM">
        /// The param equal fm.
        /// </param>
        /// <returns>
        /// The <see cref="List{FmotivChain}"/>.
        /// </returns>
        public List<FmotivChain> Divide(ScoreTrack scoreTrack, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            var chains = new List<FmotivChain>();

            foreach (CongenericScoreTrack congenericTrack in scoreTrack.CongenericScoreTracks)
            {
                var fmotivChain = (FmotivChain)Divide(congenericTrack, paramPauseTreatment, paramEqualFM).Clone();
                fmotivChain.Id = chains.Count;
                chains.Add(fmotivChain);
            }

            return chains;
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
        /// <param name="paramEqualFM">
        /// The param equal fm.
        /// как сравнивать ф-мотивы с секвентым переносом, либо нет
        /// </param>
        /// <returns>
        /// The <see cref="FmotivChain"/>.
        /// </returns>
        public FmotivChain Divide(CongenericScoreTrack congenericTrack, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            // сохраняем имя цепи фмотивов как имя монотрека
            var priorityDiscover = new PriorityDiscover();
            var fmotivDivider = new FmotivDivider();
            var fmotivIdentifier = new FmotivIdentifier();

            // подсчет приоритетов
            priorityDiscover.Calculate(congenericTrack);

            // разбиение
            FmotivChain chain = fmotivDivider.GetDivision(congenericTrack, paramPauseTreatment);

            // нахождение одинаковых
            return fmotivIdentifier.GetIdentification(chain, paramPauseTreatment, paramEqualFM);
        }
    }
}
