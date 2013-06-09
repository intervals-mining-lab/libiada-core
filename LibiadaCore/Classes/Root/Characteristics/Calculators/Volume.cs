using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Объём цепи. Произведение длин всех её интервалов.
    ///</summary>
    public class Volume : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            List<int> intervals = pChain.Intervals;
            double result = 1;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result =  result * intervals[i];
            }

            switch (Link)
            {
                case LinkUp.Start:
                    return result * intervals[0];
                case LinkUp.End:
                    return result * intervals[intervals.Count - 1];
                case LinkUp.Both:
                    return result * intervals[0] * intervals[intervals.Count - 1];
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double temp = 1;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp = temp * Calculate(pChain.UniformChain(i), Link);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Volume;
        }
    }
}