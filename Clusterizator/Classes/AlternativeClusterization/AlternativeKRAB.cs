using System.Collections;
using System.Collections.Generic;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace Clusterizator.Classes.AlternativeClusterization
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

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="dataTable">Таблица с данными</param>
        /// <param name="powerWeight"> </param>
        /// <param name="normalizedDistanseWeight"> </param>
        /// <param name="distanseWeight"> </param>
        public AlternativeKRAB(DataTable dataTable, double powerWeight, double normalizedDistanseWeight, double distanseWeight)
        {
            List<Connection> connections = new List<Connection>(); //массив связей(пар вершин)
            List<GraphElement> elements = new List<GraphElement>();//массив вершин

            this.powerWeight = powerWeight;

            IEnumerator counter = dataTable.GetEnumerator();//итератор
            counter.Reset();
            counter.MoveNext();//Установка на нулевой элемент
            for (int i = 0; i < dataTable.Count; i++)
            {
                elements.Add(new GraphElement(((DataObject)((DictionaryEntry)counter.Current).Value).vault, ((DictionaryEntry)counter.Current).Key));
                counter.MoveNext();//переход к следующему элементу
            }
            for (int j = 0; j < elements.Count - 1; j++)
            {
                for (int k = j + 1; k < elements.Count; k++)
                {
                    connections.Add(new Connection(j,k));
                }
            }

            manager = new GraphManager(connections, elements);
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanseWeight, distanseWeight); //вычисление расстояний
            manager.ConnectGraph();
        }

        /// <summary>
        /// Метод, осущствляющий кластеризацию на заданное количество классов
        /// </summary>
        /// <param name="clusters">Количество кластеров</param>
        /// <returns>Оптимальный вариант разбиения</returns>
        public ClusterizationResult Clusterizate(int clusters)
        {
            GraphManager tempManager = manager.Clone();
            ChooseDivizion(clusters, 0, manager);
            ClusterizationResult result = new ClusterizationResult();
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
            List<ArrayList> res = new List<ArrayList>();
            // Сохраняем только непустые кластеры
            for (int k = 0; k < TempRes.Count; k++)
            {
                if (TempRes[k].Count > 0)
                {
                    res.Add(TempRes[k]);
                }
            }
            // Складываем кластеры в нужный контейнер с результатами
            for (int l = 0; l < res.Count; l++)
            {
                result.Clusters.Add(new Cluster(res[l]));
                
            }
            manager = tempManager;
            return result;
        }

        /// <summary>
        /// Рекурсивный метод поиска оптимального разбиения графа на таксоны
        /// </summary>
        /// <param name="clusters">Оставшееся количество кластеров для отделения</param>
        /// <param name="position">Начальная позиция для перебора</param>
        /// <param name="currentManager">Граф и его обработчик</param>
        private void ChooseDivizion(int clusters, int position, GraphManager currentManager)
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
                        ChooseDivizion(clusters - 1, i + 1, tempManager);
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
        /// <param name="clusters">Количество кластеров</param>
        /// <returns>Результат разбиения</returns>
        public ClustarizationVariants ClusterizateVariantCountClustersBelow (int clusters)
        {
            ClustarizationVariants temp = new ClustarizationVariants();
            for (int i = 2; i <= clusters; i++)
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