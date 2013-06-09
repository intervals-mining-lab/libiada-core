using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество интервалов в зависимости от привязки.
    ///</summary>
    public class IntervalsCount : ICharacteristicCalculator
    {
        /// <summary>
        /// К началу, к концку и циклическая = столько же сколько элементов
        /// К обоим концам = количество элементов + 1
        /// Без привязки = количество элементов - 1
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            List<int> intervals = pChain.Intervals;
            switch (Link)
            {
                case LinkUp.Start:
                    return intervals.Count - 1;
                case LinkUp.End:
                    return intervals.Count - 1;
                case LinkUp.Both:
                    return intervals.Count;
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            int sum = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                sum += (int)Calculate(pChain.GetUniformChain(i), Link);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}