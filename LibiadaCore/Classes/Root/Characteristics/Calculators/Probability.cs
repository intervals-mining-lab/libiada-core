namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Вероятность (частота).
    ///</summary>
    public class Probability : ICalculator
    {
        public double Calculate(CongenericChain chain, Link link)
        {
            var count = new Count();
            var length = new Length();
            return count.Calculate(chain, link) / length.Calculate(chain, link);
        }

        /// <summary>
        /// Для неоднородной, заполненной цепи всегда равна 1.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            double temp = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                temp += Calculate(chain.CongenericChain(i), link);
            }
            if (temp > 1)
            {
                temp = 1;
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Probability;
        }
    }
}
