﻿namespace Segmenter.Model.Threshold
{
    using System;

    /// <summary>
    /// The threshold changes under the law of decrease the right bound
    /// upon concrete value
    /// </summary>
    public sealed class ThresholdLinear : ThresholdVariator
    {
        /// <summary>
        /// The step.
        /// </summary>
        private readonly double step;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThresholdLinear"/> class.
        /// </summary>
        /// <param name="leftBound">
        /// The left bound of threshold.
        /// </param>
        /// <param name="rightBound">
        /// The right bound of threshold.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public ThresholdLinear(double leftBound, double rightBound, double step)
            : base(leftBound, rightBound)
        {
            try
            {
                if ((step > Math.Abs(rightBound - leftBound)) || (leftBound > rightBound))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
            }

            this.step = step;
            this.current = this.rightBound;
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
            if (this.current > this.leftBound)
            {
                this.current = this.rightBound;
                this.rightBound = this.rightBound - this.step;
                return this.current;
            }

            return -1;
        }
    }
}