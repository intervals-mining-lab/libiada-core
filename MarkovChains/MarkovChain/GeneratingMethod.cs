namespace MarkovChains.MarkovChain
{
    using System;

    /// <summary>
    /// Перечисление типов марковских цепей.
    /// </summary>
    [Serializable]
    public enum GeneratingMethod
    {
        /// <summary>
        /// Однородная марковская цепь.
        /// Вероятности не зависят от шага
        /// </summary>
        StaticCongeneric,

        /// <summary>
        /// Неоднородная марковская цепь.
        /// Вероятности не зависят от шага
        /// </summary>
        StaticNotCongeneric,

        /// <summary>
        /// Однородная марковская цепь.
        /// Вероятности зависят от шага
        /// </summary>
        DynamicCongeneric,

        /// <summary>
        /// Неоднородная марковская цепь.
        /// Вероятности зависят от шага
        /// </summary>
        DynamicNotCongeneric,

        /// <summary>
        /// The random.
        /// </summary>
        Random
    }
}