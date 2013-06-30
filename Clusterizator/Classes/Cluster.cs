using System.Collections;
using Clusterizator.Classes.AlternativeClusterization;
using LibiadaCore.Classes.Root;

namespace Clusterizator.Classes
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


        private Cluster()
        {
        }

        public IBaseObject Clone()
        {
            Cluster Temp = new Cluster();
            Temp.Items = (ArrayList) Items.Clone();
            return Temp;
        }
    }
}