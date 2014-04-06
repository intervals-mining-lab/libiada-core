namespace Segmentator.Model
{
    /// <summary>
    /// Contains all input parameters
    /// </summary>
    public class Input
    {
        public int Seeker { get; set; }

        public double Precision { get; set; }

        public double Step { get; set; }

        public double LeftBound { get; set; }

        public double RightBound { get; set; }

        public int Balance { get; set; }

        public int Windowlength { get; set; }

        public int WindowDecrement { get; set; }

        public string ChainName { get; set; }

        public int Algorithm { get; set; }

        public int ThresholdMethod { get; set; }

        public int StopCriterion { get; set; }

        public string Chain { get; set; }
    }
}