using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    /// Контейнер с исходными данными для кластеризации.
    ///</summary>
    [Serializable]
    public class RequestClusterization:Request
    {
        /// <summary>
        /// Таблица с объектами для кластеризации
        /// </summary>
        public SoapDataTable DataTable;
        /// <summary>
        /// Тип разбиения 
        /// (на заданное количество кластеров, 
        /// на заданное или меньшее, 
        /// либо все возможные варианты)
        /// </summary>
        public MethodClusterization Method;
        /// <summary>
        /// Требуемое число кластеров
        /// </summary>
        public int ClusterCount;

        /// <summary>
        /// Вес равномощности множеств при оценке качества разбиения
        /// </summary>
        public double PowerWeight = 4;

        /// <summary>
        /// Вес нормализованного расстояния при оценке качества разбиения
        /// </summary>
        public double NormalizedDistanseWeight = 2;

        /// <summary>
        /// Вес обычного расстояния при оценке качества разбиения
        /// </summary>
        public double DistanseWeight = 1;
    }
}