using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack scoreTrack, int paramPause, int paramEqual)
        {
            var chains = new List<FmotivChain>();
            
            foreach (UniformScoreTrack uniformTrack in scoreTrack.UniformScoreTracks)
            {
                var fmotivChain = (FmotivChain) Divide(uniformTrack, paramPause, paramEqual).Clone();
                fmotivChain.Id = chains.Count;
                chains.Add(fmotivChain);
            }
            return chains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniformTrack"></param>
        /// <param name="paramPause">
        /// параметр как учитывать паузу : 
        /// игнорировать, звуковой след предыдущего звука, вырожденныый звук
        /// </param>
        /// <param name="paramEqual">как сравнивать ф-мотивы с секвентым переносом, либо нет</param>
        /// <returns></returns>
        public FmotivChain Divide(UniformScoreTrack uniformTrack, int paramPause, int paramEqual)
        {
            // сохраняем имя цепи фмотивов как имя монотрека

            var priorityDiscover = new PriorityDiscover();
            var fmotivDivider = new FmotivDivider();
            var fmotivIdentifier = new FmotivIdentifier();

            //подсчет приоритетов
            priorityDiscover.Calculate(uniformTrack);

            // разбиение
            FmotivChain chain = fmotivDivider.GetDivision(uniformTrack, paramPause);

            // нахождение одинаковых
            return fmotivIdentifier.GetIdentification(chain, paramPause, paramEqual);
        }
    }
}
