using System;
using System.Collections;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.DataMining.Clusterization.KRAB
{
    ///<summary>
    ///</summary>
    public class KrabCalusterization:IClusterization
    {
        private readonly DataTable dt = null;
        private Graph VoltageGraph = null;


        ///<summary>
        ///</summary>
        ///<param name="pDt"></param>
        public KrabCalusterization(DataTable pDt)
        {
            dt = pDt;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public ClustarizationResult Clusterizate(int Clusters)
        {
            Clusters--;
            BuildLVoltageGraph();

            Matrix ToDeside = VoltageGraph.AsMatrix();
            ArrayList Result = new ArrayList();
            Graph BreakGraph = new Graph();

            for (int i = 0; i < Clusters; i++)
            {
                Branch Branch = MatrixCalculator.GetIndexesOfMax(ToDeside);
                
                ToDeside.Set(Branch.To, Branch.From, Double.NaN);
                ToDeside.Set(Branch.From, Branch.To, Double.NaN);

                BreakGraph.Add(Branch, VoltageGraph[Branch]);
                VoltageGraph.Remove(Branch);
            }
            Divider Div = new Divider(VoltageGraph);
            foreach (int point in BreakGraph.Points)
            {
                Result.AddRange(Div.Extract(point));                
            }



            ClustarizationResult ToReturn = new ClustarizationResult();
            foreach (Graph graph in Result)
            {
                ToReturn.Clusters.Add(new Cluster(graph));
            }
            ToReturn.Quality = CalculateQuality(BreakGraph, Result);

            return ToReturn;
        }

        private double CalculateQuality(Graph BreakGraph, ArrayList Result)
        {
            double Cr = 0;
            Matrix M;
            foreach (Graph graph in Result)
            {
                double Temp;
                switch(graph.Points.Count)
                {
                    case 1:  
                        Temp = 0;
                        break;
                    case 2:  //--
                        Temp = 1;
                        break;
                    default: 
                        M = graph.AsMatrix();
                        Temp = MatrixCalculator.Average(M);
                        break;
                }
                Cr += Temp;
            }
            Cr = Cr/Result.Count;

            Double Cd = 0;
            if(BreakGraph.Branches.Count >0 )
            {
                M = BreakGraph.AsMatrix();
                Cd = MatrixCalculator.Average(M);                
            }

            M = VoltageGraph.AsMatrix();
            Double V = MatrixCalculator.Average(M);


            return Cd / (Cr +V);
        }

        private void BuildLVoltageGraph()
        {
            Matrix a = dt.GetDistanceMatrix();
            Matrix d = MatrixCalculator.Division(a, MatrixCalculator.Diameter(a));
            Matrix Bmin = MatrixCalculator.Bmin(a);
            Matrix tx = MatrixCalculator.Division(a, Bmin);
            Matrix t = MatrixCalculator.Division(tx, MatrixCalculator.Diameter(tx));
            Matrix t_2 = MatrixCalculator.Pow(t, 2);
            Matrix l = MatrixCalculator.Multiplicate(t_2, d);

            ShortestOpenLoopPathBuilder Builder = new ShortestOpenLoopPathBuilder();
            Graph LSOLP = Builder.Create(l);
            VoltageGraph = GraphCalculator.Voltage(LSOLP);
        }

        ///<summary>
        ///</summary>
        ///<param name="Clusters"></param>
        public ClustarizationVariants ClusterizateVariantCountClustersBelow(int Clusters)
        {
            ClustarizationVariants Result = new  ClustarizationVariants();
            for (int i = 2; i < Clusters; i++)
            {
                Result.Variants.Add(Clusterizate(i));
            }
            return Result;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public ClustarizationVariants ClusterizateAllVariants()
        {
            return ClusterizateVariantCountClustersBelow(dt.Count+1);
        }
    }
}