using System.Linq;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace LibiadaCore.Music
{
    /// <summary>
    /// The fmotiv identifier.
    /// </summary>
    public class FmotivIdentifier
    {
        /// <summary>
        /// The get identification.
        /// </summary>
        /// <param name="fmotivChain">
        /// The fmotiv chain.
        /// </param>
        /// <param name="paramPauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <param name="paramEqualFM">
        /// The param equal fm.
        /// </param>
        /// <returns>
        /// The <see cref="FmotivChain"/>.
        /// </returns>
        public FmotivChain GetIdentification(FmotivChain fmotivChain, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            var chain = (FmotivChain)fmotivChain.Clone();

            for (int i = 0; i < chain.FmotivList.Count; i++)
            {
                for (int j = i; j < chain.FmotivList.Count; j++)
                {
                    if (chain.FmotivList[i].FmEquals(chain.FmotivList[j], paramPauseTreatment, paramEqualFM))
                    {
                        chain.FmotivList[j].Id = chain.FmotivList[i].Id;
                    }
                }
            }

            for (int i = 0; i < chain.FmotivList.Max(fl => fl.Id); i++)
            {
                bool haveId = chain.FmotivList.Any(t => t.Id == i); // флаг того что есть такой id в цепочке
                if (!haveId)
                {
                    foreach (Fmotiv fmotiv in chain.FmotivList)
                    {
                        if (fmotiv.Id > i)
                        {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                            fmotiv.Id--;
                        }
                    }

                    // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                    i--;
                }
            }

            return chain;
        }
    }
}
