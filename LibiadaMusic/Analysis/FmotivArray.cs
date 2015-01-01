namespace LibiadaMusic.Analysis
{
    using System.Collections.Generic;

    public class FmotivArray
    {
        public FmotivArray()
        {
            Data = new List<FmotivName>();
        }

        public List<FmotivName> Data { get; private set; }
        public int Length { get; private set; }

        public void NewRecord(string name)
        {
            Data.Add(new FmotivName(name));
            Length += 1;
        }
    }
}
