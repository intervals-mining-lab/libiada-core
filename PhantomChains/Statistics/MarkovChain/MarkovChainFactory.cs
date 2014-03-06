namespace PhantomChains.Statistics.MarkovChain
{
    using System;

    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// ������� ��������� ���������� ����
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
    public class MarkovChainFactory<TChainGenerated, TChainTaught>
        where TChainTaught : BaseChain, new() where TChainGenerated : BaseChain, new()
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
        public MarkovChainBase<TChainGenerated, TChainTaught> Create(GeneratingMethod method, int rang, int uniformRang, IGenerator generator)
        {
            switch (method)
            {
                case GeneratingMethod.DynamicNotUniform:
                    return null;
                case GeneratingMethod.StaticNotUniform:
                    return new MarkovChainNotUniformStatic<TChainGenerated, TChainTaught>(rang, uniformRang, generator);
                case GeneratingMethod.DynamicUniform:
                    return null; 
                case GeneratingMethod.StaticUniform:
                    return new MarkovChainUniformStatic<TChainGenerated, TChainTaught>(rang, generator);
                case GeneratingMethod.Random:
                    return new MarkovChainRandom<TChainGenerated, TChainTaught>(rang, generator);
                default:
                    throw new ArgumentException("This type of markov chain does not registered in system", "method");
            }
        }
    }
}