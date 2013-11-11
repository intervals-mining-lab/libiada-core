using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.BorodaDivider;

namespace MDA.ICL
{
    public static class AverageLength // средняя длина ф-мотива для моно цепи
    {
        static public double Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1) throw new Exception("Unaible to count average length with no elements in chain!");

            int NCount = 0; // счетчик нот всей цепочки фмотивов

            foreach(Fmotiv fmotiv in FmChain.FmotivList)
            {
                NCount = NCount + fmotiv.TieGathered().PauseTreatment(ParamPauseTreatment.Ignore).NoteList.Count; // заполняем счетчик складывая кол-во поф-мотивно
            }

            // два инта делятся, это необходимо чтоб вернуть дабл
            double val;
            val = NCount;
            val = val / FmChain.FmotivList.Count;
            return val;
        }
    }
}
