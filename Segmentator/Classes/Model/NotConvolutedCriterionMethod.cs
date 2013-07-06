using System.Collections.Generic;
using Segmentator.Classes.Model.Criterion;

namespace Segmentator.Classes.Model
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