namespace Segmentator.Model.Threshold
{
    /// <summary>
    /// The threshold changes under the law of decrease the right or left bound on 50 %
    /// depending on the external rule
    /// </summary>
    public class ThresholdDichotomous : ThresholdVariator
    {
        private double lastDistortion = double.MaxValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        public ThresholdDichotomous(double leftBound, double rightBound)
            : base(leftBound, rightBound)
        {
            this.current = (rightBound + leftBound) / 2.0;
            this.best = this.current;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (this.rightBound - this.leftBound > Precision)
            {
                double criterionDistortion = criterion.Distortion();
                if (this.lastDistortion > criterionDistortion)
                {
                    this.best = this.current;
                    this.lastDistortion = criterionDistortion;
                }

                this.current = (this.rightBound + this.leftBound) / 2.0;

                if (criterionDistortion < 0)
                {
                    this.leftBound = this.current;
                }
                else
                {
                    this.rightBound = this.current;
                }

                return this.current;
            }

            return -1;
        }
    }
}