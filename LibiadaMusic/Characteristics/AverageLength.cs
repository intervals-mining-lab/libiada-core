using System;
using LibiadaMusic.BorodaDivider;

namespace LibiadaMusic.Characteristics
{
    /// <summary>
    /// средняя длина ф-мотива для моно цепи
    /// </summary>
    public static class AverageLength
    {
        public static double Calculate(FmotivChain chain)
        {
            if (chain.FmotivList.Count < 1)
            {
                throw new Exception("Unable to count average length with no elements in chain!");
            }
                

            int noteCount = 0; // счетчик нот всей цепочки фмотивов

            foreach (Fmotiv fmotiv in chain.FmotivList)
            {
                noteCount = noteCount + fmotiv.TieGathered().PauseTreatment((int) ParamPauseTreatment.Ignore).NoteList.Count;
                    // заполняем счетчик складывая кол-во поф-мотивно
            }

            return (double) noteCount/chain.FmotivList.Count;
        }
    }
}
