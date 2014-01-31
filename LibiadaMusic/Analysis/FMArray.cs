using System;
using System.Collections;

namespace LibiadaMusic.Analysis
{
    public class FMArray
    {
        private ArrayList Ar=new ArrayList();
        private int length;
        public ArrayList Data
        {
            get { return Ar; }
            set { Ar = (ArrayList)value.Clone(); }
            
        }

        public void NewRecord(String str)
        {   Ar.Add(new FMName(str));
            length += 1;
        }
        public int Length
        {
            get { return length; }
            
        }
    }
}
