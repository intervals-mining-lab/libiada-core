using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число описательных информаций.
    ///</summary>
    public class DescriptiveInformation : ICalculator
    {
        private readonly Count count = new Count();
        private readonly Length length = new Length();

        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            double occupancy = length.Calculate(chain, linkUp)/count.Calculate(chain, linkUp);
            return Math.Pow(occupancy, 1 / occupancy);
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double result = 1;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result *= Calculate(chain.CongenericChain(i), linkUp);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}