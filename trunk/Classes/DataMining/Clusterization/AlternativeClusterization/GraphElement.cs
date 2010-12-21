using System;
using System.Collections.Specialized;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization
{
    /// <summary>
    /// ������� �����
    /// </summary>
    public class GraphElement
    {
        /// <summary>
        /// ���������� ����� � ���� ���-�������
        /// </summary>
        public HybridDictionary Content;
        private Object id;
        private int taxonNumber;

        /// <summary>
        /// ��� �������
        /// </summary>
        public Object Id
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// ����� �������, �������� ����������� �������
        /// </summary>
        public int TaxonNumber
        {
            get
            {
                return taxonNumber;
            }
            set
            {
                if (value>=0)
                {
                    taxonNumber = value;
                }
            }
        }

        /// <summary>
        /// ����������� �������������� ���������� �������� ��������� �����������
        /// </summary>
        /// <param name="element"> ����������</param>
        /// <param name="name"> ��� �������</param>
        public GraphElement(HybridDictionary element,Object name)
        {
            Content = element;
            id = name;
            taxonNumber = 0;
        }

        ///<summary>
        /// ����� ���������� ����� �������
        ///</summary>
        ///<returns>����� ������ ������� �����</returns>
        public GraphElement Clone()
        {
            GraphElement temp = new GraphElement(Content,id);
            temp.TaxonNumber = taxonNumber;
            return temp;
        }
    }
}