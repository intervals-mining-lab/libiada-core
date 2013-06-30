namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Вероятность (частота).
    ///</summary>
    public class Probability : ICalculator
    {
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            Count count = new Count();
            Length length = new Length();
            return count.Calculate(chain, linkUp) / length.Calculate(chain, linkUp);
        }

        /// <summary>
        /// Для неоднородной, заполненной цепи всегда равна 1.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double temp = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                temp += Calculate(chain.UniformChain(i), linkUp);
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
