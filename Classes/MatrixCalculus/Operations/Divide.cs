using ChainAnalises.Classes.MatrixCalculus.Operations;

namespace ChainAnalises.Classes.MatrixCalculus.Operations
{
    ///<summary>
    ///</summary>
    public class Divide : IOperator
    {
        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="B"></param>
        ///<returns></returns>
        public double Calculate(double A, double B)
        {
            return A / B;
        }
    }
}