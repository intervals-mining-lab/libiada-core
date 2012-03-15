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
    public abstract class MarkovChainBase<ChainGenerated, ChainTeached> 
        where ChainTeached: BaseChain, new() 
        where ChainGenerated: BaseChain,new()
    {
        protected Alphabet alphabet;
        protected IGenerator pGenerator;
        protected int rang;
        protected IProbabilityMatrix[] ProbabilityMatrix;
        protected int uniformRang;

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

            rang = i;
            pGenerator = generator;
            this.uniformRang = uniformRang;
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
            return Generate(i, rang);
        }

        ///<summary>
        /// ������������ ���� ������� �������.
        /// ������������ ���������� ���������� ���� ���������� ������� ( �� ����� �������� ��������� ��� �������� �������)
        ///</summary>
        ///<param name="i">����� ������������ ����</param>
        ///<param name="rang">������� ���������� ���� ������������ ��� ����������</param>
        public abstract ChainGenerated Generate(int i, int rang);

        /// <summary>
        /// ���������� ��������������� ���������� ���� ���������� �� ��������
        /// </summary>
        /// <returns>���������� ���������� ����</returns>

        protected IBaseObject GetObject(Dictionary<IBaseObject, double> List)
        {
            IBaseObject Result = null;
            double Temp = 0;
            double Probability = pGenerator.Next();
            foreach (KeyValuePair<IBaseObject, double> pair in List)
            {
                Temp += pair.Value;
                if (Temp >= Probability)
                {
                    Result = pair.Key;
                    break;
                }
            }
            return Result;
        }

        protected virtual SpaceRebuilder<ChainTeached, ChainTeached> GetRebuilder(TeachingMethod method)
        {
            switch(method)
            {
                case TeachingMethod.None:
                    return new NullRebuilder<ChainTeached, ChainTeached>();
                case TeachingMethod.Cycle:
                    return new PsevdoCycleSpaceRebuilder<ChainTeached, ChainTeached>(rang - 1);
                default:
                    throw new Exception();
            }
        }

        ///<summary>
        /// ������� ���������� ���� �� ������������������
        ///</summary>
        ///<param name="chain">���� ������������ ��� ��������</param>
        ///<param name="Method">����� ������������� ����</param>
        public virtual void Teach(ChainTeached chain, TeachingMethod Method)
        {
            MatrixBuilder builder = new MatrixBuilder();
            IAbsoluteMatrix[] absMatrix = new IAbsoluteMatrix[uniformRang + 1];
            alphabet = chain.Alpahbet;
            for (int i = 0; i < uniformRang + 1; i++)
                absMatrix[i] = (IAbsoluteMatrix)builder.Create(alphabet.power, rang);
            SpaceRebuilder<ChainTeached, ChainTeached> Rebuilder = GetRebuilder(Method);
            chain = Rebuilder.Rebuild(chain);

            IteratorStart<ChainGenerated, ChainTeached> It = new IteratorStart<ChainGenerated, ChainTeached>(chain, rang, 1);
            It.Reset();

            int k = 0;
            //����� ����� ��������� �������
            while (It.Next())
            {
                ++k;
                int m = k % (uniformRang + 1);
                if (m == 0)
                    m = uniformRang + 1;

                ChainGenerated chainToTeach = It.Current();
                int[] indexedChain = new int[rang];
                for (int i = 0; i < rang; i++)
                {
                    indexedChain[i] = chain.Alpahbet.IndexOf(chainToTeach[i]);
                }
                absMatrix[m - 1].Add(indexedChain);
            }

            for (int i = 0; i < uniformRang + 1; i++)
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