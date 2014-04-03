namespace Segmentator.Model.Threshold
{
    /// <summary>
    /// Creates one of available threshold method
    /// </summary>
    public static class ThresholdFactory
    {
        public static ThresholdVariator Make(int index, Input input)
        {
            switch (index)
            {
                case 0: return new ThresholdLinear(input.GetLeftBound(), input.GetRightBound(), input.GetStep());
                case 1: return new ThresholdDichotomic(input.GetLeftBound(), input.GetRightBound());
                case 2: return new ThresholdRandom(input.GetLeftBound(), input.GetRightBound());
                case 3: return null; // Experemental threshold based on any log function
            }
            return null;
        } 
    }
}