using System;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    ///</summary>
    [Serializable]
    public abstract class TypeBase: IBaseObject
    {
        protected String pname = "";
        protected String pMIME = "";
        protected Int64 psize = 1;
        protected int pHashCode = 0;

        ///<summary>
        ///</summary>
        public TypeBase()
        {
            pHashCode = GetHashCode();

        }
        
        ///<summary>
        ///</summary>
        public String Name
        {
            get
            {
                return pname;
            }

            set
            {
                pname = value;
                pHashCode = GetHashCode();
            }
        }

        ///<summary>
        ///</summary>
        public String MIME
        {
            get
            {
                return pMIME;
            }

            set
            {
                pMIME = value;
                pHashCode = GetHashCode();
            }
        }

        ///<summary>
        ///</summary>
        public Int64 Size
        {
            get { return psize; }

            set
            {
                psize = value;
                pHashCode = GetHashCode();
            }
        }

        ///<summary>
        ///</summary>
        public int HashCode
        {
            get { return pHashCode; }
            set
            {

            }
        }

        ///<summary>
        /// Метод описывающий отнощениие эквивалентности, для типов.
        /// Два типа считаются эквивалентными если эквивалентны их имена, MIME и размер.
        ///</summary>
        ///<param name="TypeBase">Тип для отпределния отношения эквивалентности, если передается null возвращаетсч false</param>
        ///<returns>Возвращает true если типы эквивалентны, и false в противном случае</returns>
        public bool Equals(TypeBase TypeBase)
        {
            if (ReferenceEquals(TypeBase, null)) return false;
            if (!Equals(pname, TypeBase.pname)) return false;
            if (!Equals(pMIME, TypeBase.pMIME)) return false;
            if (!Equals(psize, TypeBase.psize)) return false;
            return true;
        }

        public IBaseObject Clone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TypeBase);
        }

        public IBin GetBin()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            int result = pname.GetHashCode();
            result = 29 * result + pMIME.GetHashCode();
            result = 29 * result + psize.GetHashCode();
            return result;
        }
    }
}