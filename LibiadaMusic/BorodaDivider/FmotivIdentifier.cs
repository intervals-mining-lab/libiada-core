using System.Collections.Generic;
using System.Linq;

namespace LibiadaMusic.BorodaDivider
{
    public class FmotivIdentifier
    {
        public FmotivChain GetIdentification(FmotivChain fmotivChain, int paramPause, int paramEqual)
        {
            var chain = (FmotivChain) fmotivChain.Clone();

            for (int i = 0; i < chain.FmotivList.Count; i++)
            {
                for (int j = i; j < chain.FmotivList.Count; j++)
                {
                    if (chain.FmotivList[i].FmEquals(chain.FmotivList[j], paramPause, paramEqual))
                    {
                        chain.FmotivList[j].Id = chain.FmotivList[i].Id;
                    }
                }
            }
            for (int i = 0; i < MaxId(chain.FmotivList); i++)
            {
                bool haveId = chain.FmotivList.Any(t => t.Id == i); // флаг того что есть такой id в цепочке
                if (!haveId)
                {
                    for (int j = 0; j < chain.FmotivList.Count; j++)
                    {
                        if (chain.FmotivList[j].Id > i)
                        {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                            chain.FmotivList[j].Id = chain.FmotivList[j].Id - 1;
                        }
                    }
                    // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                    i = i - 1;
                }
            }
            return chain;
        }

        private int MaxId(IEnumerable<Fmotiv> list)
        {
            return list.Max(f => f.Id);;
        }
    }
}