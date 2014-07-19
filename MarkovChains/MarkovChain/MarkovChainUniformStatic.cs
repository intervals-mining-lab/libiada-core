namespace MarkovChains.MarkovChain
{
    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Класс описывающий статичную однородную марковскую цепь
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// Тип генерируемой марковской цепи
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// Тип обучающей цепи
    /// </typeparam>
    public class MarkovChainCongenericStatic :
        MarkovChainNotCongenericStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainCongenericStatic{TChainGenerated,TChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// Порядок марковской цепи
        /// </param>
        /// <param name="generator">
        /// Random generator.
        /// </param>
        public MarkovChainCongenericStatic(int rang, IGenerator generator) : base(rang, 0, generator)
        {
        }
    }
}