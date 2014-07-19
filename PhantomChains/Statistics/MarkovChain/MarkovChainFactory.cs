namespace PhantomChains.Statistics.MarkovChain
{
    using System;

    using LibiadaCore.Core;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// Фабрика создающая марковскую цепь
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
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
        /// <param name="uniformRang">
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
        public MarkovChainBase Create(GeneratingMethod method, int rang, int uniformRang, IGenerator generator)
        {
            switch (method)
            {
                case GeneratingMethod.DynamicNotUniform:
                    return null;
                case GeneratingMethod.StaticNotUniform:
                    return new MarkovChainNotUniformStatic(rang, uniformRang, generator);
                case GeneratingMethod.DynamicUniform:
                    return null; 
                case GeneratingMethod.StaticUniform:
                    return new MarkovChainUniformStatic(rang, generator);
                case GeneratingMethod.Random:
                    return new MarkovChainRandom(rang, generator);
                default:
                    throw new ArgumentException("This type of markov chain does not registered in system", "method");
            }
        }
    }
}