using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ������� ����� ��� ���������� �����
    ///</summary>
    public abstract class MarkovChainBase<ChainGenerated, ChainTaught> 
        where ChainTaught: BaseChain, new() 
        where ChainGenerated: BaseChain,new()
    {
        protected Alphabet alphabet;
        protected readonly IGenerator Generator;
        protected readonly int Rank;
        protected readonly IProbabilityMatrix[] ProbabilityMatrix;
        protected readonly int UniformRank;

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="i">������� ���������� ����</param>
        ///<param name="uniformRang">������� ��������������</param>
        ///<param name="generator">��������� ������������ ��� ������������� �����������������</param>
        public MarkovChainBase(int i, int uniformRang, IGenerator generator)
        {
            if ((i<1) || (null == generator))
            {
                throw  new Exception("������ ��� �������� ���������� ����");
            }

            Rank = i;
            Generator = generator;
            UniformRank = uniformRang;
            ProbabilityMatrix = new IProbabilityMatrix[uniformRang + 1];
        }


        ///<summary>
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ������������� ������� (������� �������� ��� �������� �������)
        ///</summary>
        ///<param name="i">������ ������������ ����</param>
        ///<returns>���������� ���������� ����</returns>
        public ChainGenerated Generate(int i)
        {
            return Generate(i, Rank);
        }

        ///<summary>
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ���������� ������� ( �� ����� �������� ��������� ��� �������� �������)
        ///</summary>
        ///<param name="i">����� ������������ ����</param>
        ///<param name="rank">������� ���������� ���� ������������ ��� ����������</param>
        public abstract ChainGenerated Generate(int i, int rank);

        /// <summary>
        /// ���������� ��������������� ���������� ���� ���������� �� ��������
        /// </summary>
        /// <returns>���������� ���������� ����</returns>

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

        protected virtual SpaceRebuilder<ChainTaught, ChainTaught> GetRebuilder(TeachingMethod method)
        {
            switch(method)
            {
                case TeachingMethod.None:
                    return new NullRebuilder<ChainTaught, ChainTaught>();
                case TeachingMethod.Cycle:
                    return new NullCycleSpaceRebuilder<ChainTaught, ChainTaught>(Rank - 1);
                default:
                    throw new Exception();
            }
        }

        ///<summary>
        /// ������� ���������� ���� �� ������������������
        ///</summary>
        ///<param name="chain">���� ������������ ��� ��������</param>
        ///<param name="method">����� ������������� ����</param>
        public virtual void Teach(ChainTaught chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absMatrix = new IAbsoluteMatrix[UniformRank + 1];
            alphabet = chain.Alphabet;
            for (int i = 0; i < UniformRank + 1; i++)
                absMatrix[i] = (IAbsoluteMatrix)builder.Create(alphabet.Power, Rank);
            SpaceRebuilder<ChainTaught, ChainTaught> rebuilder = GetRebuilder(method);
            chain = rebuilder.Rebuild(chain);

            var it = new IteratorStart<ChainGenerated, ChainTaught>(chain, Rank, 1);
            it.Reset();

            int k = 0;
            //����� ����� ��������� �������
            while (it.Next())
            {
                ++k;
                int m = k % (UniformRank + 1);
                if (m == 0)
                    m = UniformRank + 1;

                ChainGenerated chainToTeach = it.Current();
                int[] indexedChain = new int[Rank];
                for (int i = 0; i < Rank; i++)
                {
                    indexedChain[i] = chain.Alphabet.IndexOf(chainToTeach[i]);
                }
                absMatrix[m - 1].Add(indexedChain);
            }

            for (int i = 0; i < UniformRank + 1; i++)
                ProbabilityMatrix[i] = absMatrix[i].ProbabilityMatrix();
        }

        /// <summary>
        /// ���������� ������� ������������ ���������� ����
        /// </summary>
        public IProbabilityMatrix PropabilityMatrix
        {
            get
            {
                return ProbabilityMatrix[0];
            }
        }

        ///<summary>
        /// ���������� ������� ����
        ///</summary>
        public Alphabet Alphabet
        {
            get
            {
                return alphabet;
            }
        }
    }
}