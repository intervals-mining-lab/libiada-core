namespace PhantomChains.Statistics.MarkovChain
{
    using global::PhantomChains.Statistics.MarkovChain.Builders;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Absolute;

    using LibiadaCore.Core;

    /// <summary>
    /// The markov chain random.
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
    public class MarkovChainRandom :
        MarkovChainNotUniformStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainRandom"/> class.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <param name="generator">
        /// The generator.
        /// </param>
        public MarkovChainRandom(int i, IGenerator generator)
            : base(1, 0, generator)
        {
        }

        /// <summary>
        /// The teach.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public override void Teach(BaseChain chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absoluteMatrix = (IAbsoluteMatrix)builder.Create(chain.Alphabet.Cardinality, this.Rank);
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                int[] temp = new int[1];
                temp[0] = chain.Alphabet.IndexOf(chain.Alphabet[i]);

                absoluteMatrix.Add(temp);
            }

            this.ProbabilityMatrix[0] = absoluteMatrix.ProbabilityMatrix();
        }
    }
}