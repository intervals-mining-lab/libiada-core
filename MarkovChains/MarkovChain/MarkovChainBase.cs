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
    /// Базовый класс для марковских цепей
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
        /// Порядок марковской цепи
        /// </param>
        /// <param name="congenericRang">
        /// Порядок неоднородности
        /// </param>
        /// <param name="generator">
        /// Генератор используемый при генерировании последовательнсти
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public MarkovChainBase(int rank, int congenericRang, IGenerator generator)
        {
            if ((rank < 1) || (generator == null))
            {
                throw new ArgumentException("Ошибка при создании марковской цепи");
            }

            Rank = rank;
            Generator = generator;
            CongenericRank = congenericRang;
            ProbabilityMatrixes = new IProbabilityMatrix[congenericRang + 1];
        }

        /// <summary>
        /// Возвращает матрицу вероятностей марковской цепи
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
        /// Генерировать цепь заданно длинной.
        /// Использовать Информацию марковской цепи максимального порядка (порядок указаный при создании объекта)
        /// </summary>
        /// <param name="i">Длинна генерируемой цепи</param>
        /// <returns>
        /// Реализация Марковской цепи
        /// </returns>
        public BaseChain Generate(int i)
        {
            return Generate(i, Rank);
        }

        /// <summary>
        /// Генерировать цепь заданно длинной.
        /// Использовать Информацию марковской цепи указанного порядка ( не более порядока указаного при создании объекта)
        /// </summary>
        /// <param name="i">
        /// Длина генерируемой цепи
        /// </param>
        /// <param name="rank">
        /// Порядок марковской цепи используемый при реализации
        /// </param>
        /// <returns>
        /// The <see cref="TChainGenerated"/>.
        /// </returns>
        public abstract BaseChain Generate(int i, int rank);

        /// <summary>
        /// Обучить Марковскую цепь на последовательности
        /// </summary>
        /// <param name="chain">Цепь используемая при обучении</param>
        /// <param name="method">Метод предобработки цепи</param>
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

            // Здесь будем заполнять матрицы
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
        /// Возвращает сгенерированную марковскую цепь полученную из индексов
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <returns>
        /// Реализация марковской цепи
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
