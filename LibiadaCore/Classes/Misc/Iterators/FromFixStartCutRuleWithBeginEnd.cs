namespace LibiadaCore.Classes.Misc.Iterators
{
    public class FromFixStartCutRuleWithBeginEnd : CutRule
    {
        public FromFixStartCutRuleWithBeginEnd(int length, int step, int begin)
        {
            for (int i = begin + step; i <= length; i+= step)
            {
                Starts.Add(begin);
                Stops.Add(i < length ? i: length);
            }
        }

        public override  CutRuleIterator GetIterator()
        {
            return new CutRuleIterator(Starts, Stops);
        }
    }
}
