namespace Clusterizator.Classes.AlternativeClusterization
{
    using System.Collections;
    using System.Collections.Generic;

    using Clusterizator.Classes.AlternativeClusterization.Calculators;

    /// <summary>
    /// Класс реализующий кластеризацию методом KRAB
    /// </summary>
    public class AlternativeKRAB : IClusterization
    {
        /// <summary>
        /// The power weight.
        /// </summary>
        private readonly double powerWeight;

        /// <summary>
        /// The manager.
        /// </summary>
        private GraphManager manager;

        /// <summary>
        /// The optimal divide.
        /// </summary>
        private GraphManager optimalDivide;

        /// <summary>
        /// The optimal f.
        /// </summary>
        private double optimalF;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlternativeKRAB"/> class.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <param name="powerWeight">
        /// The power weight.
        /// </param>
        /// <param name="normalizedDistanceWeight">
        /// The normalized distance weight.
        /// </param>
        /// <param name="distanceWeight">
        /// The distance weight.
        /// </param>
        public AlternativeKRAB(DataTable dataTable, double powerWeight, double normalizedDistanceWeight, double distanceWeight)
        {
            // массив связей(пар вершин)
            var connections = new List<Connection>(); 

            // массив вершин
            var elements = new List<GraphElement>();

            this.powerWeight = powerWeight;

            IEnumerator counter = dataTable.GetEnumerator();
            counter.Reset();

            // Установка на нулевой элемент
            counter.MoveNext();
            for (int i = 0; i < dataTable.Count; i++)
            {
                elements.Add(new GraphElement(((DataObject)((DictionaryEntry)counter.Current).Value).Vault, ((DictionaryEntry)counter.Current).Key));
                
                // переход к следующему элементу
                counter.MoveNext();
            }

            for (int j = 0; j < elements.Count - 1; j++)
            {
                for (int k = j + 1; k < elements.Count; k++)
                {
                    connections.Add(new Connection(j, k));
                }
            }

            manager = new GraphManager(connections, elements);

            // вычисление расстояний
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanceWeight, distanceWeight); 
            manager.ConnectGraph();
        }

        /// <summary>
        /// Метод, осущствляющий кластеризацию на заданное количество классов
        /// </summary>
        /// <param name="clusters">
        /// Количество кластеров
        /// </param>
        /// <returns>
        /// Оптимальный вариант разбиения
        /// </returns>
        public ClusterizationResult Clusterizate(int clusters)
        {
            GraphManager tempManager = manager.Clone();
            ChooseDivision(clusters, 0, manager);
            var result = new ClusterizationResult();
            var tempRes = new List<ArrayList>();
            for (int i = 0; i < optimalDivide.GetNextTaxonNumber(); i++)
            {
                tempRes.Add(new ArrayList());
            }

            // Извлекаем кластеры из графа
            for (int j = 0; j < optimalDivide.Elements.Count; j++)
            {
                tempRes[optimalDivide.Elements[j].TaxonNumber].Add(optimalDivide.Elements[j]);
            }

            var res = new List<ArrayList>();

            // Сохраняем только непустые кластеры
            for (int k = 0; k < tempRes.Count; k++)
            {
                if (tempRes[k].Count > 0)
                {
                    res.Add(tempRes[k]);
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
        /// Метод, осуществляющий кластеризацию с количествок кластеров 
        /// меньше или равное заданому
        /// </summary>
        /// <param name="clusters">
        /// Количество кластеров
        /// </param>
        /// <returns>
        /// Результат разбиения
        /// </returns>
        public ClusterizationVariants ClusterizateVariantCountClustersBelow(int clusters)
        {
            var temp = new ClusterizationVariants();
            for (int i = 2; i <= clusters; i++)
            {
                temp.Variants.Add(Clusterizate(i));
            }

            return temp;
        }

        /// <summary>
        /// Метод, осуществляющий разбиение на все возможные кластеры
        /// </summary>
        /// <returns>
        /// Результат разбиения
        /// </returns>
        public ClusterizationVariants ClusterizateAllVariants()
        {
            return ClusterizateVariantCountClustersBelow(manager.Elements.Count);
        }

        /// <summary>
        /// Рекурсивный метод поиска оптимального разбиения графа на таксоны
        /// </summary>
        /// <param name="clusters">
        /// Оставшееся количество кластеров для отделения
        /// </param>
        /// <param name="position">
        /// Начальная позиция для перебора
        /// </param>
        /// <param name="currentManager">
        /// Граф и его обработчик
        /// </param>
        private void ChooseDivision(int clusters, int position, GraphManager currentManager)
        {
            // если ещё требуются рекурсивные вызовы процедуры 
            if (clusters > 1)
            {
                for (int i = position; i < (manager.Connections.Count - clusters); i++)
                {
                    // копируем граф, чтобы разорвать одну из его дуг
                    GraphManager tempManager = currentManager.Clone();
                    if (tempManager.Connections[i].Connected)
                    {
                        tempManager.Cut(tempManager.Connections[i]);
                        ChooseDivision(clusters - 1, i + 1, tempManager);
                    }
                }
            }
            else
            {
                // вычисление качества разбиения
                double f = QualityCalculator.Calculate(currentManager, manager, powerWeight);
                if (f > optimalF)
                {
                    // сохранение оптимального разбиения
                    optimalDivide = currentManager;
                    optimalF = f;
                }
            }
        }
    }
}