﻿namespace LibiadaCore.Music
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
        /// <param name="sequentialTransfer">
        /// The sequential transfer parameter.
        /// </param>
        /// <returns>
        /// The <see cref="List{FmotifChain}"/>.
        /// </returns>
        public List<FmotifChain> Divide(ScoreTrack scoreTrack, PauseTreatment pauseTreatment, bool sequentialTransfer)
        {
            var chains = new List<FmotifChain>();

            foreach (CongenericScoreTrack congenericTrack in scoreTrack.CongenericScoreTracks)
            {
                var fmotifChain = (FmotifChain)Divide(congenericTrack, pauseTreatment, sequentialTransfer).Clone();
                chains.Add(fmotifChain);
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
        /// <param name="sequentialTransfer">
        /// The sequential transfer parameter.
        /// как сравнивать ф-мотивы с секвентым переносом, либо нет
        /// </param>
        /// <returns>
        /// The <see cref="FmotifChain"/>.
        /// </returns>
        public FmotifChain Divide(CongenericScoreTrack congenericTrack, PauseTreatment pauseTreatment, bool sequentialTransfer)
        {
            // сохраняем имя цепи фмотивов как имя монотрека
            var priorityDiscover = new PriorityDiscover();
            var fmotifDivider = new FmotifDivider();
            var fmotifIdentifier = new FmotifIdentifier();

            // подсчет приоритетов
            priorityDiscover.Calculate(congenericTrack);

            // разбиение
            FmotifChain chain = fmotifDivider.GetDivision(congenericTrack, pauseTreatment);

            // нахождение одинаковых
            return fmotifIdentifier.GetIdentification(chain, sequentialTransfer);
        }
    }
}
