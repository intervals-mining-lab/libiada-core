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
                case 0: return new CriterionPartialOrlov(threshold, input.getPrecision());
                case 1: return new CriterionMinSymmetryByShrader(threshold, input.getPrecision());
                case 2: return new CriterionMinSimmetryByIntervals(threshold, input.getPrecision());
                case 3: return new CriterionEqualityOfDepths(threshold, input.getPrecision());
                case 4: return new CriterionAttitudeOfRemoteness(threshold, input.getPrecision());
                case 5: return new CriterionMinimumRegularity(threshold, input.getPrecision());
                case 6: return new CriterionGoldenRatio(threshold, input.getPrecision());
            }
            return null;
        } 
    }
}