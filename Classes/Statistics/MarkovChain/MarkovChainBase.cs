using System;
using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Базовый класс для марковских цепей
    ///</summary>
    public abstract class MarkovChainBase<ChainGenerated, ChainTeached> 
        where ChainTeached: BaseChain, new() 
        where ChainGenerated: BaseChain,new()
    {
        protected Alphabet alphabet = null;
        protected IGenerator pGenerator = null;
        protected int rang = 0;
        protected IProbabilityMatrix[] ProbabilityMatrix = null;
        protected int uniformRang = 0;

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

            rang = i;
            pGenerator = generator;
            this.uniformRang = uniformRang;
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
            return Generate(i, rang);
        }

        ///<summary>
        /// Генерировать цепь заданно длинной.
        /// Использовать Информацию марковской цепи указанного порядка ( не более порядока указаного при создании объекта)
        ///</summary>
        ///<param name="i">Длина генерируемой цепи</param>
        ///<param name="rang">Порядок марковской цепи используемый при реализации</param>
        public abstract ChainGenerated Generate(int i, int rang);

        /// <summary>
        /// Возвращает сгенерированную марковскую цепь полученную из индексов
        /// </summary>
        /// <returns>Реализация марковской цепи</returns>

        protected IBaseObject GetObject(Dictionary<IBaseObject, double> List)
        {
            IBaseObject Result = null;
            double Temp = 0;
            double Probability = pGenerator.Next();
            foreach (KeyValuePair<IBaseObject, double> pair in List)
            {
                Temp += pair.Value;
                if ((Temp >= Probability) && (null == Result))
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
                    return new PsevdoCycleSpace<ChainTeached, ChainTeached>(rang - 1);
                default:
                    throw new Exception();
            }
        }

        ///<summary>
        /// Обучить Марковскую цепь на последовательности
        ///</summary>
        ///<param name="chain">Цепь используемая при обучении</param>
        ///<param name="Method">Метод предобработки цепи</param>
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
            //Сдесь будем заполнять матрицы
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
        /// Возвращает матрицу вероятностей марковской цепи
        /// </summary>
        public IProbabilityMatrix GetPropabilityMatrix //Lesha
        {
            get
            {
                return ProbabilityMatrix[0];
            }
        }
    }
}