namespace Segmenter.Model.Seekers
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Iterators;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// That's the seeker for allocate words with characteristic differences of the arithmetic mean
    /// and geometric mean of the interval
    /// </summary>
    public class DifferenceAverageIntervalExtractor : WordExtractor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DifferenceAverageIntervalExtractor"/> class.
        /// </summary>
        public DifferenceAverageIntervalExtractor()
        {
            wordPriority = new Dictionary<double, KeyValuePair<List<string>, List<int>>>();
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="par">
        /// The par.
        /// </param>
        /// <returns>
        /// The <see cref="KeyValuePair"/>.
        /// </returns>
        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            var convoluted = (ComplexChain)par.Get(Enum.GetName(typeof(Formalism), Formalism.Sequence));
            var windowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            var alphabet = (FrequencyDictionary)par.Get(Enum.GetName(typeof(Formalism), Formalism.Alphabet));
            var level = (double)par.Get(Enum.GetName(typeof(Parameter), Parameter.CurrentThreshold));

            int scanStep = 1;
            int disp = 0;

            var it = new StartIterator(convoluted, windowLen, scanStep);

            while (it.HasNext())
            {
                it.Next();
                fullEntry.Add(it, disp);
            }

            CalculateStd(convoluted, windowLen);

            return DiscardCompositeWords(alphabet, level);
        }

        /// <summary>
        /// The calc std.
        /// </summary>
        /// <param name="convoluted">
        /// The convoluted.
        /// </param>
        /// <param name="windowLen">
        /// The window len.
        /// </param>
        public void CalculateStd(ComplexChain convoluted, int windowLen)
        {
            var geometricMean = new GeometricMean();
            var arithmeticMean = new ArithmeticMean();

            foreach (KeyValuePair<List<string>, List<int>> accord in fullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                var temp = new ComplexChain(accord.Value);
                double geometric = geometricMean.Calculate(temp, convoluted.Anchor);
                double arithmetic = arithmeticMean.Calculate(temp, convoluted.Anchor);
                double std = 1 - (1 / Math.Abs(arithmetic - geometric));
                if (!wordPriority.ContainsKey(std))
                {
                    wordPriority.Add(std, accord);
                }
            }
        }
    }
}