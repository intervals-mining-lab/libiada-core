using System;
using System.Collections;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.DataMining.Clusterization.KRAB
{
    ///<summary>
    ///</summary>
    public static class GraphCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="lsolp"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public static Graph Voltage(Graph lsolp)
        {
            Graph Temp = (Graph) lsolp.Clone();
            foreach (Branch branch in lsolp.Branches)
            {
                Divider Div = new Divider(lsolp);
                ArrayList Clusters = Div.Divide(branch);
                double m1 = ((Graph) Clusters[0]).Points.Count;
                double m2 = ((Graph) Clusters[1]).Points.Count;
                double m = lsolp.Points.Count;
                double h = 4*(m1/m)*(m2/m);
                Temp[branch] = lsolp[branch] * Math.Pow(h,4);
            }
            return Temp;
        }
    }
}