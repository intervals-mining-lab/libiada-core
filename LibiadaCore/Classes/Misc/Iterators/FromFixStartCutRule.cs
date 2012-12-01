namespace LibiadaCore.Classes.Misc.Iterators
{
    public class FromFixStartCutRule : CutRule
    {
        public FromFixStartCutRule(int length, int step)
        {
            for (int i = 1; i <= length / step; i++)
            {
                starts.Add(1);
                stops.Add(i * step);
            }
        }

        public override  CutRuleIterator getIterator()
        {
            return new CutRuleIterator(starts, stops);
        }
    }
}
