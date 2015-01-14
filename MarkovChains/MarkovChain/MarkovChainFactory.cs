namespace MarkovChains.MarkovChain
{
    using System;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Factory of markov chains.
    /// </summary>
    public class MarkovChainFactory
    {
        /// <summary>
        /// Creates markov chain.
        /// </summary>
        /// <param name="method">
        /// Chain type.
        /// </param>
        /// <param name="rang">
        /// Chain's rank.
        /// </param>
        /// <param name="congenericRang">
        /// Неоднородность цепи
        /// </param>
        /// <param name="generator">
        /// Генератор используемый в цепи
        /// </param>
        /// <returns>
        /// Марковская цепь
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if chain type is unknown.
        /// </exception>
        public MarkovChainBase Create(GeneratingMethod method, int rang, int congenericRang, IGenerator generator)
        {
            switch (method)
            {
                case GeneratingMethod.DynamicNotCongeneric:
                    return null;
                case GeneratingMethod.StaticNotCongeneric:
                    return new MarkovChainNotCongenericStatic(rang, congenericRang, generator);
                case GeneratingMethod.DynamicCongeneric:
                    return null; 
                case GeneratingMethod.StaticCongeneric:
                    return new MarkovChainCongenericStatic(rang, generator);
                case GeneratingMethod.Random:
                    return new MarkovChainRandom(rang, generator);
                default:
                    throw new ArgumentException("This type of markov chain does not registered in system", "method");
            }
        }
    }
}
