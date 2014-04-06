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
                case 0: return new ThresholdLinear(input.LeftBound, input.RightBound, input.Step);
                case 1: return new ThresholdDichotomous(input.LeftBound, input.RightBound);
                case 2: return new ThresholdRandom(input.LeftBound, input.RightBound);
                case 3: return null; // Experemental threshold based on any log function
            }

            return null;
        } 
    }
}