using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public abstract class CutRule
    {
        protected readonly List<int> Starts = new List<int>();
        protected readonly List<int> Stops = new  List<int>();
        public abstract CutRuleIterator GetIterator();
    }
}
