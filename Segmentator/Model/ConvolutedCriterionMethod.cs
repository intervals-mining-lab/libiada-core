namespace Segmentator.Model
{
    using System.Collections.Generic;

    using Segmentator.Model.Criterion;

    /// <summary>
    /// Calculates frequency for convoluted chain
    /// </summary>
    public class ConvolutedCriterionMethod : CriterionMethod
    {
        public override sealed double Frequncy(List<int> std, int chainLength, int windowLength)
        {
            return this.Probability(std.Count, chainLength - (std.Count * (windowLength - 1)));
        }
    }
}