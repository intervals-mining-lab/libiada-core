using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина цепи.
    ///</summary>
    public class Length : ICalculator
    {
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return chain.Length;
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            return chain.Length;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Length;
        }
    }
}