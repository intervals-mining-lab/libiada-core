namespace MarkovChains.MarkovChain
{
    using System;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// ������� ��������� ���������� ����
    /// </summary>
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
        /// <param name="congenericRang">
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
