namespace LibiadaCore.Classes.Misc.Iterators
{
    public class SimpleCutRuleWithBeginEnd : CutRule
    {
        public SimpleCutRuleWithBeginEnd(int chainLength, int step, int windowLength, int begin)
        {
            for (int i = begin; i + windowLength <= chainLength; i += step)
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
