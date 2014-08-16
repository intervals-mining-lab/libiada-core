﻿using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack scoreTrack, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            var chains = new List<FmotivChain>();
            
            foreach (CongenericScoreTrack congenericTrack in scoreTrack.CongenericScoreTracks)
            {
                var fmotivChain = (FmotivChain) Divide(congenericTrack, paramPauseTreatment, paramEqualFM).Clone();
                fmotivChain.Id = chains.Count;
                chains.Add(fmotivChain);
            }
            return chains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="congenericTrack"></param>
        /// <param name="paramPauseTreatment">
        /// параметр как учитывать паузу : 
        /// игнорировать, звуковой след предыдущего звука, вырожденныый звук
        /// </param>
        /// <param name="paramEqualFM">как сравнивать ф-мотивы с секвентым переносом, либо нет</param>
        /// <returns></returns>
        public FmotivChain Divide(CongenericScoreTrack congenericTrack, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            // сохраняем имя цепи фмотивов как имя монотрека

            var priorityDiscover = new PriorityDiscover();
            var fmotivDivider = new FmotivDivider();
            var fmotivIdentifier = new FmotivIdentifier();

            //подсчет приоритетов
            priorityDiscover.Calculate(congenericTrack);

            // разбиение
            FmotivChain chain = fmotivDivider.GetDivision(congenericTrack, paramPauseTreatment);

            // нахождение одинаковых
            return fmotivIdentifier.GetIdentification(chain, paramPauseTreatment, paramEqualFM);
        }
    }
}