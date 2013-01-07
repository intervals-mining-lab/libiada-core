using Segmentation.Classes.Base;

namespace Segmentation.Classes.Model.Threshold
{
    public class ThresholdRandom : ThresholdVariator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        public ThresholdRandom(double leftBound, double rightBound)
            : base(leftBound, rightBound)
        {
            formalismType = Formalism.THRESHOLD_RANDOM_METHOD;
        }


        public override double next(Criterion.Criterion criterion)
        {
            return 0;
        }
    }
}