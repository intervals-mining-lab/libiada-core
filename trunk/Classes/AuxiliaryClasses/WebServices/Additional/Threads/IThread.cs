using System;
using System.Collections.Generic;
using System.Text;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    ///</summary>
    public abstract class IThread
    {
        protected string hashvalue = null;

        ///<summary>
        ///</summary>
        ///<param name="data"></param>
        public abstract void SetData(object data);

        ///<summary>
        ///</summary>
        ///<param name="hash"></param>
        public  void SetHash(string hash)
        {
            hashvalue = hash;
        }

        ///<summary>
        ///</summary>
        public abstract void Calculate();
    }
}
