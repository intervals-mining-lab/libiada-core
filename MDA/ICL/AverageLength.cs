﻿using System;
using MDA.OIP.BorodaDivider;

namespace MDA.ICL
{
    /// <summary>
    /// средняя длина ф-мотива для моно цепи
    /// </summary>
    public static class AverageLength
    {
        public static double Calculate(FmotivChain fmChain)
        {
            if (fmChain.Length < 1)
                throw new Exception("Unaible to count average length with no elements in chain!");

            int NCount = 0; // счетчик нот всей цепочки фмотивов

            for (int i = 0; i < fmChain.Length; i++)
            {
                NCount = NCount + ((Fmotiv)fmChain[i]).TieGathered().Clone(PauseTreatment.Ignore).NoteList.Count;
                // заполняем счетчик складывая кол-во поф-мотивно
            }

            // два инта делятся, это необходимо чтоб вернуть дабл
            double val;
            val = NCount;
            val = val/fmChain.Length;
            return val;
        }
    }
}
