namespace Segmentator.Model.Threshold
{
    using System;

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
            catch (Exception)
            {

            }
            this.step = step;
            this.Current = this.RightBound;
        }

        public override double Next(Criterion.Criterion criterion)
        {
            if (this.Current > this.LeftBound)
            {
                this.Current = this.RightBound;
                this.RightBound = this.RightBound - this.step;
                return this.Current;
            }
            return -1;
        }
    }
}