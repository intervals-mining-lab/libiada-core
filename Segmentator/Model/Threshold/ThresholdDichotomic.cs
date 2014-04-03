namespace Segmentator.Model.Threshold
{
    using System;

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
            this.Current = (rightBound + leftBound)/2.0;
            this.Best = this.Current;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (this.RightBound - this.LeftBound > Precision)
            {
                double criterionDistortion = criterion.Distortion();
                if (this.lastDistortion > criterionDistortion)
                {
                    this.Best = this.Current;
                    this.lastDistortion = criterionDistortion;
                }
                this.Current = (this.RightBound + this.LeftBound)/2.0;

                if (criterionDistortion < 0) this.LeftBound = this.Current;
                else this.RightBound = this.Current;

                return this.Current;
            }
            return -1;
        }
    }
}