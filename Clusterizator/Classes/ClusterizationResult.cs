using System;
using System.Collections;
using LibiadaCore.Classes.Root;

namespace Clusterizator.Classes
{
    ///<summary>
    ///</summary>
    public class ClusterizationResult: IBaseObject
    {
        public ArrayList Clusters = new ArrayList();
        public Double Quality;

        public IBaseObject Clone()
        {
            ClusterizationResult result = new ClusterizationResult
                {
                    Quality = Quality,
                    Clusters = (ArrayList) Clusters.Clone()
                };
            return result;
        }
    }
}