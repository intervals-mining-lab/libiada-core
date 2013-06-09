using System;
using Segmentation.Classes.Base;

namespace Segmentation.Classes.Model.Threshold
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
            formalismType = Formalism.THRESHOLD_DICHOTOMIC_METHOD;
            current = (rightBound + leftBound)/2.0;
            best = current;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (rightBound - leftBound > PRECISION)
            {
                double criterionDistortion = criterion.Distortion();
                if (lastDistortion > criterionDistortion)
                {
                    best = current;
                    lastDistortion = criterionDistortion;
                }
                current = (rightBound + leftBound)/2.0;

                if (criterionDistortion < 0) leftBound = current;
                else rightBound = current;

                return current;
            }
            return -1;
        }
    }
}