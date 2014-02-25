namespace PhantomChains.Classes.Statistics.MarkovChain
{
    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Builders;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Absolute;

    /// <summary>
    /// The markov chain random.
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
    public class MarkovChainRandom<TChainGenerated, TChainTaught> :
        MarkovChainNotUniformStatic<TChainGenerated, TChainTaught>
        where TChainGenerated : BaseChain, new() where TChainTaught : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainRandom{ChainGenerated,ChainTaught}"/> class.
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
        public override void Teach(TChainTaught chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absoluteMatrix = (IAbsoluteMatrix)builder.Create(chain.Alphabet.Cardinality, Rank);
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                int[] temp = new int[1];
                temp[0] = chain.Alphabet.IndexOf(chain.Alphabet[i]);

                absoluteMatrix.Add(temp);
            }

            ProbabilityMatrix[0] = absoluteMatrix.ProbabilityMatrix();
        }
    }
}