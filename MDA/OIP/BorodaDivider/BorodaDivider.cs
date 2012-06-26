using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack strack, int paramPause, int paramEqual) 
        {
            List<FmotivChain> Temp = new List<FmotivChain>();

            foreach(UniformScoreTrack utrack in strack.UniformScoreTracks)
            {
                FmotivChain fmchain = (FmotivChain)this.Divide(utrack, paramPause, paramEqual).Clone();
                fmchain.Id = Temp.Count;
                Temp.Add(fmchain);
            }
            return Temp;
        }

        public FmotivChain Divide(UniformScoreTrack utrack, int paramPause, int paramEqual) 
        {
            // paramPause - параметр как учитывать паузу : игнорировать, звуковой след предыдущего звука, вырожденныый звук
            // paramEqual - как сравнивать ф-мотивы с секвентым переносом, либо нет


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
