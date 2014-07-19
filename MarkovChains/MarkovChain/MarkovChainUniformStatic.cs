namespace MarkovChains.MarkovChain
{
    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// ����� ����������� ��������� ���������� ���������� ����
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// ��� ������������ ���������� ����
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// ��� ��������� ����
    /// </typeparam>
    public class MarkovChainUniformStatic :
        MarkovChainNotUniformStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainUniformStatic{TChainGenerated,TChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// ������� ���������� ����
        /// </param>
        /// <param name="generator">
        /// Random generator.
        /// </param>
        public MarkovChainUniformStatic(int rang, IGenerator generator) : base(rang, 0, generator)
        {
        }
    }
}