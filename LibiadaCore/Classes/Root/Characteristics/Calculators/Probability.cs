namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Вероятность (частота).
    ///</summary>
    public class Probability : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            Count count = new Count();
            Length length = new Length();
            return count.Calculate(pChain, LinkUp.Both)/length.Calculate(pChain, LinkUp.Both);
        }

        /// <summary>
        /// Для неоднородной, заполненной цепи всегда равна 1.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double temp = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp += Calculate(pChain.GetUniformChain(i), Link);
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
