using System;
using System.Collections;
using LibiadaCore.Classes.Root;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class ClusterizationResult: IBaseObject
    {
        public ArrayList Clusters = new ArrayList();
        public Double Quality = 0;

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<exception cref="NotImplementedException"></exception>
        public ClusterizationResult(ClusterizationResultBin bin)
        {
            Quality = bin.Quality;
            foreach (ClusterBin cluster in bin.Clusters)
            {
                Clusters.Add(cluster.GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        public ClusterizationResult()
        {
            
        }

        public IBaseObject Clone()
        {
            ClusterizationResult Temp = new ClusterizationResult();
            Temp.Quality = Quality;
            Temp.Clusters = (ArrayList) Clusters.Clone();
            return Temp;
        }

        public IBin GetBin()
        {
            ClusterizationResultBin Temp = new ClusterizationResultBin();
            Temp.Quality = Quality;
            foreach (Cluster cluster in Clusters)
            {
                Temp.Clusters.Add(cluster.GetBin());
            }
            return Temp;
        }
    }

    ///<summary>
    ///</summary>
    public class ClusterizationResultBin : IBin
    {
        public ArrayList Clusters = new ArrayList();
        public Double Quality = 0;

        public IBaseObject GetInstance()
        {
            return new ClusterizationResult(this);
        }
    }
}