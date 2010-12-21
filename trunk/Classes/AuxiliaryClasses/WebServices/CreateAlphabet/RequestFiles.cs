using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;


namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    /// Класс-запрос для построения алфавита
    ///</summary>
    [Serializable]
    public class RequestFiles:Request
    {
        public ActionType Action = null; 
        public File Files = null;
    }
}