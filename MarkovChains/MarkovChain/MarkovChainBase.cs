namespace MarkovChains.MarkovChain
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;
    using LibiadaCore.Misc.SpaceReorganizers;

    using MarkovChains.MarkovChain.Builders;
    using MarkovChains.MarkovChain.Generators;
    using MarkovChains.MarkovChain.Matrices.Absolute;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// ������� ����� ��� ���������� �����
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
        /// The congeneric rank.
        /// </summary>
        protected readonly int CongenericRank;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainBase"/> class.
        /// </summary>
        /// <param name="rank">
        /// ������� ���������� ����
        /// </param>
        /// <param name="congenericRang">
        /// ������� ��������������
        /// </param>
        /// <param name="generator">
        /// ��������� ������������ ��� ������������� �����������������
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public MarkovChainBase(int rank, int congenericRang, IGenerator generator)
        {
            if ((rank < 1) || (generator == null))
            {
                throw new ArgumentException("������ ��� �������� ���������� ����");
            }

            Rank = rank;
            Generator = generator;
            CongenericRank = congenericRang;
            ProbabilityMatrixes = new IProbabilityMatrix[congenericRang + 1];
        }

        /// <summary>
        /// ���������� ������� ������������ ���������� ����
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
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ������������� ������� (������� �������� ��� �������� �������)
        /// </summary>
        /// <param name="i">������ ������������ ����</param>
        /// <returns>
        /// ���������� ���������� ����
        /// </returns>
        public BaseChain Generate(int i)
        {
            return Generate(i, Rank);
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
        public abstract BaseChain Generate(int i, int rank);

        /// <summary>
        /// ������� ���������� ���� �� ������������������
        /// </summary>
        /// <param name="chain">���� ������������ ��� ��������</param>
        /// <param name="method">����� ������������� ����</param>
        public virtual void Teach(BaseChain chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absMatrix = new IAbsoluteMatrix[CongenericRank + 1];
            Alphabet = chain.Alphabet;
            for (int i = 0; i < CongenericRank + 1; i++)
            {
                absMatrix[i] = (IAbsoluteMatrix)builder.Create(Alphabet.Cardinality, Rank);
            }

            SpaceReorganizer reorganizer = GetRebuilder(method);
            chain = (BaseChain)reorganizer.Reorganize(chain);

            var it = new IteratorStart(chain, Rank, 1);
            it.Reset();

            int k = 0;

            // ����� ����� ��������� �������
            while (it.Next())
            {
                ++k;
                int m = k % (CongenericRank + 1);
                if (m == 0)
                {
                    m = CongenericRank + 1;
                }

                BaseChain chainToTeach = (BaseChain)it.Current();
                var indexedChain = new int[Rank];
                for (int i = 0; i < Rank; i++)
                {
                    indexedChain[i] = chain.Alphabet.IndexOf(chainToTeach[i]);
                }

                absMatrix[m - 1].Add(indexedChain);
            }

            for (int i = 0; i < CongenericRank + 1; i++)
            {
                ProbabilityMatrixes[i] = absMatrix[i].ProbabilityMatrix();
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
        /// The <see cref="T:SpaceReorganizer{ChainTaught, ChainTaught}"/>.
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
}
