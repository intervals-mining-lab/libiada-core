using System;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class ErrorType : TypeBase
    {
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static ErrorType FullP
        {
            get
            {
                ErrorType EType = new ErrorType();
                EType.Name = "Fatal error";
                EType.pMIME = "Error";
                EType.Size = 0;
                return EType;
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static ErrorType CalculationsComplete
        {
            get
            {
                ErrorType EType = new ErrorType();
                EType.Name = "No Errors was detected";
                EType.pMIME = "NoError";
                EType.Size = 0;
                return EType;
            }

        }

        ///<summary>
        ///</summary>
        public static ErrorType Calculating
        {
            get
            {
                ErrorType EType = new ErrorType();
                EType.Name = "Calculating result";
                EType.pMIME = "Calculate";
                EType.Size = 0;
                return EType;
            }

        }

          ///<summary>
          ///</summary>
        public static ErrorType IdError
        {
            get
            {
                ErrorType EType = new ErrorType();
                EType.Name = "Id does not exist";
                EType.pMIME = "IdError";
                EType.Size = 0;
                return EType;
            }
        }

    }
}