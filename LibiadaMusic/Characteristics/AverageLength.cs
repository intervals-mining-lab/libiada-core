using System;
using LibiadaMusic.BorodaDivider;

namespace LibiadaMusic.Characteristics
{
    public static class AverageLength // средняя длина ф-мотива для моно цепи
    {
        public static double Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1)
                throw new Exception("Unaible to count average length with no elements in chain!");

            int NCount = 0; // счетчик нот всей цепочки фмотивов

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                NCount = NCount + fmotiv.TieGathered().PauseTreatment((int) ParamPauseTreatment.Ignore).NoteList.Count;
                    // заполняем счетчик складывая кол-во поф-мотивно
            }

            return (double) NCount/FmChain.FmotivList.Count;
        }
    }
}
