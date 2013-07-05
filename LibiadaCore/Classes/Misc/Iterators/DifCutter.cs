using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Misc.Iterators
{
    public class DifCutter
    {
        public static List<String> Cut(String chain, CutRule rule)
        {
            List<String> result = new List<String>();

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
