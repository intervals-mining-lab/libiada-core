namespace PhantomChains.Classes.Statistics.MarkovChain
{
    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Generators;

    /// <summary>
    /// Класс описывающий статичную неоднородную марковскую цепь
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// Тип генерируемой цепи
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// Тип обучающей цепи
    /// </typeparam>
    public class MarkovChainNotUniformStatic<TChainGenerated, TChainTaught> : MarkovChainBase<TChainGenerated, TChainTaught>
        where TChainGenerated : BaseChain, new() where TChainTaught : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainNotUniformStatic{ChainGenerated,ChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// Порядок марковской цепи
        /// </param>
        /// <param name="uniformRang">
        /// Неоднородность цепи
        /// </param>
        /// <param name="generator">
        /// Генератор
        /// </param>
        public MarkovChainNotUniformStatic(int rang, int uniformRang, IGenerator generator)
            : base(rang, uniformRang, generator)
        {
        }

        /// <summary>
        /// Генерация марковской цепочки
        /// </summary>
        /// <param name="i">
        /// Длинна генерируемой цепи
        /// </param>
        /// <param name="chainRang">
        /// Ранг генерируемой цепи
        /// </param>
        /// <returns>
        /// Сгенерированная цепь
        /// </returns>
        public override TChainGenerated Generate(int i, int chainRang)
        {
            var temp = new TChainGenerated();
            temp.ClearAndSetNewLength(i);
            var read = Rank > 1 ? new IteratorStart<TChainGenerated, TChainGenerated>(temp, Rank - 1, 1) : null;
            var write = new IteratorWritableStart<TChainGenerated, TChainGenerated>(temp);
            if (read != null)
            {
                read.Reset();
                read.Next();
            }

            write.Reset();
            Generator.Reset();

            int m = 0;
            for (int j = 0; j < i; j++)
            {
                if (m == UniformRank + 1)
                {
                    m = 0;
                }

                m += 1;

                write.Next();

                if (j >= Rank)
                {
                    if (read != null)
                    {
                        read.Next();
                    }
                }

                if (read != null)
                {
                    TChainGenerated chain = read.Current();
                    var indexedChain = new int[chain.Length];
                    for (int k = 0; k < chain.Length; k++)
                    {
                        indexedChain[k] = this.Alphabet.IndexOf(chain[k]);
                    }

                    write.WriteValue(
                        GetObject(ProbabilityMatrix[m - 1].GetProbabilityVector(this.Alphabet, indexedChain)));
                }
            }

            return temp;
        }
    }
}