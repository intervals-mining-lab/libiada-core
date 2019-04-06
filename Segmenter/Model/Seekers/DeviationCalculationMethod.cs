﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Segmenter.Model.Seekers
{
    public enum DeviationCalculationMethod
    {
        [Display(Name = "Average interval difference")]
        [Description("")]
        AverageIntervalDifference = 1,

        [Display(Name = "Probability method")]
        [Description("")]
        ProbabilityMethod = 2
    }
}