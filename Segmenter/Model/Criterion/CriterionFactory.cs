namespace Segmenter.Model.Criterion
{
    using System;

    using Segmenter.Model.Threshold;

    /// <summary>
    /// Creates one of available criterion
    /// </summary>
    public static class CriterionFactory
    {
        /// <summary>
        /// The make.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="threshold">
        /// The threshold.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Criterion"/>.
        /// </returns>
        public static Criterion Make(int index, ThresholdVariator threshold, Input input)
        {
            switch (index)
            {
                case 0: 
                    return new CriterionPartialOrlov(threshold, input.Precision);
                case 1: 
                    return new CriterionMinSymmetryByShrader(threshold, input.Precision);
                case 2: 
                    return new CriterionMinSymmetryByIntervals(threshold, input.Precision);
                case 3: 
                    return new CriterionEqualityOfDepths(threshold, input.Precision);
                case 4: 
                    return new CriterionAttitudeOfRemoteness(threshold, input.Precision);
                case 5: 
                    return new CriterionMinimumRegularity(threshold, input.Precision);
                case 6: 
                    return new CriterionGoldenRatio(threshold, input.Precision);
                default:
                    throw new ArgumentException("Unknown index", "index");
            }
        } 
    }
}