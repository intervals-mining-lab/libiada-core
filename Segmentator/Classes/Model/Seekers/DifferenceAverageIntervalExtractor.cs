using System;
using System.Collections.Generic;

using Segmentator.Classes.Base;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Iterators;
using Segmentator.Classes.Base.Sequencies;

namespace Segmentator.Classes.Model.Seekers
{
    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// That's the seeker for allocate words with characteristic differences of the arithmetic mean
    /// and geometric mean of the interval
    /// </summary>
    public class DifferenceAverageIntervalExtractor:WordExtractor
    {
        public DifferenceAverageIntervalExtractor()
        {
            WordPriority = new Dictionary<Double, KeyValuePair<List<String>, List<int>>>();
        }

        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            ComplexChain convoluted = (ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence));
            int windowLen = (int) par.Get(Enum.GetName(typeof(Parameter),Parameter.Window));
            FrequencyDictionary alphabet = (FrequencyDictionary)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Alphabet));
            double level = (Double)par.Get(Enum.GetName(typeof(Parameter), Parameter.CurrentThreshold));

            int scanStep = 1;
            int disp = 0;

            StartIterator it = new StartIterator(convoluted, windowLen, scanStep);
            PositionFilter filter = new PositionFilter();

            while (it.HasNext())
            {
                it.Next();
                FullEntry.Add(it, disp);
            }
            CalcStd(convoluted, windowLen);

            return DiscardCompositeWords(alphabet, level);
        }

        public void CalcStd(ComplexChain convoluted, int windowLen)
        {
            GeometricMean gAvgInterval = new GeometricMean();
            ArithmeticMean aAvgInterval = new ArithmeticMean();

            foreach (KeyValuePair<List<String>, List<int>> accord in FullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                ComplexChain temp = new ComplexChain(accord.Value);
                double geometric = gAvgInterval.Calculate(temp, convoluted.Anchor);
                double arithmetic = aAvgInterval.Calculate(temp, convoluted.Anchor);
                double std = 1 - (1/Math.Abs(arithmetic - geometric));
                if (!WordPriority.ContainsKey(std)) WordPriority.Add(std, accord);
            }
        }
    }
}