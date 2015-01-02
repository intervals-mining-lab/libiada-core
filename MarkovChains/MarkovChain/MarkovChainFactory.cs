namespace MarkovChains.MarkovChain
{
    using System;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Фабрика создающая марковскую цепь
    /// </summary>
    public class MarkovChainFactory
    {
        /// <summary>
        /// Создать марковскую цепь
        /// </summary>
        /// <param name="method">
        /// Тип цепи
        /// </param>
        /// <param name="rang">
        /// Порядок
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
        /// В случае если тип цепи не зарегистирован в фабрике
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
