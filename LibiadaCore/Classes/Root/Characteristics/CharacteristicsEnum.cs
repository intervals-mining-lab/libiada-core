namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    /// 
    ///</summary>
    public enum CharacteristicsEnum
    {
        ///<summary>
        /// Длинна как сумма длин интервалов.
        ///</summary>
        Length,
        ///<summary>
        /// Мощность алфавита.
        ///</summary>
        AlphabetPower,
        ///<summary>
        /// Удалённость.
        ///</summary>
        AverangeRemoteness,
        ///<summary>
        /// Количество элементов.
        /// Для однородной цепи это количество 
        /// непустых элементов.
        /// Для неоднородной цепи это её длина.
        ///</summary>
        Count,
        ///<summary>
        /// Длина обрезания по Садовскому.
        ///</summary>
        CutLength,
        ///<summary>
        /// Количество интервалов в зависимости от привязки.
        ///</summary>
        IntervalsCount,
        ///<summary>
        /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
        /// Энтропия, количество информации.
        ///</summary>
        Entropy,
        ///<summary>
        /// Объём цепи. Произведение длин всех её интервалов.
        ///</summary>
        Volume,
        ///<summary>
        /// Число возможных цепочек которые можно сгенерировать 
        /// из данной цепочки, содержащей фантомные сообщения.
        ///</summary>
        PhantomMessageCount,
        /// <summary>
        /// Энтропия словаря по Садовскому. 
        /// </summary>
        CutLengthVocabularyEntropy,
        ///<summary>
        /// Регулярность.
        ///</summary>
        Regularity,
        /// <summary>
        /// Вероятность (частота).
        /// </summary>
        Propability,
        ///<summary>
        /// Число описательных информаций.
        ///</summary>
        DescriptiveInformation,
        ///<summary>
        /// Глубина.
        ///</summary>
        Depth,
        ///<summary>
        /// Среднее арифметическое значение длин интервалов.
        ///</summary>
        ArithmeticMean,
        ///<summary>
        /// Глубина, приходящаяся на одно сообщение.
        ///</summary>
        NomalizedGamut,
        ///<summary>
        /// Периодичность.
        ///</summary>
        Periodicity,
        ///<summary>
        /// Среднее геометрическое значение длин интервалов.
        ///</summary>
        GeometricMean,
        /// <summary>
        /// Нормализованная удалённость
        /// </summary>
        NormalizedAverageRemoteness,
        /// <summary>
        /// Средняя длина слова
        /// </summary>
        AverageWordLength

    }
}