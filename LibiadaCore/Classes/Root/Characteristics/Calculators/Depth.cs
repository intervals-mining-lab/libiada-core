namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Глубина
    /// </summary>
    public class Depth : ICalculator
    {
        /// <summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            List<int> intervals = chain.Intervals;
            double result = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result += Math.Log(intervals[i], 2);
            }

            switch (link)
            {
                case Link.Start:
                    return result + Math.Log(intervals[0], 2);
                case Link.End:
                    return result + Math.Log(intervals[intervals.Count - 1], 2);
                case Link.Both:
                    return result + Math.Log(intervals[0], 2) +
                        Math.Log(intervals[intervals.Count - 1], 2);
                case Link.Cycle:
                    return result + Math.Log(intervals[intervals.Count - 1] + intervals[0] - 1, 2);
                case Link.None:
                    return result;
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        /// <summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Depth;
        }
    }
}