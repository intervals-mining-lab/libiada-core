namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    /// Варианты кластеризации
    ///</summary>
    public enum MethodClusterization
    {
        ///<summary>
        /// Производится кластеризация на заданное количество таксонов
        ///</summary>
        Simple, 
        ///<summary>
        /// Производится кластеризация на заданное количество таксонов
        /// и все варианты с меньшим заданного
        ///</summary>
        Less, 
        ///<summary>
        /// Перебираются все возможные количества таксонов
        ///</summary>
        All
    }
}