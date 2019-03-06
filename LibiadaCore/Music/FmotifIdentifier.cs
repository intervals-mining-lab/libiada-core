namespace LibiadaCore.Music
{
    using System.Linq;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The fmotif identifier.
    /// </summary>
    public class FmotifIdentifier
    {
        /// <summary>
        /// The get identification.
        /// </summary>
        /// <param name="fmotifChain">
        /// The fmotif chain.
        /// </param>
        /// <param name="pauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <param name="sequentialTransfer">
        /// The sequential transfer parameter.
        /// </param>
        /// <returns>
        /// The <see cref="FmotifChain"/>.
        /// </returns>
        public FmotifChain GetIdentification(FmotifChain fmotifChain, PauseTreatment pauseTreatment, bool sequentialTransfer)
        {
            var chain = (FmotifChain)fmotifChain.Clone();

            for (int i = 0; i < chain.FmotifsList.Count; i++)
            {
                for (int j = i; j < chain.FmotifsList.Count; j++)
                {
                    if (chain.FmotifsList[i].FmEquals(chain.FmotifsList[j], pauseTreatment, sequentialTransfer))
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
                    foreach (Fmotif fmotif in chain.FmotifsList)
                    {
                        if (fmotif.Id > i)
                        {
                            // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                            fmotif.Id--;
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
