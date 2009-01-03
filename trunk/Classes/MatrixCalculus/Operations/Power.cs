using System;

namespace ChainAnalises.Classes.MatrixCalculus.Operations
{
    ///<summary>
    ///</summary>
    public class Power : IOperator
    {
        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="B"></param>
        ///<returns></returns>
        public double Calculate(double A, double B)
        {
            return Math.Pow(A,B);
        }
    }
}