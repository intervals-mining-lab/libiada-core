using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public static class DiffCutter
    {
        public static List<String> Cut(String chain, CutRule rule)
        {
            var result = new List<String>();

            rule.GetIterator();
            CutRuleIterator iterator = rule.GetIterator();

            while (iterator.Next())
            {
                String s = chain.Substring(iterator.GetStartPos(), iterator.GetStopPos());
                result.Add(s);
            }
            return result;
        }
    }
}
