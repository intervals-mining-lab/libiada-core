using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество интервалов в зависимости от привязки.
    ///</summary>
    public class IntervalsCount : ICalculator
    {
        /// <summary>
        /// К началу, к концку и циклическая = столько же сколько элементов
        /// К обоим концам = количество элементов + 1
        /// Без привязки = количество элементов - 1
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            List<int> intervals = chain.Intervals;
            switch (linkUp)
            {
                case LinkUp.Start:
                    return intervals.Count - 1;
                case LinkUp.End:
                    return intervals.Count - 1;
                case LinkUp.Both:
                    return intervals.Count;
                case LinkUp.Cycle:
                    return intervals.Count - 1;
                case LinkUp.None:
                    return intervals.Count-2;
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            int sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += (int)Calculate(chain.CongenericChain(i), linkUp);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}