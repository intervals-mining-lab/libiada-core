namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    public class AlphabetPower: ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.Alpahbet.power;
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return pChain.Alpahbet.power;
        }
    }
}