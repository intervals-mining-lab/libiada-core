using System;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization
{
    ///<summary>
    ///Класс-контейнер хранящий пару точек и различные расстояния между ними 
    ///</summary>
    public class Connection
    {
        ///<summary>
        /// Характеризует соединена ли данная пара точек
        ///</summary>
        public bool Connected;
        /// <summary>
        /// Евклидово расстояние
        /// </summary>
        public double distance=double.NaN;
        /// <summary>
        /// Нормированное Эвклидово расстояние
        /// </summary>
        public double normalizedDistance = double.NaN;
        /// <summary>
        /// Локальная плотность точек
        /// </summary>
        public double tauStar = double.NaN;
        /// <summary>
        /// Нормированная локальная плотность точек
        /// </summary>
        public double tau = double.NaN;
        /// <summary>
        /// Лямбда-расстояние
        /// </summary>
        public double λ = double.NaN;
        private int firstElementIndex;
        private int secondElementIndex;


        /// <summary>
        /// Индекс первой точки
        /// </summary>
        public int FirstElementIndex
        {
            get
            {
                return firstElementIndex;
            }
        }

        /// <summary>
        /// Индекс второй точки
        /// </summary>
        public int SecondElementIndex
        {
            get
            {
                return secondElementIndex;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="element1">Индекс первого объекта</param>
        /// <param name="element2">Индекс второго объекта</param>
        public Connection(int element1, int element2)
        {
            if ((element1<0)||(element2<0))
            {
                throw new Exception("Индекс не может быть отрицательным");
            }
            Connected = false;
            firstElementIndex = element1;
            secondElementIndex = element2;
        }

        ///<summary>
        /// Метод возвращает копию объекта
        ///</summary>
        ///<returns>копия соединения</returns>
        public Connection Clone()
        {
            Connection temp = new Connection(firstElementIndex,secondElementIndex);
            temp.Connected = Connected;
            temp.distance = distance;
            temp.normalizedDistance = normalizedDistance;
            temp.tauStar = tauStar;
            temp.tau = tau;
            temp.λ = λ;
            return temp;
        }
    }
}