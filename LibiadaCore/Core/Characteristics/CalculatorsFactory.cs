namespace LibiadaCore.Core.Characteristics
{
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// Статическая фабрика различных калькуляторов.
    /// </summary>
    public static class CalculatorsFactory
    {

        /// <summary>
        /// Вероятность (частота).
        /// </summary>
        public static ICalculator P
        {
            get { return new Probability(); }
        }

        /// <summary>
        /// Количество интервалов в зависимости от привязки.
        /// </summary>
        public static ICalculator IntervalsCount
        {
            get { return new IntervalsCount(); }
        }

        /// <summary>
        /// Длина обрезания по Садовскому.
        /// </summary>
        public static ICalculator CutLength
        {
            get { return new CutLength(); }
        }

        /// <summary>
        /// Глубина.
        /// </summary>
        public static ICalculator G
        {
            get { return new Depth(); }
        }

        /// <summary>
        /// Алфавиная Глубина.
        /// </summary>
        public static ICalculator AlphabeticDepth
        {
            get { return new AlphabeticDepth(); }
        }

        /// <summary>
        /// Количество элементов.
        /// Для однородной цепи это количество непустых элементов.
        /// Для неоднородной цепи это её длина.
        /// </summary>
        public static ICalculator n
        {
            get { return new ElementsCount(); }
        }

        /// <summary>
        /// Среднегеометрический интервал.
        /// </summary>
        public static ICalculator deltaG
        {
            get { return new GeometricMean(); }
        }

        /// <summary>
        /// Длинна цепи.
        /// </summary>
        public static ICalculator Length
        {
            get { return new Length(); }
        }

        /// <summary>
        /// Длинна как сумма длин интервалов.
        /// </summary>
        public static ICalculator IntervalsSum
        {
            get { return new IntervalsSum(); }
        }

        /// <summary>
        /// Среднее арифметическое значение длин интервалов.
        /// </summary>
        public static ICalculator deltaA
        {
            get { return new ArithmeticMean(); }
        }

        /// <summary>
        /// Число описательных информаций.
        /// </summary>
        public static ICalculator D
        {
            get { return new DescriptiveInformation(); }
        }

        /// <summary>
        /// Регулярность.
        /// </summary>
        public static ICalculator r
        {
            get { return new Regularity(); }
        }

        /// <summary>
        /// Средняя удалённость.
        /// </summary>
        public static ICalculator g
        {
            get { return new AverageRemoteness(); }
        }

        /// <summary>
        /// Алфавитная удалённость.
        /// </summary>
        public static ICalculator AlphabeticAverageRemoteness
        {
            get { return new AlphabeticAverageRemoteness(); }
        }

        /// <summary>
        /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
        /// Энтропия, количество информации.
        /// </summary>
        public static ICalculator H
        {
            get { return new IdentificationInformation(); }
        }

        /// <summary>
        /// Объём цепи. Произведение длин всех её интервалов.
        /// </summary>
        public static ICalculator V
        {
            get { return new Volume(); }
        }

        /// <summary>
        /// Мощность алфавита.
        /// </summary>
        public static ICalculator Cardinality
        {
            get { return new AlphabetCardinality(); }
        }

        /// <summary>
        /// Глубина приходящаяся на одно сообщение.
        /// </summary>
        public static ICalculator nG
        {
            get { return new NormalizedDepth(); }
        }


        /// <summary>
        /// Периодичность.
        /// </summary>
        public static ICalculator t
        {
            get { return new Periodicity(); }
        }

        /// <summary>
        /// Энтропия словаря по Садовскому.
        /// </summary>
        public static ICalculator CutLenVocEntropy
        {
            get { return new CutLengthVocabularyEntropy(); }
        }

        /// <summary>
        /// Список калькуляторов характеристик.
        /// </summary>
        public static List<ICalculator> List
        {
            get
            {
                List<ICalculator> temp = new List<ICalculator>
                    {
                        D,
                        deltaA,
                        deltaG,
                        g,
                        G,
                        H,
                        IntervalsCount,
                        Length,
                        n,
                        P,
                        r,
                        Cardinality,
                        nG,
                        t,
                        AlphabeticAverageRemoteness,
                        AlphabeticDepth
                    };

                return temp;
            }
        }


        public static ICalculator Create(string type)
        {
            foreach (ICalculator calculator in List)
            {
                if ((type == calculator.GetType().ToString()) ||
                    ("LibiadaCore.Classes.Root.Characteristics.Calculators." + type == calculator.GetType().ToString()))
                {
                    return calculator;
                }
            }
            return null;
        }

        public static ICalculator Create(CharacteristicsEnum type)
        {
            foreach (ICalculator calculator in List)
            {
                if (type == calculator.GetCharacteristicName())
                {
                    return calculator;
                }
            }
            return null;
        }
    }
}