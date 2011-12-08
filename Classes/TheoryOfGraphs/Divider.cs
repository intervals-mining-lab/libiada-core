using System.Collections;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    public class Divider
    {
        private Graph Temp = null;

        public Divider(Graph graph)
        {
            Temp = (Graph)graph.Clone();            
        }
        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<returns></returns>
        public ArrayList Divide(Branch branch)
        {
            Temp.Remove(branch);

            ArrayList Result = new ArrayList();
            Result.AddRange(Extract(branch.From));
            Result.AddRange(Extract(branch.To));
            return Result;
        }

        public ArrayList Extract(int from)
        {
            ArrayList Result = new ArrayList();

            Result.Add((new WavePathFinder(Temp)).GetConnectedGraph(from));

            if (((Graph)Result[0]).Points.Count == 0)
            {
                ((Graph)Result[0]).AddPoint(from);
            }

            foreach (int point in ((Graph)Result[0]).Points)
            {
                Temp.Remove(point);
            }
            return Result;
        }
    }
}