namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    ///<summary>
    ///</summary>
    public class DBFileType : Node
    {
        private string Field_mime_value;
        private int Field_size_value;
        private string Field_name_value;

        ///<summary>
        ///</summary>
        public virtual string mime
        {
            get { return Field_mime_value; }
            set { Field_mime_value = value; }
        }

        ///<summary>
        ///</summary>
        public virtual int size
        {
            get { return Field_size_value; }
            set { Field_size_value = value; }
        }

        ///<summary>
        ///</summary>
        public virtual string name
        {
            get { return Field_name_value; }
            set { Field_name_value = value; }
        }
    }
}