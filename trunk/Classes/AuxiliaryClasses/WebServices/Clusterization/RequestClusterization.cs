using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///  онтейнер с исходными данными дл€ кластеризации.
    ///</summary>
    [Serializable]
    public class RequestClusterization:Request
    {
        /// <summary>
        /// “аблица с объектами дл€ кластеризации
        /// </summary>
        public SoapDataTable DataTable;
        /// <summary>
        /// “ип разбиени€ 
        /// (на заданное количество кластеров, 
        /// на заданное или меньшее, 
        /// либо все возможные варианты)
        /// </summary>
        public MethodClusterization Method;
        /// <summary>
        /// “ребуемое число кластеров
        /// </summary>
        public int ClusterCount;


    }
}