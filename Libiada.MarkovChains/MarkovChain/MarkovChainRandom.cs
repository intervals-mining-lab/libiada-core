namespace Libiada.MarkovChains.MarkovChain;

using Libiada.Core.Core;

using MarkovChains.MarkovChain.Builders;
using MarkovChains.MarkovChain.Generators;
using MarkovChains.MarkovChain.Matrices.Absolute;

/// <summary>
/// The markov chain random.
/// </summary>
public class MarkovChainRandom : MarkovChainNotCongenericStatic
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
        MatrixBuilder builder = new();
        IAbsoluteMatrix absoluteMatrix = (IAbsoluteMatrix)builder.Create(chain.Alphabet.Cardinality, Rank);
        for (int i = 0; i < chain.Alphabet.Cardinality; i++)
        {
            int[] temp = [chain.Alphabet.IndexOf(chain.Alphabet[i])];
            absoluteMatrix.Add(temp);
        }

        ProbabilityMatrixes[0] = absoluteMatrix.ProbabilityMatrix();
    }
}
