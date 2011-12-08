using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class Probability : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.n)/
                   pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double temp = 0;
            for (int i = 0; i < pChain.Alpahbet.power; i++)
            {
                temp += Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.P);
            }
            return temp;
        }
    }
}