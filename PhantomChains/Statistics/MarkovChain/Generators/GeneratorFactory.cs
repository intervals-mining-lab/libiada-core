namespace PhantomChains.Statistics.MarkovChain.Generators
{
    using System;

    /// <summary>
    /// ����������� ����� - ������� ����������� ��������� �����
    /// </summary>
    public static class GeneratorFactory
    {
        /// <summary>
        /// ����� ��������� ��������� ��������� ������� ��������� ����
        /// </summary>
        /// <param name="generator">��� ����������</param>
        /// <returns>
        /// ��������� ��������� �����
        /// </returns>
        /// <exception cref="ArgumentException">
        /// ����������� ��� ���������� �������� ����������
        /// </exception>
        public static IGenerator Create(GeneratorType generator)
        {
            switch (generator)
            {
                case GeneratorType.SimpleGenerator:
                    return new SimpleGenerator();
                default:
                    throw new ArgumentException("This type of generator does not registered in system", "generator");
            }
        }
    }
}