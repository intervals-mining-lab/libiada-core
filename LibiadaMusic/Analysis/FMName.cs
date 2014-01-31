namespace LibiadaMusic.Analysis
{
    public class FMName
    {
        private int id = 0;
        private string name;
        
        public FMName(string st) 
        {
            name = st;
        }

        public string Name
        {
            get { return name; }
            
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
