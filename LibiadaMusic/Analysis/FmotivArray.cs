using System;
using System.Collections.Generic;

namespace LibiadaMusic.Analysis
{
    public class FmotivArray
    {
        public FmotivArray()
        {
            Data = new List<FmotivName>();
        }

        public List<FmotivName> Data { get; private set; }
        public int Length { get; private set; }

        public void NewRecord(String name)
        {
            Data.Add(new FmotivName(name));
            Length += 1;
        }
    }
}