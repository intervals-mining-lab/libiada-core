namespace LibiadaCore.Classes.Misc.Iterators
{
    public class FromFixStartCutRule : CutRule
    {
        public FromFixStartCutRule(int length, int step)
        {
            for (int i = step; i <= length; i+= step)
            {
                starts.Add(0);
                stops.Add(i);
            }
        }

        public override  CutRuleIterator getIterator()
        {
            return new CutRuleIterator(starts, stops);
        }
    }
}
