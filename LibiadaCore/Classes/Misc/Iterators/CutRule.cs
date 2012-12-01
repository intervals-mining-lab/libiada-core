using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public abstract class CutRule
    {
        protected List<int> starts = new List<int>();
        protected List<int> stops = new  List<int>();
        public abstract CutRuleIterator getIterator();
    }
}
