using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public class DifCutter
    {
        public List<String> cut(String chain, CutRule rule)
        {
            List<String> result = new List<String>();

            rule.getIterator();
            CutRuleIterator iterator = rule.getIterator();

            while (iterator.next())
            {
                String s = chain.Substring(iterator.getStartPos() - 1, iterator.getStopPos());
                result.Add(s);
            }
            return result;
        }
    }
}
