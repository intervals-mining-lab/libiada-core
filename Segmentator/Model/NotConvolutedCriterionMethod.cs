namespace Segmentator.Model
{
    using System.Collections.Generic;

    using Segmentator.Model.Criterion;

    /// <summary>
    /// Calculates frequency for not convoluted chain
    /// </summary>
    public class NotConvolutedCriterionMethod : CriterionMethod
    {
        public override sealed double Frequncy(List<int> std, int chainLength, int windowLength)
        {
            return this.Probability(std.Count, chainLength);
        }
    }
}