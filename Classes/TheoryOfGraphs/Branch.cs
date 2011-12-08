using System;

namespace ChainAnalises.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    public class Branch
    {
        private int pFrom;
        private int pTo;

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<param name="to"></param>
        public Branch(int from, int to)
        {
            if (from == to)
            {
                throw new Exception("Null point");
            }
            pFrom = from;
            pTo = to;
        }

        ///<summary>
        ///</summary>
        public int From
        {
            get { return pFrom; }
            set
            {
                if (pTo ==  value)
                {
                    throw new Exception("Null point");
                }
                pFrom = value;
            }
        }

        ///<summary>
        ///</summary>
        public int To
        {
            get { return pTo; }
            set 
            {
                if (pFrom == value)
                {
                    throw new Exception("Null point");
                }
                pTo = value; 
            }
        }

        public override bool Equals(object obj)
        {
            return (obj != null) && ((Equals(obj as Branch) || ((obj is int) ? Equals((int) obj) : false)));
        }

        ///<summary>
        ///</summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public bool Equals(Branch obj)
        {
            return (obj != null) && (Equals(obj.pTo) && Equals(obj.pFrom));

        }

        ///<summary>
        ///</summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public bool Equals(Int32 obj)
        {
            return ((pTo == obj) || (pFrom == obj));

        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public int GetOtherPoint(int i)
        {
            return (pTo == i) ? pFrom : pTo;
        }
    }
}