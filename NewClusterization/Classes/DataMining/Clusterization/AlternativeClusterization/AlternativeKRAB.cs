using System.Collections;
using System.Collections.Generic;
using NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization
{
    /// <summary>
    /// ����� ����������� ������������� ������� KRAB
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
        /// ����������� ������
        /// </summary>
        /// <param name="dataTable">������� � �������</param>
        public AlternativeKRAB(DataTable dataTable, double PowerWeight, double NormalizedDistanseWeight, double DistanseWeight)
        {
            List<Connection> Connections = new List<Connection>(); //������ ������(��� ������)
            List<GraphElement> Elements = new List<GraphElement>();//������ ������

            powerWeight = PowerWeight;
            normalizedDistanseWeight = NormalizedDistanseWeight;
            distanseWeight = DistanseWeight;

            IEnumerator Counter = dataTable.GetEnumerator();//��������
            Counter.Reset();
            Counter.MoveNext();//��������� �� ������� �������
            for (int i = 0; i < dataTable.Count; i++)
            {
                Elements.Add(new GraphElement(((DataObject)((DictionaryEntry)Counter.Current).Value).vault, ((DictionaryEntry)Counter.Current).Key));
                Counter.MoveNext();//������� � ���������� ��������
            }
            for (int j = 0; j < Elements.Count - 1; j++)
            {
                for (int k = j + 1; k < Elements.Count; k++)
                {
                    Connections.Add(new Connection(j,k));
                }
            }

            manager = new GraphManager(Connections, Elements);
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanseWeight, distanseWeight); //���������� ����������
            manager.ConnectGraph();
        }

        /// <summary>
        /// �����, ������������� ������������� �� �������� ���������� �������
        /// </summary>
        /// <param name="Clusters">���������� ���������</param>
        /// <returns>����������� ������� ���������</returns>
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
            //��������� �������� �� �����
            for (int j = 0; j < optimalDivide.Elements.Count; j++)
            {
                TempRes[optimalDivide.Elements[j].TaxonNumber].Add(optimalDivide.Elements[j]);
            }
            List<ArrayList> Res = new List<ArrayList>();
            // ��������� ������ �������� ��������
            for (int k = 0; k < TempRes.Count; k++)
            {
                if (TempRes[k].Count > 0)
                {
                    Res.Add(TempRes[k]);
                }
            }
            // ���������� �������� � ������ ��������� � ������������
            for (int l = 0; l < Res.Count; l++)
            {
                result.Clusters.Add(new Cluster(Res[l]));
                
            }
            manager = TempManager;
            return result;
        }

        /// <summary>
        /// ����������� ����� ������ ������������ ��������� ����� �� �������
        /// </summary>
        /// <param name="clusters">���������� ���������� ��������� ��� ���������</param>
        /// <param name="position">��������� ������� ��� ��������</param>
        /// <param name="currentManager">���� � ��� ����������</param>
        private void chooseDivizion(int clusters, int position, GraphManager currentManager)
        {
            //���� ��� ��������� ����������� ������ ��������� 
            if (clusters > 1)
            {
                for (int i = position; i < (manager.Connections.Count - clusters); i++)
                {
                    //�������� ����, ����� ��������� ���� �� ��� ���
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
                //���������� �������� ���������
                double f = FCalculator.Calculate(currentManager, manager, powerWeight);
                if (f > optimalF)
                {
                    //���������� ������������ ���������
                    optimalDivide = currentManager;
                    optimalF = f;
                }
            }
        }
        
        /// <summary>
        /// �����, �������������� ������������� � ����������� ��������� 
        /// ������ ��� ������ ��������
        /// </summary>
        /// <param name="Clusters">���������� ���������</param>
        /// <returns>��������� ���������</returns>
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
        /// �����, �������������� ��������� �� ��� ��������� ��������
        /// </summary>
        /// <returns>��������� ���������</returns>
        public ClustarizationVariants ClusterizateAllVariants ()
        {
            return ClusterizateVariantCountClustersBelow(manager.Elements.Count);
        }
    }
}