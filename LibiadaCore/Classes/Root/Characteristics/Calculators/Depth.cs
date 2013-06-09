using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Глубина
    ///</summary>
    public class Depth : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            List<int> intervals = pChain.Intervals;
            double result = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result += Math.Log(intervals[i], 2);
            }

            switch (Link)
            {
                case LinkUp.Start:
                    return result + Math.Log(intervals[0], 2);
                case LinkUp.End:
                    return result + Math.Log(intervals[intervals.Count - 1], 2);
                case LinkUp.Both:
                    return result + Math.Log(intervals[0], 2) +
                        Math.Log(intervals[intervals.Count - 1], 2);
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
            double temp = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp += Calculate(pChain.GetUniformChain(i), Link);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Depth;
        }
    }
}