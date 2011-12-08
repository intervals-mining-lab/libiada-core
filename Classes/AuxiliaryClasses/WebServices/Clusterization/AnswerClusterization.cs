using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;


namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    /// Контейнер с результатами кластеризации
    ///</summary>
    [Serializable]
    public class AnswerClusterization:Answer
    {
        ///<summary>
        /// Массив с вариантами разбиения
        ///</summary>
        public SoapClusterizationVaraints Variant = null;
    }
}