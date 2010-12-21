﻿using System.Collections.Generic;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace ChainAnalises.Classes.Statistics.MarkovCompare
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
            for (int i = 0; i < chain.Alphabet.power; i++)
            {
                int[] array = {i};
                Dictionary<IBaseObject, double> dic = matrix.GetProbabilityVector(chain.Alphabet, array);
            }
            return 0;
        }
    }
}