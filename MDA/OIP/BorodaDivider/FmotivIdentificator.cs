using System.Linq;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivIdentificator
    {
        public FmotivChain GetIdentification(FmotivChain fmotivchain, PauseTreatment paramPause, FMSequentEquality paramEqual)
        {
            FmotivChain Temp = (FmotivChain) fmotivchain.Clone();

            for (int i = 0; i < Temp.Length; i++)
            {
                for (int j = i; j < Temp.Length; j++)
                {
                    if (((Fmotiv)Temp[i]).Equals(Temp[j], paramPause, paramEqual))
                        //if (Temp.FmotivList[i].Equals(Temp.FmotivList[j])) 
                    {
                        Temp.Building[j] = Temp.Building[i];
                    }
                }
            }
            for (int i = 1; i <= Temp.Building.Max(); i++)
            {
                bool HaveId = false; // флаг того что есть такой id в цепочке
                for (int j = 0; j < Temp.Length; j++)
                {
                    if (!HaveId)
                    {
                        if (Temp.Building[j] == i)
                        {
                            HaveId = true;
                            break;
                        }
                    }
                }
                if (!HaveId)
                {
                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (Temp.Building[j] > i)
                        {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                            Temp.Building[j] = Temp.Building[j] - 1;
                        }
                    }
                    // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                    i = i - 1;

                }
            }

            return Temp;
        }
    }
}
