namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Число описательных информаций.
    /// </summary>
    public class DescriptiveInformation : ICalculator
    {
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(CongenericChain chain, Link link)
        {
            double occupancy = arithmeticMean.Calculate(chain,link);
            return Math.Pow(occupancy, 1/occupancy);
        }

        /// <summary>
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 1;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result *= Calculate(chain.CongenericChain(i), link);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}