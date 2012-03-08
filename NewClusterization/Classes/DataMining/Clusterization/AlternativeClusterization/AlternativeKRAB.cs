using System.Collections;
using System.Collections.Generic;
using NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization
{
    /// <summary>
    /// Класс реализующий кластеризацию методом KRAB
    /// </summary>
    public class AlternativeKRAB : IClusterization
    {
        private GraphManager manager;
        private GraphManager optimalDivide;
        private double optimalF = 0;
        private double powerWeight;
        private double normalizedDistanseWeight;
        private double distanseWeight;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="dataTable">Таблица с данными</param>
        public AlternativeKRAB(DataTable dataTable, double PowerWeight, double NormalizedDistanseWeight, double DistanseWeight)
        {
            List<Connection> Connections = new List<Connection>(); //массив связей(пар вершин)
            List<GraphElement> Elements = new List<GraphElement>();//массив вершин

            powerWeight = PowerWeight;
            normalizedDistanseWeight = NormalizedDistanseWeight;
            distanseWeight = DistanseWeight;

            IEnumerator Counter = dataTable.GetEnumerator();//итератор
            Counter.Reset();
            Counter.MoveNext();//Установка на нулевой элемент
            for (int i = 0; i < dataTable.Count; i++)
            {
                Elements.Add(new GraphElement(((DataObject)((DictionaryEntry)Counter.Current).Value).vault, ((DictionaryEntry)Counter.Current).Key));
                Counter.MoveNext();//переход к следующему элементу
            }
            for (int j = 0; j < Elements.Count - 1; j++)
            {
                for (int k = j + 1; k < Elements.Count; k++)
                {
                    Connections.Add(new Connection(j,k));
                }
            }

            manager = new GraphManager(Connections, Elements);
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanseWeight, distanseWeight); //вычисление расстояний
            manager.ConnectGraph();
        }

        /// <summary>
        /// Метод, осущствляющий кластеризацию на заданное количество классов
        /// </summary>
        /// <param name="Clusters">Количество кластеров</param>
        /// <returns>Оптимальный вариант разбиения</returns>
        public ClustarizationResult Clusterizate(int Clusters)
        {
            GraphManager TempManager = manager.Clone();
            chooseDivizion(Clusters, 0, manager);
            ClustarizationResult result = new ClustarizationResult();
            List<ArrayList> TempRes = new List<ArrayList>();
            for (int i = 0; i < optimalDivide.GetNextTaxonNumber(); i++)
            {
                TempRes.Add(new ArrayList());
            }
            //Извлекаем кластеры из графа
            for (int j = 0; j < optimalDivide.Elements.Count; j++)
            {
                TempRes[optimalDivide.Elements[j].TaxonNumber].Add(optimalDivide.Elements[j]);
            }
            List<ArrayList> Res = new List<ArrayList>();
            // Сохраняем только непустые кластеры
            for (int k = 0; k < TempRes.Count; k++)
            {
                if (TempRes[k].Count > 0)
                {
                    Res.Add(TempRes[k]);
                }
            }
            // Складываем кластеры в нужный контейнер с результатами
            for (int l = 0; l < Res.Count; l++)
            {
                result.Clusters.Add(new Cluster(Res[l]));
                
            }
            manager = TempManager;
            return result;
        }

        /// <summary>
        /// Рекурсивный метод поиска оптимального разбиения графа на таксоны
        /// </summary>
        /// <param name="clusters">Оставшееся количество кластеров для отделения</param>
        /// <param name="position">Начальная позиция для перебора</param>
        /// <param name="currentManager">Граф и его обработчик</param>
        private void chooseDivizion(int clusters, int position, GraphManager currentManager)
        {
            //если ещё требуются рекурсивные вызовы процедуры 
            if (clusters > 1)
            {
                for (int i = position; i < (manager.Connections.Count - clusters); i++)
                {
                    //копируем граф, чтобы разорвать одну из его дуг
                    GraphManager tempManager = currentManager.Clone();
                    if (tempManager.Connections[i].Connected)
                    {
                        tempManager.Cut(tempManager.Connections[i]);
                        chooseDivizion(clusters - 1, i + 1, tempManager);
                    }
                }
            }
            else
            {
                //вычисление качества разбиения
                double f = FCalculator.Calculate(currentManager, manager, powerWeight);
                if (f > optimalF)
                {
                    //сохранение оптимального разбиения
                    optimalDivide = currentManager;
                    optimalF = f;
                }
            }
        }
        
        /// <summary>
        /// Метод, осуществляющий кластеризацию с количествок кластеров 
        /// меньше или равное заданому
        /// </summary>
        /// <param name="Clusters">Количество кластеров</param>
        /// <returns>Результат разбиения</returns>
        public ClustarizationVariants ClusterizateVariantCountClustersBelow (int Clusters)
        {
            ClustarizationVariants temp = new ClustarizationVariants();
            for (int i = 2; i <= Clusters; i++)
            {
                temp.Variants.Add(Clusterizate(i));
            }
            return temp;
        }

        /// <summary>
        /// Метод, осуществляющий разбиение на все возможные кластеры
        /// </summary>
        /// <returns>Результат разбиения</returns>
        public ClustarizationVariants ClusterizateAllVariants ()
        {
            return ClusterizateVariantCountClustersBelow(manager.Elements.Count);
        }
    }
}