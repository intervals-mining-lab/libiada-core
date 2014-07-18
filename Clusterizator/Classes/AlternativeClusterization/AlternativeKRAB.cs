namespace Clusterizator.Classes.AlternativeClusterization
{
    using System.Collections;
    using System.Collections.Generic;

    using Clusterizator.Classes.AlternativeClusterization.Calculators;

    /// <summary>
    /// ����� ����������� ������������� ������� KRAB
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
            // ������ ������(��� ������)
            var connections = new List<Connection>(); 

            // ������ ������
            var elements = new List<GraphElement>();

            this.powerWeight = powerWeight;

            IEnumerator counter = dataTable.GetEnumerator();
            counter.Reset();

            // ��������� �� ������� �������
            counter.MoveNext();
            for (int i = 0; i < dataTable.Count; i++)
            {
                elements.Add(new GraphElement(((DataObject)((DictionaryEntry)counter.Current).Value).Vault, ((DictionaryEntry)counter.Current).Key));
                
                // ������� � ���������� ��������
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

            // ���������� ����������
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanceWeight, distanceWeight); 
            manager.ConnectGraph();
        }

        /// <summary>
        /// �����, ������������� ������������� �� �������� ���������� �������
        /// </summary>
        /// <param name="clusters">
        /// ���������� ���������
        /// </param>
        /// <returns>
        /// ����������� ������� ���������
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

            // ��������� �������� �� �����
            for (int j = 0; j < optimalDivide.Elements.Count; j++)
            {
                tempRes[optimalDivide.Elements[j].TaxonNumber].Add(optimalDivide.Elements[j]);
            }

            var res = new List<ArrayList>();

            // ��������� ������ �������� ��������
            for (int k = 0; k < tempRes.Count; k++)
            {
                if (tempRes[k].Count > 0)
                {
                    res.Add(tempRes[k]);
                }
            }

            // ���������� �������� � ������ ��������� � ������������
            for (int l = 0; l < res.Count; l++)
            {
                result.Clusters.Add(new Cluster(res[l]));
            }

            manager = tempManager;
            return result;
        }

        /// <summary>
        /// �����, �������������� ������������� � ����������� ��������� 
        /// ������ ��� ������ ��������
        /// </summary>
        /// <param name="clusters">
        /// ���������� ���������
        /// </param>
        /// <returns>
        /// ��������� ���������
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
        /// �����, �������������� ��������� �� ��� ��������� ��������
        /// </summary>
        /// <returns>
        /// ��������� ���������
        /// </returns>
        public ClusterizationVariants ClusterizateAllVariants()
        {
            return ClusterizateVariantCountClustersBelow(manager.Elements.Count);
        }

        /// <summary>
        /// ����������� ����� ������ ������������ ��������� ����� �� �������
        /// </summary>
        /// <param name="clusters">
        /// ���������� ���������� ��������� ��� ���������
        /// </param>
        /// <param name="position">
        /// ��������� ������� ��� ��������
        /// </param>
        /// <param name="currentManager">
        /// ���� � ��� ����������
        /// </param>
        private void ChooseDivision(int clusters, int position, GraphManager currentManager)
        {
            // ���� ��� ��������� ����������� ������ ��������� 
            if (clusters > 1)
            {
                for (int i = position; i < (manager.Connections.Count - clusters); i++)
                {
                    // �������� ����, ����� ��������� ���� �� ��� ���
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
                // ���������� �������� ���������
                double f = QualityCalculator.Calculate(currentManager, manager, powerWeight);
                if (f > optimalF)
                {
                    // ���������� ������������ ���������
                    optimalDivide = currentManager;
                    optimalF = f;
                }
            }
        }
    }
}