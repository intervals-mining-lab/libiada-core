using System;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
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
            switch(Link)
            {
                case LinkUp.Start:
                    IDataForCalculator tempStart = pChain;
                    return pChain.Length - ((ValueInt)tempStart.EndInterval.Keys[0]) + 1;
                case LinkUp.End:
                    IDataForCalculator tempEnd = pChain;
                    return pChain.Length - ((ValueInt)tempEnd.StartInterval.Keys[0]) + 1;
                case LinkUp.Both:
                    return pChain.Length;
                default: throw new Exception();
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