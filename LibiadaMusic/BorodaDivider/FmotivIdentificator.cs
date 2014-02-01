using System.Collections.Generic;

namespace LibiadaMusic.BorodaDivider
{
    public class FmotivIdentificator
    {
        public FmotivChain GetIdentification(FmotivChain fmotivchain, int paramPause, int paramEqual)
        {
            var temp = (FmotivChain)fmotivchain.Clone();

            for (int i = 0; i < temp.FmotivList.Count; i++)
            {
                for (int j = i; j < temp.FmotivList.Count; j++)
                {
                    if (temp.FmotivList[i].FmEquals(temp.FmotivList[j], paramPause, paramEqual)) 
                    {
                        temp.FmotivList[j].Id = temp.FmotivList[i].Id;
                    }
                }
            }
            for (int i = 0; i < MaxId(temp.FmotivList); i++) 
            {
                bool HaveId = false; // флаг того что есть такой id в цепочке
                for (int j = 0; j < temp.FmotivList.Count; j++)
                {
                    if (!HaveId)
                    {
                        if (temp.FmotivList[j].Id == i)
                        {
                            HaveId = true;
                            break;
                        }
                    }
                }
                if (!HaveId) 
                {
                    for (int j = 0; j < temp.FmotivList.Count; j++)
                    {
                        if (temp.FmotivList[j].Id > i)
                            {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                                temp.FmotivList[j].Id = temp.FmotivList[j].Id -1;
                            }
                    }
                    // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                    i=i-1;

                }
            }

                return temp;
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
