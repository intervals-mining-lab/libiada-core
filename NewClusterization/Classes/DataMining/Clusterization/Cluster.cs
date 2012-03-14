using System.Collections;
using LibiadaCore.Classes.Root;
using NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class Cluster: IBaseObject
    {
        public ArrayList Items = new ArrayList();

        public Cluster(ArrayList points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Items.Add(((GraphElement) points[i]).Id);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        public Cluster(ClusterBin bin)
        {
            Items = (ArrayList)bin.Items.Clone();
        }


        private Cluster()
        {
        }

        public IBaseObject Clone()
        {
            Cluster Temp = new Cluster();
            Temp.Items = (ArrayList) Items.Clone();
            return Temp;
        }

        public IBin GetBin()
        {
            ClusterBin Temp = new ClusterBin();
            Temp.Items = (ArrayList) Items.Clone();
            return Temp;
        }
    }

    ///<summary>
    ///</summary>
    public class ClusterBin: IBin
    {
        public ArrayList Items = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new Cluster(this);
        }
    }
}