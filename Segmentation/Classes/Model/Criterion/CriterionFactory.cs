using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// Creates one of availale criterion
    /// </summary>
    public class CriterionFactory
    {
        public static Criterion make(int index, ThresholdVariator threshold, Input input)
        {
            switch (index)
            {
                case 0: return new CriterionPartialOrlov(threshold, input.GetPrecision());
                case 1: return new CriterionMinSymmetryByShrader(threshold, input.GetPrecision());
                case 2: return new CriterionMinSimmetryByIntervals(threshold, input.GetPrecision());
                case 3: return new CriterionEqualityOfDepths(threshold, input.GetPrecision());
                case 4: return new CriterionAttitudeOfRemoteness(threshold, input.GetPrecision());
                case 5: return new CriterionMinimumRegularity(threshold, input.GetPrecision());
                case 6: return new CriterionGoldenRatio(threshold, input.GetPrecision());
            }
            return null;
        } 
    }
}