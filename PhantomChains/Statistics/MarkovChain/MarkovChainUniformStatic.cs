namespace PhantomChains.Statistics.MarkovChain
{
    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// Класс описывающий статичную однородную марковскую цепь
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// Тип генерируемой марковской цепи
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// Тип обучающей цепи
    /// </typeparam>
    public class MarkovChainUniformStatic<TChainGenerated, TChainTaught> :
        MarkovChainNotUniformStatic<TChainGenerated, TChainTaught>
        where TChainGenerated : BaseChain, new() where TChainTaught : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainUniformStatic{TChainGenerated,TChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// Порядок марковской цепи
        /// </param>
        /// <param name="generator">
        /// Random generator.
        /// </param>
        public MarkovChainUniformStatic(int rang, IGenerator generator)
            : base(rang, 0, generator)
        {
        }
    }
}