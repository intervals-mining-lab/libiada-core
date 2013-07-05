namespace LibiadaCore.Classes.Misc.Iterators
{
    public class SimpleCutRule : CutRule
    {
        public SimpleCutRule(int chainLength, int step, int windowLength)
        {
            for (int i = 0; i + windowLength < chainLength; i+= step)
            {
                Starts.Add(i);
                Stops.Add(windowLength + i);
            }
        }

        public override CutRuleIterator GetIterator()
        {
            return new CutRuleIterator(Starts, Stops);
        }
    }
}
