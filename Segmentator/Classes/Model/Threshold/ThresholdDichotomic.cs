using System;

namespace Segmentator.Classes.Model.Threshold
{
    /// <summary>
    /// The threshold changes under the law of decrease the right or left bound on 50 %
    /// depending on the external rule
    /// </summary>
    public class ThresholdDichotomic : ThresholdVariator
    {
        private double lastDistortion = Double.MaxValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        public ThresholdDichotomic(double leftBound, double rightBound)
            : base(leftBound, rightBound)
        {
            Current = (rightBound + leftBound)/2.0;
            Best = Current;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (RightBound - LeftBound > Precision)
            {
                double criterionDistortion = criterion.Distortion();
                if (lastDistortion > criterionDistortion)
                {
                    Best = Current;
                    lastDistortion = criterionDistortion;
                }
                Current = (RightBound + LeftBound)/2.0;

                if (criterionDistortion < 0) LeftBound = Current;
                else RightBound = Current;

                return Current;
            }
            return -1;
        }
    }
}