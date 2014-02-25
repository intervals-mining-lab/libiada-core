namespace PhantomChains.Classes.Statistics.MarkovChain
{
    /// <summary>
    /// Метод предобработки цепи
    /// </summary>
    public enum TeachingMethod
    {
        /// <summary>
        /// Отсутсвие предобработки
        /// </summary>
        None,

        /// <summary>
        /// Замыкание в кольцо (используя статистические данные)
        /// </summary>
        Cycle,

        /// <summary>
        /// Замыкание в кольцо (используя информацию о строе цепи)
        /// </summary>
        CycleBuilding
    }
}