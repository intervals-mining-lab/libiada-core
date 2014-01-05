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
            var clone = new Cluster {Items = (ArrayList) Items.Clone()};
            return clone;
        }
    }
}