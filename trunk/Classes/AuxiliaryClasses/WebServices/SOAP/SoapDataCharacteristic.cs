using System;
using System.Collections.Specialized;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Soap класс, соответствующий элементу массива <see cref="HybridDictionary"/>.
    ///</summary>
    [Serializable]
    public class SoapDataCharacteristic
    {
        ///<summary>
        /// —троковый ключ по которому в массиве ищетс€ значение.
        /// ѕри кластеризации здесь должен быть идентификатор,
        /// указыывающий на тип характеристики в <see cref="Value"/>.
        ///</summary>
        public string Key;
        ///<summary>
        /// ¬ещественное значение какой-либо численной характеристики.
        ///</summary>
        public double Value;
    }
}