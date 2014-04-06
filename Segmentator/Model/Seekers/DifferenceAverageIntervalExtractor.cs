namespace Segmentator.Model.Seekers
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmentator.Base;
    using Segmentator.Base.Collectors;
    using Segmentator.Base.Iterators;
    using Segmentator.Base.Sequencies;

    /// <summary>
    /// That's the seeker for allocate words with characteristic differences of the arithmetic mean
    /// and geometric mean of the interval
    /// </summary>
    public class DifferenceAverageIntervalExtractor : WordExtractor
    {
        public DifferenceAverageIntervalExtractor()
        {
            this.wordPriority = new Dictionary<double, KeyValuePair<List<string>, List<int>>>();
        }

        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            ComplexChain convoluted = (ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence));
            int windowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            FrequencyDictionary alphabet =
                (FrequencyDictionary)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Alphabet));
            double level = (double)par.Get(Enum.GetName(typeof(Parameter), Parameter.CurrentThreshold));

            int scanStep = 1;
            int disp = 0;

            StartIterator it = new StartIterator(convoluted, windowLen, scanStep);
            PositionFilter filter = new PositionFilter();

            while (it.HasNext())
            {
                it.Next();
                this.fullEntry.Add(it, disp);
            }

            this.CalcStd(convoluted, windowLen);

            return this.DiscardCompositeWords(alphabet, level);
        }

        public void CalcStd(ComplexChain convoluted, int windowLen)
        {
            var geometricMean = new GeometricMean();
            var arithmeticMean = new ArithmeticMean();

            foreach (KeyValuePair<List<string>, List<int>> accord in this.fullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                ComplexChain temp = new ComplexChain(accord.Value);
                double geometric = geometricMean.Calculate(temp, convoluted.Anchor);
                double arithmetic = arithmeticMean.Calculate(temp, convoluted.Anchor);
                double std = 1 - (1 / Math.Abs(arithmetic - geometric));
                if (!this.wordPriority.ContainsKey(std))
                {
                    this.wordPriority.Add(std, accord);
                }
            }
        }
    }
}