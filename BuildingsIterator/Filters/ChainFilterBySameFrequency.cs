namespace BuildingsIterator.Filters
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// Filter for sequences with equal frequencies of their elements.
    /// </summary>
    public class ChainFilterBySameFrequency : IChainFilter
    {
        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="building">
        /// The building.
        /// </param>
        /// <returns>
        /// true if
        /// </returns>
        public bool IsValid(string building)
        {
            var chain = new Chain(building);
            var countCalculator = new ElementsCount();

            var firstCount = (int)countCalculator.Calculate(chain.CongenericChain(0), Link.Start);
            for (int i = 1; i < chain.Alphabet.Cardinality; i++)
            {
                if (firstCount != (int)countCalculator.Calculate(chain.CongenericChain(i), Link.Start))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
