namespace PhantomChains.Statistics.MarkovChain
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Statistics.MarkovChain.Builders;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Absolute;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Probability;

    /// <summary>
    /// ������� ����� ��� ���������� �����
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// </typeparam>
    public abstract class MarkovChainBase<TChainGenerated, TChainTaught>
        where TChainTaught : BaseChain, new() where TChainGenerated : BaseChain, new()
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
        protected readonly IProbabilityMatrix[] ProbabilityMatrix;

        /// <summary>
        /// The uniform rank.
        /// </summary>
        protected readonly int UniformRank;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainBase{ChainGenerated,ChainTaught}"/> class.
        /// </summary>
        /// <param name="i">
        /// ������� ���������� ����
        /// </param>
        /// <param name="uniformRang">
        /// ������� ��������������
        /// </param>
        /// <param name="generator">
        /// ��������� ������������ ��� ������������� �����������������
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public MarkovChainBase(int i, int uniformRang, IGenerator generator)
        {
            if ((i < 1) || (null == generator))
            {
                throw new ArgumentException("������ ��� �������� ���������� ����");
            }

            this.Rank = i;
            this.Generator = generator;
            this.UniformRank = uniformRang;
            this.ProbabilityMatrix = new IProbabilityMatrix[uniformRang + 1];
        }

        /// <summary>
        /// ���������� ������� ������������ ���������� ����
        /// </summary>
        public IProbabilityMatrix PropabilityMatrix
        {
            get
            {
                return this.ProbabilityMatrix[0];
            }
        }

        /// <summary>
        /// Gets the alphabet.
        /// </summary>
        public Alphabet Alphabet { get; private set; }

        /// <summary>
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ������������� ������� (������� �������� ��� �������� �������)
        /// </summary>
        /// <param name="i">������ ������������ ����</param>
        /// <returns>
        /// ���������� ���������� ����
        /// </returns>
        public TChainGenerated Generate(int i)
        {
            return this.Generate(i, this.Rank);
        }

        /// <summary>
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ���������� ������� ( �� ����� �������� ��������� ��� �������� �������)
        /// </summary>
        /// <param name="i">
        /// ����� ������������ ����
        /// </param>
        /// <param name="rank">
        /// ������� ���������� ���� ������������ ��� ����������
        /// </param>
        /// <returns>
        /// The <see cref="TChainGenerated"/>.
        /// </returns>
        public abstract TChainGenerated Generate(int i, int rank);

        /// <summary>
        /// ������� ���������� ���� �� ������������������
        /// </summary>
        /// <param name="chain">���� ������������ ��� ��������</param>
        /// <param name="method">����� ������������� ����</param>
        public virtual void Teach(TChainTaught chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absMatrix = new IAbsoluteMatrix[this.UniformRank + 1];
            this.Alphabet = chain.Alphabet;
            for (int i = 0; i < this.UniformRank + 1; i++)
            {
                absMatrix[i] = (IAbsoluteMatrix)builder.Create(this.Alphabet.Cardinality, this.Rank);
            }

            SpaceReorganizer<TChainTaught, TChainTaught> reorganizer = this.GetRebuilder(method);
            chain = reorganizer.Reorganize(chain);

            var it = new IteratorStart<TChainGenerated, TChainTaught>(chain, this.Rank, 1);
            it.Reset();

            int k = 0;

            // ����� ����� ��������� �������
            while (it.Next())
            {
                ++k;
                int m = k % (this.UniformRank + 1);
                if (m == 0)
                {
                    m = this.UniformRank + 1;
                }

                TChainGenerated chainToTeach = it.Current();
                var indexedChain = new int[this.Rank];
                for (int i = 0; i < this.Rank; i++)
                {
                    indexedChain[i] = chain.Alphabet.IndexOf(chainToTeach[i]);
                }

                absMatrix[m - 1].Add(indexedChain);
            }

            for (int i = 0; i < this.UniformRank + 1; i++)
            {
                this.ProbabilityMatrix[i] = absMatrix[i].ProbabilityMatrix();
            }
        }

        /// <summary>
        /// ���������� ��������������� ���������� ���� ���������� �� ��������
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <returns>
        /// ���������� ���������� ����
        /// </returns>
        protected IBaseObject GetObject(Dictionary<IBaseObject, double> list)
        {
            IBaseObject result = null;
            double temp = 0;
            double probability = this.Generator.Next();
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
        /// The <see cref="T:SpaceReorganizer{ChainTaught, ChainTaught}"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if unknown <see cref="TeachingMethod"/> is provided.
        /// </exception>
        protected virtual SpaceReorganizer<TChainTaught, TChainTaught> GetRebuilder(TeachingMethod method)
        {
            switch (method)
            {
                case TeachingMethod.None:
                    return new NullReorganizer<TChainTaught, TChainTaught>();
                case TeachingMethod.Cycle:
                    return new NullCycleSpaceReorganizer<TChainTaught, TChainTaught>(this.Rank - 1);
                default:
                    throw new ArgumentException();
            }
        }
    }
}