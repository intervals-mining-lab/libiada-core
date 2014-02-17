using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public class DefaultCutRule : CutRule
    {
        public DefaultCutRule(List<int> starts, List<int> stops)
        {
            Starts.AddRange(starts);
            Stops.AddRange(stops);
        }


        public DefaultCutRule(int start, int stop)
        {
            Starts.Add(start);
            Stops.Add(stop);
        }

        public override CutRuleIterator GetIterator()
        {
            return new CutRuleIterator(Starts, Stops);
        }
    }
}
