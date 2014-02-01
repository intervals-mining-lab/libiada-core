using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack strack, int paramPause, int paramEqual)
        {
            var temp = new List<FmotivChain>();

            foreach (UniformScoreTrack utrack in strack.UniformScoreTracks)
            {
                var fmchain = (FmotivChain) Divide(utrack, paramPause, paramEqual).Clone();
                fmchain.Id = temp.Count;
                temp.Add(fmchain);
            }
            return temp;
        }

        public FmotivChain Divide(UniformScoreTrack utrack, int paramPause, int paramEqual)
        {
            // paramPause - параметр как учитывать паузу : игнорировать, звуковой след предыдущего звука, вырожденныый звук
            // paramEqual - как сравнивать ф-мотивы с секвентым переносом, либо нет


            // сохраняем имя цепи фмотивов как имя монотрека

            var prioritydiscover = new PriorityDiscover();
            var fmdivider = new FmotivDivider();
            var fmident = new FmotivIdentificator();

            //подсчет приоритетов
            prioritydiscover.Calculate(utrack);

            // разбиение
            FmotivChain temp = fmdivider.GetDivision(utrack, paramPause);

            // нахождение одинаковых
            return fmident.GetIdentification(temp, paramPause, paramEqual);
        }
    }
}
