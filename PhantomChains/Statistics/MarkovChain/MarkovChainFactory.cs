namespace PhantomChains.Statistics.MarkovChain
{
    using System;

    using LibiadaCore.Core;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// ������� ��������� ���������� ����
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
    public class MarkovChainFactory
    {
        /// <summary>
        /// ������� ���������� ����
        /// </summary>
        /// <param name="method">
        /// ��� ����
        /// </param>
        /// <param name="rang">
        /// �������
        /// </param>
        /// <param name="uniformRang">
        /// �������������� ����
        /// </param>
        /// <param name="generator">
        /// ��������� ������������ � ����
        /// </param>
        /// <returns>
        /// ���������� ����
        /// </returns>
        /// <exception cref="Exception">
        /// � ������ ���� ��� ���� �� �������������� � �������
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