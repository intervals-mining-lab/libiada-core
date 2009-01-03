using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class NomalizationGamut : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.G)/
                pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.G) /
                pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);

        }
    }
}