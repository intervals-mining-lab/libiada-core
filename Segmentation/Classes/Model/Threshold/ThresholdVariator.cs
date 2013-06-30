using Segmentation.Classes.Base;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Model.Threshold
{
    /// <summary>
    /// A rule for handle a threshold value
    /// </summary>
    public abstract class ThresholdVariator : IDefinable
    {
        public const double PRECISION = 0.01;
        protected double LeftBound;
        protected double RightBound;
        protected double Current;
        protected double Best;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftBound">the left bound of threshold</param>
        /// <param name="rightBound">the right bound of threshold</param>
        public ThresholdVariator(double leftBound, double rightBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
        }

        /// <summary>
        /// Calculates a new value of the threshold subject to taken criterion
        /// </summary>
        /// <param name="criterion">a rule subject to the threshold changes</param>
        /// <returns>the new value of threshold</returns>
        public abstract double Next(Criterion.Criterion criterion);

        /// <summary>
        /// Returns the difference between the right and left bounds
        /// </summary>
        /// <returns>the difference between the right and left bounds</returns>
        public double Distance()
        {
            return (this.RightBound - this.LeftBound);
        }

        public double Value
        {
            get { return Best; }
            
        }

        /// <summary>
        /// Fix the best value
        /// </summary>
        public void SaveBest()
        {
            Best = Current;
        }

        public double GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}