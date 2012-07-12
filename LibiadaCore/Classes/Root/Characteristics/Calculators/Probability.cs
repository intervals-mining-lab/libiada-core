using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Вероятность (частота).
    ///</summary>
    public class Probability : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.n)/
                   pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
        }

        /// <summary>
        /// Для неоднородной, заполненной цепи всегда равна 1.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double temp = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp += Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.P);
            }
            if (temp > 1)
            {
                temp = 1;
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Propability;
        }
    }
}
