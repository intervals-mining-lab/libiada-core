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
    public class MarkovChainNotCongenericStatic : MarkovChainBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainNotCongenericStatic{ChainGenerated,ChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// Порядок марковской цепи
        /// </param>
        /// <param name="congenericRang">
        /// Неоднородность цепи
        /// </param>
        /// <param name="generator">
        /// Генератор
        /// </param>
        public MarkovChainNotCongenericStatic(int rang, int congenericRang, IGenerator generator)
            : base(rang, congenericRang, generator)
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
            var read = Rank > 1 ? new IteratorStart(temp, Rank - 1, 1) : null;
            var write = new IteratorWritableStart(temp);
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
                if (m == CongenericRank + 1)
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
                    BaseChain chain = (BaseChain)read.Current();
                    var indexedChain = new int[chain.GetLength()];
                    for (int k = 0; k < chain.GetLength(); k++)
                    {
                        indexedChain[k] = Alphabet.IndexOf(chain[k]);
                    }

                    write.WriteValue(GetObject(ProbabilityMatrixes[m - 1].GetProbabilityVector(Alphabet, indexedChain)));
                }
            }

            return temp;
        }
    }
}