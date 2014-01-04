using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public class CutRuleIterator
    {
        private readonly List<int> starts;
        private readonly List<int> stops;
        private int i = -1;

        public CutRuleIterator(List<int> starts, List<int> stops)
        {
            this.starts = starts;   //храним начальные позиции
            this.stops = stops;     //храним конечные позиции

        }

        public bool Next()
        {
            i++;
            return (starts.Count() > i) && (stops.Count() > i);
        }

        public int GetStartPos()
        {
            return starts[i];
        }

        public int GetStopPos()
        {
            return stops[i];
        }
    }
}
