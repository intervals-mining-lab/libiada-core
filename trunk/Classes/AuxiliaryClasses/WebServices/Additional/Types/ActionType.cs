using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class ActionType : TypeBase
    {
        public LinkUp LinkUp;
        public int BlockSize;
        ///<summary>
        /// ������ �������� �������� �������� �������.
        ///</summary>
        public static ActionType CreateAlphabetByBlock
        {
            get
            {
                ActionType AcType = new ActionType();
                AcType.pname = "Create Alphabet by Block";
                AcType.pMIME = "Create Alphabet by Block";
                return AcType;
            }
        }

        ///<summary>
        /// ������ �������� �������� �������� �������.
        ///</summary>
        public static ActionType Calculate
        {
            get
            {
                ActionType AcType = new ActionType();
                AcType.pname = "Calculate";
                AcType.pMIME = "Calculate";
                return AcType;
            }
        }

    }
}
