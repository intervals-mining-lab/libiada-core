using System.Collections;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class Cluster: IBaseObject
    {
        public ArrayList Items = new ArrayList();
        ///<summary>
        ///</summary>
        ///<param name="graph"></param>
        public Cluster(Graph graph)
        {
            Items = (ArrayList) graph.Points.Clone();
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