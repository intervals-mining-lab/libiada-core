namespace MarkovChains.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Класс описывающий статичную неоднородную марковскую цепь
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// Тип генерируемой цепи
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// Тип обучающей цепи
    /// </typeparam>
    public class MarkovChainNotUniformStatic : MarkovChainBase
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
        public override BaseChain Generate(int i, int chainRang)
        {
            var temp = new BaseChain();
            temp.ClearAndSetNewLength(i);
            var read = this.Rank > 1 ? new IteratorStart(temp, this.Rank - 1, 1) : null;
            var write = new IteratorWritableStart(temp);
            if (read != null)
            {
                read.Reset();
                read.Next();
            }

            write.Reset();
            this.Generator.Reset();

            int m = 0;
            for (int j = 0; j < i; j++)
            {
                if (m == this.UniformRank + 1)
                {
                    m = 0;
                }

                m += 1;

                write.Next();

                if (j >= this.Rank)
                {
                    if (read != null)
                    {
                        read.Next();
                    }
                }

                if (read != null)
                {
                    BaseChain chain = (BaseChain)read.Current();
                    var indexedChain = new int[chain.GetLength()];
                    for (int k = 0; k < chain.GetLength(); k++)
                    {
                        indexedChain[k] = this.Alphabet.IndexOf(chain[k]);
                    }

                    write.WriteValue(
                        this.GetObject(this.ProbabilityMatrix[m - 1].GetProbabilityVector(this.Alphabet, indexedChain)));
                }
            }

            return temp;
        }
    }
}