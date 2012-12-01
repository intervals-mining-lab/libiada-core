using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public class CutRuleIterator
    {
        private List<int> starts;
        private List<int> stops;
        private int i = -1;

        public CutRuleIterator(List<int> starts, List<int> stops)
        {
            this.starts = starts;   //храним начальные позиции
            this.stops = stops;     //храним конечные позиции

        }

        public bool next()
        {
            i++;
            return (starts.Count() > i) && (stops.Count() > i);
        }

        public int getStartPos()
        {
            return starts[i];
        }

        public int getStopPos()
        {
            return stops[i];
        }
    }
}
