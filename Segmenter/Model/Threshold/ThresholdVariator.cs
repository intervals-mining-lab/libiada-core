namespace Segmenter.Model.Threshold
{
    using Segmenter.Interfaces;

    /// <summary>
    /// A rule for handle a threshold value
    /// </summary>
    public abstract class ThresholdVariator : IDefinable
    {
        public const double Precision = 0.01;
        protected double leftBound;
        protected double rightBound;
        protected double current;
        protected double best;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        public ThresholdVariator(double leftBound, double rightBound)
        {
            this.leftBound = leftBound;
            this.rightBound = rightBound;
        }

        public double Value
        {
            get { return this.best; }
        }

        /// <summary>
        /// Returns the difference between the right and left bounds
        /// </summary>
        /// <returns>the difference between the right and left bounds</returns>
        public double Distance
        {
            get { return this.rightBound - this.leftBound; }
        }

        /// <summary>
        /// Calculates a new value of the threshold subject to taken criterion
        /// </summary>
        /// <param name="criterion">a rule subject to the threshold changes</param>
        /// <returns>the new value of threshold</returns>
        public abstract double Next(Criterion.Criterion criterion);

        /// <summary>
        /// Fix the best value
        /// </summary>
        public void SaveBest()
        {
            this.best = this.current;
        }

        public double GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}