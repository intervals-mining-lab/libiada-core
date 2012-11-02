using System.Collections.Generic;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack strack, PauseTreatment paramPause, FMSequentEquality paramEqual)
        {
            List<FmotivChain> Temp = new List<FmotivChain>();

            foreach (UniformScoreTrack utrack in strack.UniformScoreTracks)
            {
                FmotivChain fmchain = this.Divide(utrack, paramPause, paramEqual).CloneChain();
                Temp.Add(fmchain);
            }
            return Temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utrack"></param>
        /// <param name="paramPause">параметр как учитывать паузу : игнорировать, звуковой след предыдущего звука, вырожденныый звук</param>
        /// <param name="paramEqual">как сравнивать ф-мотивы с секвентым переносом, либо нет</param>
        /// <returns></returns>
        public FmotivChain Divide(UniformScoreTrack utrack, PauseTreatment paramPause, FMSequentEquality paramEqual)
        {
            FmotivChain Temp = new FmotivChain();
            // сохраняем имя цепи фмотивов как имя монотрека
            Temp.Name = utrack.Name;

            PriorityDiscover prioritydiscover = new PriorityDiscover();
            FmotivDivider fmdivider = new FmotivDivider();
            FmotivIdentificator fmident = new FmotivIdentificator();

            //подсчет приоритетов
            prioritydiscover.Calculate(utrack);

            // разбиение
            Temp = fmdivider.GetDivision(utrack, paramPause);

            // нахождение одинаковых
            Temp = fmident.GetIdentification(Temp, paramPause, paramEqual);

            return Temp;
        }
    }
}
