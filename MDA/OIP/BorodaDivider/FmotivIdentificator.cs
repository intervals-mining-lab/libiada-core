using System;
using System.Collections.Generic;
using System.Text;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivIdentificator
    {
        public FmotivChain GetIdentification(FmotivChain fmotivchain)
        {
            FmotivChain Temp = (FmotivChain)fmotivchain.Clone();

            for (int i = 0; i < Temp.FmotivList.Count; i++)
            {
                for (int j = i; j < Temp.FmotivList.Count; j++)
                {
                    if (Temp.FmotivList[i].Equals(Temp.FmotivList[j])) 
                    {
                        Temp.FmotivList[j].Id = Temp.FmotivList[i].Id;
                    }
                }
            }
            for (int i = 0; i < MaxId(Temp.FmotivList); i++) 
            {
                bool HaveId = false; // флаг того что есть такой id в цепочке
                for (int j = 0; j < Temp.FmotivList.Count; j++)
                {
                    if (!HaveId)
                    {
                        if (Temp.FmotivList[j].Id == i)
                        {
                            HaveId = true;
                            break;
                        }
                    }
                }
                if (!HaveId) 
                {
                    for (int j = 0; j < Temp.FmotivList.Count; j++)
                    {
                        if (Temp.FmotivList[j].Id > i)
                            {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                                Temp.FmotivList[j].Id = Temp.FmotivList[j].Id -1;
                            }
                    }
                    // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                    i=i-1;

                }
            }

                return Temp;
        }

        private int MaxId(List<Fmotiv> list)
        {
            int max = 0;
            foreach(Fmotiv fmotiv in list)
            {
                if (fmotiv.Id > max) { max = fmotiv.Id;}
            }
            return max;
        }
    }
}
