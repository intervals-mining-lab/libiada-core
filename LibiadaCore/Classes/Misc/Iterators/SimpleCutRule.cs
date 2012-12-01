namespace LibiadaCore.Classes.Misc.Iterators
{
    public class SimpleCutRule : CutRule
    {
        public SimpleCutRule(int length, int step)
        {

            starts.Add(1);
            stops.Add(step);

            for (int i = 2; i <= length / step; i++)
            {
                starts.Add((i * step) - (step - 1));
                stops.Add(step * i);
            }
        }

        public override CutRuleIterator getIterator()
        {
            return new CutRuleIterator(starts, stops);
        }
    }
}
