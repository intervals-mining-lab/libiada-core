namespace Segmenter.Model.Threshold
{
    /// <summary>
    /// The threshold changes under the law of decrease the right or left bound on 50 %
    /// depending on the external rule
    /// </summary>
    public class ThresholdDichotomous : ThresholdVariator
    {
        /// <summary>
        /// The last distortion.
        /// </summary>
        private double lastDistortion = double.MaxValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThresholdDichotomous"/> class.
        /// </summary>
        /// <param name="leftBound">
        /// The left bound of threshold.
        /// </param>
        /// <param name="rightBound">
        /// The right bound of threshold.
        /// </param>
        public ThresholdDichotomous(double leftBound, double rightBound)
            : base(leftBound, rightBound)
        {
            current = (rightBound + leftBound) / 2.0;
            Value = current;
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <param name="criterion">
        /// The criterion.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public override double Next(Criterion.Criterion criterion)
        {
            if (rightBound - leftBound > Precision)
            {
                double criterionDistortion = criterion.Distortion();
                if (lastDistortion > criterionDistortion)
                {
                    Value = current;
                    lastDistortion = criterionDistortion;
                }

                current = (rightBound + leftBound) / 2.0;

                if (criterionDistortion < 0)
                {
                    leftBound = current;
                }
                else
                {
                    rightBound = current;
                }

                return current;
            }

            return -1;
        }
    }
}
