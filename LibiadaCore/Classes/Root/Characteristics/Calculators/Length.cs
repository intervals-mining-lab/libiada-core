using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина как сумма длин интервалов.
    ///</summary>
    public class Length : ICharacteristicCalculator
    {
        /// <summary>
        /// Для однородной цепи считается по первому 
        /// или последнему значащему сообщению в зависимости от привязки.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            List<int> intervals = pChain.Intervals;
            int sum = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                sum += intervals[i];
            }
            switch(Link)
            {
                case LinkUp.Start:
                    return sum + intervals[0];
                case LinkUp.End:
                    return sum + intervals[intervals.Count - 1];
                case LinkUp.Both:
                    return pChain.Length;
                default: throw new Exception("неизвестная привязка");
            }
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return pChain.Length;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Length;
        }
    }
}