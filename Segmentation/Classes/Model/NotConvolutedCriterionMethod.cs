using System.Collections.Generic;
using Segmentation.Classes.Model.Criterion;

namespace Segmentation.Classes.Model
{
    /// <summary>
    /// Calculates frequency for not convoluted chain
    /// </summary>
    public class NotConvolutedCriterionMethod : CriterionMethod
    {
        public override sealed double Frequncy(List<int> std, int chainLength, int windowLength)
        {
            return Probability(std.Count, chainLength);
        }
    }
}