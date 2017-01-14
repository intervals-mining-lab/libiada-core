namespace MarkovChains.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Static non congeneric (heterogeneous) markov chain class.
    /// </summary>
    public class MarkovChainNotCongenericStatic : MarkovChainBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainNotCongenericStatic"/> class.
        /// </summary>
        /// <param name="rank">
        /// Markov chain rank.
        /// </param>
        /// <param name="heterogeneityRank">
        /// Heterogeneity rank.
        /// </param>
        /// <param name="generator">
        /// Random numbers generator.
        /// </param>
        public MarkovChainNotCongenericStatic(int rank, int heterogeneityRank, IGenerator generator) : base(rank, heterogeneityRank, generator)
        {
        }

        /// <summary>
        /// Generates sequence.
        /// </summary>
        /// <param name="length">
        /// Length of generated sequence.
        /// </param>
        /// <param name="chainRank">
        /// Rank of used markov chain.
        /// </param>
        /// <returns>
        /// Generated sequence as <see cref="BaseChain"/>.
        /// </returns>
        public override BaseChain Generate(int length, int chainRank)
        {
            var temp = new BaseChain();
            temp.ClearAndSetNewLength(length);
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
            for (int j = 0; j < length; j++)
            {
                if (m == HeterogeneityRank + 1)
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
