using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    public class ShortestOpenLoopPathBuilder
    {
        ///<summary>
        ///</summary>
        ///<param name="l"></param>
        ///<returns></returns>
        public Graph Create(Matrix l)
        {
            Graph Temp = new Graph();
            WavePathFinder Finder = new WavePathFinder(Temp);
            Branch Branch;
            Matrix lTemp = (Matrix) l.Clone();
            do
            {
                Branch = MatrixCalculator.GetIndexesOfMin(lTemp);
                if ((Branch != null) && !Finder.PathExist(Branch))
                {
                    Temp.Add(Branch, lTemp.Get(Branch.From, Branch.To));
                }
                lTemp.Set(Branch.From, Branch.To, double.NaN);
                lTemp.Set(Branch.To, Branch.From, double.NaN);
            } while ((Temp.Count != lTemp.RowCount-1) && (Branch != null));
            return Temp;
        }
    }
}