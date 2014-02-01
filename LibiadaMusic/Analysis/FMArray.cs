using System;
using System.Collections.Generic;

namespace LibiadaMusic.Analysis
{
    public class FMArray
    {
        private List<FMName> Ar = new List<FMName>();
        private int length;

        public List<FMName> Data
        {
            get { return Ar; }
            set { Ar = new List<FMName>(value); }
        }

        public void NewRecord(String str)
        {
            Ar.Add(new FMName(str));
            length += 1;
        }

        public int Length
        {
            get { return length; }
        }
    }
}
