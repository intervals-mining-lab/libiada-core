namespace PhantomChains.Classes.Statistics.MarkovChain
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
        StaticUniform,

        /// <summary>
        /// Неоднородная марковская цепь.
        /// Вероятности не зависят от шага
        /// </summary>
        StaticNotUniform,

        /// <summary>
        /// Однородная марковская цепь.
        /// Вероятности зависят от шага
        /// </summary>
        DynamicUniform,


        /// <summary>
        /// Неоднородная марковская цепь.
        /// Вероятности зависят от шага
        /// </summary>
        DynamicNotUniform,

        /// <summary>
        /// The random.
        /// </summary>
        Random
    }
}