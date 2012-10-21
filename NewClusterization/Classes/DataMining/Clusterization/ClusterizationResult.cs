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
    }
}