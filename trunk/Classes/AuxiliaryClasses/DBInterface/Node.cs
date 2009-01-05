namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    public class Node
    {
        protected int Nid;
        protected int Vid;
        protected string Type;
        protected string Language = "en";
        protected string Title;
        protected int Uid = 1;
        protected int Status = 1;
        protected int Created;
        protected int Changed;
        protected int Comment = 0;
        protected int Promote = 0;
        protected int Moderate = 1;
        protected int Sticky = 0;
        protected int Tnid = 0;
        protected int Translate = 0;
        protected int Use_trigger = 1;

        public Node()
        {
        }

        public virtual int nid
        {
            get { return Nid; }
            set { Nid = value; }
        }

        protected int vid
        {
            get { return Vid; }
            set { Vid = value; }
        }

        protected string type
        {
            get { return Type; }
            set { Type = value; }
        }

        protected string language
        {
            get { return Language; }
            set { Language = value; }
        }

        protected string title
        {
            get { return Title; }
            set { Title = value; }
        }

        protected int uid
        {
            get { return Uid; }
            set { Uid = value; }
        }

        protected int status
        {
            get { return Status; }
            set { Status = value; }
        }

        protected int created
        {
            get { return Created; }
            set { Created = value; }
        }

        protected int changed
        {
            get { return Changed; }
            set { Changed = value; }
        }

        protected int comment
        {
            get { return Comment; }
            set { Comment = value; }
        }

        protected int promote
        {
            get { return Promote; }
            set { Promote = value; }
        }

        protected int moderate
        {
            get { return Moderate; }
            set { Moderate = value; }
        }

        protected int sticky
        {
            get { return Sticky; }
            set { Sticky = value; }
        }

        protected int tnid
        {
            get { return Tnid; }
            set { Tnid = value; }
        }

        protected int translate
        {
            get { return Translate; }
            set { Translate = value; }
        }

        protected int use_trigger
        {
            get { return Use_trigger; }
            set { Use_trigger = value; }
        }
    }
}