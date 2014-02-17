namespace LibiadaCore.Classes.Misc.Iterators
{
    public class FromFixStartCutRule : CutRule
    {
        public FromFixStartCutRule(int length, int step)
        {
            for (int i = step; i <= length; i += step)
            {
                Starts.Add(0);
                Ends.Add(i < length ? i: length);
            }
        }

        public override  CutRuleIterator GetIterator()
        {
            return new CutRuleIterator(Starts, Ends);
        }
    }
}
