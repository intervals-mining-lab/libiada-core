namespace Segmentator.Model.Threshold
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
        }


        public override double Next(Criterion.Criterion criterion)
        {
            return 0;
        }
    }
}