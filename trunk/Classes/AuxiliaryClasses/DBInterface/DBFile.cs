namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    ///<summary>
    ///</summary>
    public class DBFile : Node
    {
        private string Value;
        private DBFileType private_type = null;

        ///<summary>
        ///</summary>
        public virtual string value
        {
            get { return Value; }
            set { Value = value; }
        }

        ///<summary>
        ///</summary>
        public virtual DBFileType field_type
        {
            get { return private_type; }
            set
            {
                private_type = value;
            }
        }
    }
}