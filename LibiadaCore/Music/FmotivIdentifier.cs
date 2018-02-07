﻿namespace LibiadaCore.Music
{
    using System.Linq;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

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
        /// The <see cref="FmotifChain"/>.
        /// </returns>
        public FmotifChain GetIdentification(FmotifChain fmotivChain, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            var chain = (FmotifChain)fmotivChain.Clone();

            for (int i = 0; i < chain.FmotifsList.Count; i++)
            {
                for (int j = i; j < chain.FmotifsList.Count; j++)
                {
                    if (chain.FmotifsList[i].FmEquals(chain.FmotifsList[j], paramPauseTreatment, paramEqualFM))
                    {
                        chain.FmotifsList[j].Id = chain.FmotifsList[i].Id;
                    }
                }
            }

            for (int i = 0; i < chain.FmotifsList.Max(fl => fl.Id); i++)
            {
                bool haveId = chain.FmotifsList.Any(t => t.Id == i); // флаг того что есть такой id в цепочке
                if (!haveId)
                {
                    foreach (Fmotif fmotiv in chain.FmotifsList)
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
