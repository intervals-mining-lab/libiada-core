using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace BuildingsIterator.Classes.Filters
{
    ///<summary>
    /// Фильтр отфильтровывающий цепи по равенству частот вхождения элементов
    ///</summary>
    public class ChainFilterBySameFrequency : IChainFilter
    {
        public bool IsValid(string building)
        {
            Chain ch = new Chain(building);
            Probability probability = new Probability();
            AlphabetPower alphabetPower = new AlphabetPower();
            double p = probability.Calculate(ch.UniformChain(0), LinkUp.Start);
            for (int i = 1; i < alphabetPower.Calculate(ch, LinkUp.Start); i++)
            {
                if (p != probability.Calculate(ch.UniformChain(i), LinkUp.Start))
                    return false;
            }
            return true;
        }
    }
}