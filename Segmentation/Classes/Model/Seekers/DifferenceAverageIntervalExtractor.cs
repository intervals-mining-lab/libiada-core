using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Model.Seekers
{
    /// <summary>
    /// That's the seeker for allocate words with characteristic differences of the arithmetic mean
    /// and geometric mean of the interval
    /// </summary>
    public class DifferenceAverageIntervalExtractor:WordExtractor
    {
        public DifferenceAverageIntervalExtractor()
        {
            wordPriority = new Dictionary<Double, KeyValuePair<List<String>, List<int>>>();
        }

        public override sealed KeyValuePair<List<string>, List<int>>? find(ContentValues par)
        {
            ComplexChain convoluted = (ComplexChain)par.get(Formalism.GetName(typeof(Formalism), Formalism.SEQUENCE));
            int windowLen = (int) par.get(Enum.GetName(typeof(Parameter),Parameter.WINDOW));
            FrequencyDictionary alphabet = (FrequencyDictionary)par.get(Formalism.GetName(typeof(Formalism), Formalism.ALPHABET));
            double level = (Double)par.get(Enum.GetName(typeof(Parameter), Parameter.CURRENT_THRESHOLD));

            int scanStep = 1;
            int disp = 0;
            StartIterator it;
            PositionFilter filter;

            it = new StartIterator(convoluted, windowLen, scanStep);
            filter = new PositionFilter();

            while (it.hasNext())
            {
                it.next();
                fullEntry.add(it, disp);
            }
            calcStd(convoluted, windowLen, filter);

            return discardCompositeWords(alphabet, level);
        }

        public void calcStd(ComplexChain convoluted, int windowLen, PositionFilter filter)
        {
            GeometricMean gAvgInterval = new GeometricMean();
            ArithmeticMean aAvgInterval = new ArithmeticMean();

            foreach (KeyValuePair<List<String>, List<int>> accord in fullEntry.entry())
            {
                filter.filtrate(accord.Value, windowLen);
                ComplexChain temp = new ComplexChain(accord.Value);
                double geometric = gAvgInterval.Calculate(temp, convoluted.GetAnchor());
                double arithmetic = aAvgInterval.Calculate(temp, convoluted.GetAnchor());
                double std = 1 - (1/Math.Abs(arithmetic - geometric));
                if (!wordPriority.ContainsKey(std)) wordPriority.Add(std, accord);
            }
        }
    }
}