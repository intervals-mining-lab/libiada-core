using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    public class Periodicity : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG)/
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG) /
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);

        }
    }
}