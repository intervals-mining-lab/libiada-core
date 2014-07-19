namespace MarkovChains.MarkovCompare
{
    using MarkovChains.MarkovChain;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// Класс предназначеный для получения метрик марковских цепей
    /// </summary>
    public class MarkovMetrics
    {
        /// <summary>
        /// Выдает метрику как среднее арифметическое вероятностей
        /// </summary>
        /// <param name="chain">
        /// Обсчитываемая цепь
        /// </param>
        /// <returns>
        /// Среднее арифметическое вероятностей
        /// </returns>
        public double GetMiddleArith(MarkovChainNotUniformStatic chain)
        {
            IProbabilityMatrix matrix = chain.PropabilityMatrix;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                int[] array = { i };
                matrix.GetProbabilityVector(chain.Alphabet, array);
            }

            return 0;
        }
    }
}