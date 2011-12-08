using System;
using System.Collections.Specialized;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization
{
    /// <summary>
    /// Вершина графа
    /// </summary>
    public class GraphElement
    {
        /// <summary>
        /// Координаты точки в виде хеш-таблицы
        /// </summary>
        public HybridDictionary Content;
        private Object id;
        private int taxonNumber;

        /// <summary>
        /// Имя вершины
        /// </summary>
        public Object Id
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// Номер таксона, которому принадлежит вершина
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
        /// Конструктор инициализирует внутренние значения принятыми параметрами
        /// </summary>
        /// <param name="element"> Координаты</param>
        /// <param name="name"> Имя объекта</param>
        public GraphElement(HybridDictionary element,Object name)
        {
            Content = element;
            id = name;
            taxonNumber = 0;
        }

        ///<summary>
        /// Метод возвращает копию объекта
        ///</summary>
        ///<returns>копия данной вершины графа</returns>
        public GraphElement Clone()
        {
            GraphElement temp = new GraphElement(Content,id);
            temp.TaxonNumber = taxonNumber;
            return temp;
        }
    }
}