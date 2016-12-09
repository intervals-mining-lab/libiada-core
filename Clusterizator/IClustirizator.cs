using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizator
{
    interface IClustirizator
    {
        int[] Cluster(int clustersCount, double[][] data);
    }
}
