using System;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    /// Класс содержащий стандартные ответы 
    /// о состоянии вычислений и их результатах
    ///</summary>
    [Serializable]
    public class ErrorType : TypeBase
    {
        ///<summary>
        /// В процессе вычислений произошла ошибка
        ///</summary>
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
        /// Вычисления завершены
        ///</summary>
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
        /// Вычисления производятся
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
          /// Неверный хеш-код вычисления
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

        ///<summary>
        /// Файл с результатами вычислений не найден либо недоступен
        ///</summary>
        public static ErrorType FileError
        {
            get
            {
                ErrorType EType = new ErrorType();
                EType.Name = "Cannot open result file";
                EType.pMIME = "FileError";
                EType.Size = 0;
                return EType;
            }
        }
    }
}