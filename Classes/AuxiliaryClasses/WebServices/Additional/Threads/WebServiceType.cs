namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// Список типов вычислительных сервисов.
    ///</summary>
    public enum WebServiceType
    {

        ///<summary>
        ///</summary>
        Alphabet,
        ///<summary>
        /// 
        ///</summary>
        Calculate,
        ///<summary>
        ///</summary>
        MarkovChain,
        ///<summary>
        ///</summary>
        Segmentation,
        ///<summary>
        /// Генерация заданного количества фантомных нуклеотидных цепей
        /// для заданной аминокислотной цепи.
        ///</summary>
        PhantomChain,
        ///<summary>
        /// Кластеризация объектов в признаковом пространстве
        /// произвольной размерности алгоритмом лямбда-KRAB.
        ///</summary>
        Clusterization

    }
}