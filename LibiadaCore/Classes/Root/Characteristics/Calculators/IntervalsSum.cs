using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Суммарная длина интервалов данной цепи.
    /// </summary>
    public class IntervalsSum : ICalculator
    {
        /// <summary>
        /// Суммирует интервалы в соотвествии с привязкой
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            List<int> intervals = chain.Intervals;
            Int64 sum = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                sum += intervals[i];
            }
            switch (link)
            {
                case Link.Start:
                    return sum + intervals[0];
                case Link.End:
                    return sum + intervals[intervals.Count - 1];
                case Link.Both:
                    return sum + intervals[0] + intervals[intervals.Count - 1];
                case Link.Cycle:
                    return sum + intervals[intervals.Count - 1] + intervals[0] - 1;
                case Link.None:
                    return sum;
                default: 
                    throw new Exception("неизвестная привязка");
            }
        }

        /// <summary>
        /// Сумма всех интервалов однородных цепочек данной цепи
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            Int64 sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += (Int64)Calculate(chain.CongenericChain(i), link);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsSum;
        }
    }
}