using System;
using System.Collections;
using LibiadaCore.Classes.Root;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class ClustarizationResult: IBaseObject
    {
        public ArrayList Clusters = new ArrayList();
        public Double Quality = 0;

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<exception cref="NotImplementedException"></exception>
        public ClustarizationResult(ClustarizationResultBin bin)
        {
            Quality = bin.Quality;
            foreach (ClusterBin cluster in bin.Clusters)
            {
                Clusters.Add(cluster.GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        public ClustarizationResult()
        {
            
        }

        public IBaseObject Clone()
        {
            ClustarizationResult Temp = new ClustarizationResult();
            Temp.Quality = Quality;
            Temp.Clusters = (ArrayList) Clusters.Clone();
            return Temp;
        }

        public IBin GetBin()
        {
            ClustarizationResultBin Temp = new ClustarizationResultBin();
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
    public class ClustarizationResultBin:IBin
    {
        public ArrayList Clusters = new ArrayList();
        public Double Quality = 0;

        public IBaseObject GetInstance()
        {
            return new ClustarizationResult(this);
        }
    }
}