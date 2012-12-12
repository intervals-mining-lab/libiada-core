namespace LibiadaCore.Classes.Misc.Iterators
{
    public class SimpleCutRule : CutRule
    {
        public SimpleCutRule(int chainLength, int step, int windowLength)
        {
            for (int i = 0; i + windowLength < chainLength; i+= step)
            {
                starts.Add(i);
                stops.Add(windowLength + i);
            }
        }

        public override CutRuleIterator getIterator()
        {
            return new CutRuleIterator(starts, stops);
        }
    }
}
