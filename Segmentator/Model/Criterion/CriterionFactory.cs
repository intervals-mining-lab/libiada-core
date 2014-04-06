namespace Segmentator.Model.Criterion
{
    using Segmentator.Model.Threshold;

    /// <summary>
    /// Creates one of availale criterion
    /// </summary>
    public static class CriterionFactory
    {
        public static Criterion Make(int index, ThresholdVariator threshold, Input input)
        {
            switch (index)
            {
                case 0: return new CriterionPartialOrlov(threshold, input.Precision);
                case 1: return new CriterionMinSymmetryByShrader(threshold, input.Precision);
                case 2: return new CriterionMinSimmetryByIntervals(threshold, input.Precision);
                case 3: return new CriterionEqualityOfDepths(threshold, input.Precision);
                case 4: return new CriterionAttitudeOfRemoteness(threshold, input.Precision);
                case 5: return new CriterionMinimumRegularity(threshold, input.Precision);
                case 6: return new CriterionGoldenRatio(threshold, input.Precision);
            }

            return null;
        } 
    }
}