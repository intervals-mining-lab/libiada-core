﻿using System.Collections.Generic;
using Segmentation.Classes.Model.Criterion;

namespace Segmentation.Classes.Model
{
    /// <summary>
    /// Calculates frequency for convoluted chain
    /// </summary>
    public class ConvolutedCriterionMethod : CriterionMethod
    {
        public override sealed double frequncy(List<int> std, int chainLength, int windowLength)
        {
            return probability(std.Count, (chainLength - (std.Count*(windowLength - 1))));
        }
    }
}