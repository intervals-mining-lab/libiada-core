using System;
using System.Collections;

namespace ChainAnalises.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    public class WavePathFinder
    {
        private readonly Graph Graph = null;
        private Graph TempGraph = null;
        private readonly ArrayList WavePoints = new ArrayList();
        private Graph ResultGraph = null;

        ///<summary>
        ///</summary>
        ///<param name="graph"></param>
        public WavePathFinder(Graph graph)
        {
            Graph = graph;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<param name="to"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public bool PathExist(int from, int to)
        {
            return GetConnectedGraph(from).Points.Contains(to);
        }

        ///<summary>
        ///</summary>
        ///<param name="point"></param>
        ///<returns></returns>
        public Graph GetConnectedGraph(int point)
        {
            TempGraph = (Graph)Graph.Clone();
            ResultGraph = new Graph();
            WavePoints.Add(point);
            Excecute();
            WavePoints.Clear();

            return ResultGraph;
        }

        private void Excecute()
        {
            if ((WavePoints.Count == 0) || (TempGraph.Count == 0))
            {
                return;
            }

            foreach (int i in new ArrayList(WavePoints))
            {
                ArrayList Points = TempGraph.PointsConnectedWith(i);
                WavePoints.Remove(i);
                foreach (int point in Points)
                {
                    ResultGraph.Add(new Branch(i, point), TempGraph[new Branch(i, point)]);
                    TempGraph.Remove(new Branch(i, point));
                    WavePoints.Add(point);
                }
            }
            Excecute();
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<returns></returns>
        public bool PathExist(Branch branch)
        {
            return PathExist(branch.From, branch.To);
        }
    }
}