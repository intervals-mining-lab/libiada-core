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
        /// �������� ��������� �������� ������� �� �������
        /// � ������ ������ �� ������� ������������ ����������
        ///</summary>
        ///<param name="index">����� ��������</param>
        public IBaseObject this[int index]
        {
            get { return (IBaseObject) vault[index]; }
        }

        ///<summary>
        /// �������� ���������� ���-�� ��������� � ������
        /// ������ ��� �������
        ///</summary>
        public int Count
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// ��������� ������� � �����
        /// 
        ///</summary>
        ///<param name="baseObject">����������� �������</param>
        public void Add(IBaseObject baseObject)
        {
            vault.Add(baseObject);
        }
    }
}