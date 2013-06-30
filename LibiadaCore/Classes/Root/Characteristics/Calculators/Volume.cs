using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Объём цепи. Произведение длин всех её интервалов.
    ///</summary>
    public class Volume : ICalculator
    {
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            List<int> intervals = chain.Intervals;
            double result = 1;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result =  result * intervals[i];
            }

            switch (linkUp)
            {
                case LinkUp.None:
                    return result;
                case LinkUp.Start:
                    return result * intervals[0];
                case LinkUp.End:
                    return result * intervals[intervals.Count - 1];
                case LinkUp.Both:
                    return result * intervals[0] * intervals[intervals.Count - 1];
                case LinkUp.Cycle:
                    return result*(intervals[0] + intervals[intervals.Count - 1] - 1);
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double temp = 1;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                temp = temp * Calculate(chain.CongenericChain(i), linkUp);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Volume;
        }
    }
}