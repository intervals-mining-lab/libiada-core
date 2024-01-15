namespace Libiada.MarkovChains.MarkovChain;

using System;
using System.Collections.Generic;

using Libiada.Core.Core;
using Libiada.Core.Iterators;
using Libiada.Core.SpaceReorganizers;
using MarkovChains.MarkovChain.Builders;
using MarkovChains.MarkovChain.Generators;
using MarkovChains.MarkovChain.Matrices.Absolute;
using MarkovChains.MarkovChain.Matrices.Probability;

/// <summary>
/// Base class of all markov chains.
/// </summary>
public abstract class MarkovChainBase
{
    /// <summary>
    /// The generator.
    /// </summary>
    protected readonly IGenerator Generator;

    /// <summary>
    /// The rank.
    /// </summary>
    protected readonly int Rank;

    /// <summary>
    /// The probability matrix.
    /// </summary>
    protected readonly IProbabilityMatrix[] ProbabilityMatrixes;

    /// <summary>
    /// The heterogeneity rank.
    /// </summary>
    protected readonly int HeterogeneityRank;

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkovChainBase"/> class.
    /// </summary>
    /// <param name="rank">
    /// Markov chain rank.
    /// </param>
    /// <param name="heterogeneityRank">
    /// Heterogeneity rank.
    /// </param>
    /// <param name="generator">
    /// Random numbers generator used for sequence generation.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if rank is less than 1 or generator is null.
    /// </exception>
    public MarkovChainBase(int rank, int heterogeneityRank, IGenerator generator)
    {
        if ((rank < 1) || (generator == null))
        {
            throw new ArgumentException("Error during creation of markov chain.");
        }

        Rank = rank;
        Generator = generator;
        HeterogeneityRank = heterogeneityRank;
        ProbabilityMatrixes = new IProbabilityMatrix[heterogeneityRank + 1];
    }

    /// <summary>
    /// Gets matrix of probabilities of markov chain.
    /// </summary>
    public IProbabilityMatrix PropabilityMatrix
    {
        get
        {
            return ProbabilityMatrixes[0];
        }
    }

    /// <summary>
    /// Gets the alphabet.
    /// </summary>
    public Alphabet Alphabet { get; private set; }

    /// <summary>
    /// Generates sequence of given length.
    /// Uses rank given upon creation.
    /// </summary>
    /// <param name="length">
    /// Length of generated sequence.
    /// </param>
    /// <returns>
    /// Generated sequence <see cref="BaseChain"/>.
    /// </returns>
    public BaseChain Generate(int length)
    {
        return Generate(length, Rank);
    }

    /// <summary>
    /// Generates sequence of given length.
    /// Uses given rank but not higher than given upon creation.
    /// </summary>
    /// <param name="length">
    /// Length of generated sequence.
    /// </param>
    /// <param name="rank">
    /// Rank of markov chain used in generaton of sequence.
    /// </param>
    /// <returns>
    /// Generated sequence <see cref="BaseChain"/>.
    /// </returns>
    public abstract BaseChain Generate(int length, int rank);

    /// <summary>
    /// Teaches markov chain using provided sequence.
    /// </summary>
    /// <param name="chain">
    /// Sequence used for teaching.
    /// </param>
    /// <param name="method">
    /// Chain preprocessing method.
    /// </param>
    public virtual void Teach(BaseChain chain, TeachingMethod method)
    {
        var builder = new MatrixBuilder();
        var absMatrix = new IAbsoluteMatrix[HeterogeneityRank + 1];
        Alphabet = chain.Alphabet;
        for (int i = 0; i < HeterogeneityRank + 1; i++)
        {
            absMatrix[i] = (IAbsoluteMatrix)builder.Create(Alphabet.Cardinality, Rank);
        }

        SpaceReorganizer reorganizer = GetRebuilder(method);
        chain = (BaseChain)reorganizer.Reorganize(chain);

        var it = new IteratorStart(chain, Rank, 1);
        it.Reset();

        int k = 0;

        // filling matrixes
        while (it.Next())
        {
            ++k;
            int m = k % (HeterogeneityRank + 1);
            if (m == 0)
            {
                m = HeterogeneityRank + 1;
            }

            BaseChain chainToTeach = (BaseChain)it.Current();
            var indexedChain = new int[Rank];
            for (int i = 0; i < Rank; i++)
            {
                indexedChain[i] = chain.Alphabet.IndexOf(chainToTeach[i]);
            }

            absMatrix[m - 1].Add(indexedChain);
        }

        for (int i = 0; i < HeterogeneityRank + 1; i++)
        {
            ProbabilityMatrixes[i] = absMatrix[i].ProbabilityMatrix();
        }
    }

    /// <summary>
    /// Gets generated sequence from indexes.
    /// </summary>
    /// <param name="list">
    /// The list.
    /// </param>
    /// <returns>
    /// Generated sequence <see cref="BaseChain"/>.
    /// </returns>
    protected IBaseObject GetObject(Dictionary<IBaseObject, double> list)
    {
        IBaseObject result = null;
        double temp = 0;
        double probability = Generator.Next();
        foreach (KeyValuePair<IBaseObject, double> pair in list)
        {
            temp += pair.Value;
            if (temp >= probability)
            {
                result = pair.Key;
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// The get rebuilder.
    /// </summary>
    /// <param name="method">
    /// The method.
    /// </param>
    /// <returns>
    /// The <see cref="SpaceReorganizer"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if unknown <see cref="TeachingMethod"/> is provided.
    /// </exception>
    protected virtual SpaceReorganizer GetRebuilder(TeachingMethod method)
    {
        switch (method)
        {
            case TeachingMethod.None:
                return new NullReorganizer();
            case TeachingMethod.Cycle:
                return new NullCycleSpaceReorganizer(Rank - 1);
            default:
                throw new ArgumentException();
        }
    }
}
