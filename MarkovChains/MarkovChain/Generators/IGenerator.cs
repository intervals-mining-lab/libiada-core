namespace MarkovChains.MarkovChain.Generators
{
    /// <summary>
    /// Интерфейс для генероторов псевдосулайно величины
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Переустановить стартовое число.
        /// </summary>
        void Reset();

        /// <summary>
        /// Получить следующие значение псевдослучаной величины.
        /// </summary>
        /// <returns>
        /// [0..1] значение
        /// </returns>
        double Next();
    }
}