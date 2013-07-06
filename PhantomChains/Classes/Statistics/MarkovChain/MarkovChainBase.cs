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
    /// Базовый класс для марковских цепей
    ///</summary>
    public abstract class MarkovChainBase<ChainGenerated, ChainTeached> 
        where ChainTeached: BaseChain, new() 
        where ChainGenerated: BaseChain,new()
    {
        protected Alphabet alphabet;
        protected readonly IGenerator Generator;
        protected readonly int Rank;
        protected readonly IProbabilityMatrix[] ProbabilityMatrix;
        protected readonly int UniformRank;

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="i">Порядок марковской цепи</param>
        ///<param name="uniformRang">Порядок неоднородности</param>
        ///<param name="generator">Генератор используемый при генерировании последовательнсти</param>
        public MarkovChainBase(int i, int uniformRang, IGenerator generator)
        {
            if ((i<1) || (null == generator))
            {
                throw  new Exception("Ошибка при создании марковской цепи");
            }

            Rank = i;
            Generator = generator;
            UniformRank = uniformRang;
            ProbabilityMatrix = new IProbabilityMatrix[uniformRang + 1];
        }


        ///<summary>
        /// Генерировать цепь заданно длинной.
        /// Использовать Информацию марковской цепи максимального порядка (порядок указаный при создании объекта)
        ///</summary>
        ///<param name="i">Длинна генерируемой цепи</param>
        ///<returns>Реализация Марковской цепи</returns>
        public ChainGenerated Generate(int i)
        {
            return Generate(i, Rank);
        }

        ///<summary>
        /// Генерировать цепь заданно длинной.
        /// Использовать Информацию марковской цепи указанного порядка ( не более порядока указаного при создании объекта)
        ///</summary>
        ///<param name="i">Длина генерируемой цепи</param>
        ///<param name="rank">Порядок марковской цепи используемый при реализации</param>
        public abstract ChainGenerated Generate(int i, int rank);

        /// <summary>
        /// Возвращает сгенерированную марковскую цепь полученную из индексов
        /// </summary>
        /// <returns>Реализация марковской цепи</returns>

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

        protected virtual SpaceRebuilder<ChainTeached, ChainTeached> GetRebuilder(TeachingMethod method)
        {
            switch(method)
            {
                case TeachingMethod.None:
                    return new NullRebuilder<ChainTeached, ChainTeached>();
                case TeachingMethod.Cycle:
                    return new PsevdoCycleSpaceRebuilder<ChainTeached, ChainTeached>(Rank - 1);
                default:
                    throw new Exception();
            }
        }

        ///<summary>
        /// Обучить Марковскую цепь на последовательности
        ///</summary>
        ///<param name="chain">Цепь используемая при обучении</param>
        ///<param name="method">Метод предобработки цепи</param>
        public virtual void Teach(ChainTeached chain, TeachingMethod method)
        {
            MatrixBuilder builder = new MatrixBuilder();
            IAbsoluteMatrix[] absMatrix = new IAbsoluteMatrix[UniformRank + 1];
            alphabet = chain.Alphabet;
            for (int i = 0; i < UniformRank + 1; i++)
                absMatrix[i] = (IAbsoluteMatrix)builder.Create(alphabet.Power, Rank);
            SpaceRebuilder<ChainTeached, ChainTeached> rebuilder = GetRebuilder(method);
            chain = rebuilder.Rebuild(chain);

            IteratorStart<ChainGenerated, ChainTeached> it = new IteratorStart<ChainGenerated, ChainTeached>(chain, Rank, 1);
            it.Reset();

            int k = 0;
            //Сдесь будем заполнять матрицы
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
        /// Возвращает матрицу вероятностей марковской цепи
        /// </summary>
        public IProbabilityMatrix PropabilityMatrix
        {
            get
            {
                return ProbabilityMatrix[0];
            }
        }

        ///<summary>
        /// Возвращает алфавит цепи
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