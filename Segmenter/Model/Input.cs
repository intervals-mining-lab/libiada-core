namespace Segmenter.Model
{
    /// <summary>
    /// Contains all input parameters
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Gets or sets the seeker.
        /// </summary>
        public int Seeker { get; set; }

        /// <summary>
        /// Gets or sets the precision.
        /// </summary>
        public double Precision { get; set; }

        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        public double Step { get; set; }

        /// <summary>
        /// Gets or sets the left bound.
        /// </summary>
        public double LeftBound { get; set; }

        /// <summary>
        /// Gets or sets the right bound.
        /// </summary>
        public double RightBound { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Gets or sets the window length.
        /// </summary>
        public int WindowLength { get; set; }

        /// <summary>
        /// Gets or sets the window decrement.
        /// </summary>
        public int WindowDecrement { get; set; }

        /// <summary>
        /// Gets or sets the chain name.
        /// </summary>
        public string ChainName { get; set; }

        /// <summary>
        /// Gets or sets the algorithm.
        /// </summary>
        public int Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the threshold method.
        /// </summary>
        public int ThresholdMethod { get; set; }

        /// <summary>
        /// Gets or sets the stop criterion.
        /// </summary>
        public int StopCriterion { get; set; }

        /// <summary>
        /// Gets or sets the chain.
        /// </summary>
        public string Chain { get; set; }
    }
}
