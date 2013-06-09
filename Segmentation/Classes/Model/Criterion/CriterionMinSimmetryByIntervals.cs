﻿using System;
using System.Collections.Generic;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// The criterion of "minimum symmetry by  intervals".
    /// As taxons are the words of the intervals and merons - parts word intervals.
    /// </summary>
    public class CriterionMinSimmetryByIntervals : Criterion
    {
        public CriterionMinSimmetryByIntervals(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            formalismType = Formalism.CRITERION_MIN_SYMMETRY_INTERVALS;

        }

        public double GetTaxonsValue(FrequencyDictionary alphabet)
        {
            double taxons = 0;

            List<List<int>> positions = alphabet.GetWordsPositions();

            for (int index = 0; index < alphabet.Count; index++)
            {
                int countT = positions[index].Count;
                taxons += Math.Log(countT)*countT - countT;
            }
            return taxons;
        }

        public double GetMeronsValue(FrequencyDictionary alphabet)
        {
            double merons = 0;

            return merons;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return false;
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return -1;
        }
    }
}