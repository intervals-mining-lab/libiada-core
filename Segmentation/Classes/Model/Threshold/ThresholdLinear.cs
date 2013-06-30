using System;

namespace Segmentation.Classes.Model.Threshold
{
    /// <summary>
    /// The threshold changes under the law of decrease the right bound
    /// upon concrete value
    /// </summary>
    public sealed class ThresholdLinear : ThresholdVariator
    {
        private readonly double step;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        /// <param name="step">a value which threshold will be changed</param>
        public ThresholdLinear(double leftBound, double rightBound, double step)
            : base(leftBound, rightBound)
        {
            try
            {
                if ((step > (Math.Abs(rightBound - leftBound))) || (leftBound > rightBound)) throw new Exception();
            }
            catch (Exception ignored)
            {

            }
            this.step = step;
            Current = this.RightBound;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (Current > LeftBound)
            {
                Current = RightBound;
                RightBound = RightBound - step;
                return Current;
            }
            return -1;
        }
    }
}