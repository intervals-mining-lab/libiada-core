namespace MDA.Analisis
{
    public class FMName
    {
        private int id = 0;
        private string name;

        public FMName(string st)
        {
            this.name = st;
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
