namespace Segmenter.Model.Threshold
{
    using System;

    using Segmenter.Interfaces;

    /// <summary>
    /// A rule for handle a threshold value
    /// </summary>
    public abstract class ThresholdVariator : IDefinable
    {
        /// <summary>
        /// The precision.
        /// </summary>
        public const double Precision = 0.01;

        /// <summary>
        /// The left bound.
        /// </summary>
        protected double leftBound;

        /// <summary>
        /// The right bound.
        /// </summary>
        protected double rightBound;

        /// <summary>
        /// The current.
        /// </summary>
        protected double current;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThresholdVariator"/> class.
        /// </summary>
        /// <param name="leftBound">
        /// The left bound of threshold.
        /// </param>
        /// <param name="rightBound">
        /// The right bound of threshold.
        /// </param>
        public ThresholdVariator(double leftBound, double rightBound)
        {
            this.leftBound = leftBound;
            this.rightBound = rightBound;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Gets the difference between the right and left bounds
        /// </summary>
        /// <returns>the difference between the right and left bounds</returns>
        public double Distance
        {
            get { return rightBound - leftBound; }
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
            Value = current;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
