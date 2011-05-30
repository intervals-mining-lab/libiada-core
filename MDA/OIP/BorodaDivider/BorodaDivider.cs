using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class BorodaDivider
    {
        public List<FmotivChain> Divide(ScoreTrack strack) 
        {
            List<FmotivChain> Temp = new List<FmotivChain>();

            foreach(UniformScoreTrack utrack in strack.UniformScoreTracks)
            {
                FmotivChain fmchain = (FmotivChain)this.Divide(utrack).Clone();
                fmchain.Id = Temp.Count;
                Temp.Add(fmchain);
            }
            return Temp;
        }

        public FmotivChain Divide(UniformScoreTrack utrack) 
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
            Temp = fmdivider.GetDivision(utrack);

            // нахождение одинаковых
            Temp = fmident.GetIdentification(Temp);

            return Temp;
        }
    }
}
