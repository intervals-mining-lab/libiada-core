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
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            List<int> intervals = chain.Intervals;
            Int64 sum = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                sum += intervals[i];
            }
            switch (linkUp)
            {
                case LinkUp.Start:
                    return sum + intervals[0];
                case LinkUp.End:
                    return sum + intervals[intervals.Count - 1];
                case LinkUp.Both:
                    return sum + intervals[0] + intervals[intervals.Count - 1];
                case LinkUp.Cycle:
                    return sum + intervals[intervals.Count - 1] + intervals[0] - 1;
                case LinkUp.None:
                    return sum;
                default: 
                    throw new Exception("неизвестная привязка");
            }
        }

        /// <summary>
        /// Сумма всех интервалов однородных цепочек данной цепи
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            Int64 sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += (Int64)Calculate(chain.UniformChain(i), linkUp);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsSum;
        }
    }
}