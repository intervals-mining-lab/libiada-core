using System.Collections;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators
{
    ///<summary>
    ///</summary>
    public class ElementStream
    {
        public IBaseObject pMetaInfo;
        protected ArrayList vault = new ArrayList();

        ///<summary>
        ///</summary>
        ///<param name="MetaInfo"></param>
        public ElementStream(FileType MetaInfo)
        {
            pMetaInfo = MetaInfo;
        }


        ///<summary>
        /// Сыойство позволяет получить элемент по индексу
        /// В случае выхода за границы выкидывается исключение
        ///</summary>
        ///<param name="index">номер элемента</param>
        public IBaseObject this[int index]
        {
            get { return (IBaseObject) vault[index]; }
        }

        ///<summary>
        /// Свойство содержащее кол-во элементов в потоке
        /// Только для чтнения
        ///</summary>
        public int Count
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// Добавляет элемент в поток
        /// 
        ///</summary>
        ///<param name="baseObject">ДОбавляемый элемент</param>
        public void Add(IBaseObject baseObject)
        {
            vault.Add(baseObject);
        }
    }
}