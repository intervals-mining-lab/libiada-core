using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovCompare
{
    ///<summary>
    /// Класс предназначеный для получения метрик марковских цепей
    ///</summary>
    public class MarkovMetrics
    {
        ///<summary>
        /// Выдает метрику как среднее арифметическое вероятностей
        ///</summary>
        ///<param name="chain">Обсчитываемая цепь</param>
        ///<returns>Среднее арифметическое вероятностей</returns>
        public double GetMiddleArith(MarkovChainNotUniformStatic<Chain, Chain> chain)
        {
            IProbabilityMatrix matrix = chain.PropabilityMatrix;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                int[] array = {i};
                Dictionary<IBaseObject, double> dic = matrix.GetProbabilityVector(chain.Alphabet, array);
            }
            return 0;
        }
    }
}