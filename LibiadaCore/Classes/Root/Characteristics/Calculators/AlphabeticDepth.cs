using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    public class AlphabeticDepth: ICalculator
    {
        private int alphabetPower = 0;

        /// <summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            if (alphabetPower == 0)
            {
                throw new InvalidOperationException("Глубина в масштабе алфавита может вычисляться только для полной цепи.");
            }
            List<int> intervals = chain.Intervals;
            double result = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result += Math.Log(intervals[i], alphabetPower);
            }

            switch (linkUp)
            {
                case LinkUp.Start:
                    return result + Math.Log(intervals[0], alphabetPower);
                case LinkUp.End:
                    return result + Math.Log(intervals[intervals.Count - 1], alphabetPower);
                case LinkUp.Both:
                    return result + Math.Log(intervals[0], alphabetPower) +
                        Math.Log(intervals[intervals.Count - 1], alphabetPower);
                case LinkUp.Cycle:
                    return result + Math.Log(intervals[intervals.Count - 1] + intervals[0] - 1, alphabetPower);
                case LinkUp.None:
                    return result;
                default:
                    throw new Exception("Неизвестная привязка");
            }
        }

        ///<summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            alphabetPower = chain.Alphabet.Power;
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result += Calculate(chain.CongenericChain(i), linkUp);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabeticDepth;
        }
    }
}