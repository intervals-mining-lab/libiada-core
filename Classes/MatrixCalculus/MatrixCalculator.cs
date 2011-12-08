using System;
using ChainAnalises.Classes.MatrixCalculus.Operations;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.MatrixCalculus
{
    ///<summary>
    ///</summary>
    public static class MatrixCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="B"></param>
        public static Matrix Division(Matrix A, Matrix B)
        {
            return OperationOnTwoMatrixes(A, B, new Divide());
        }

        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="d"></param>
        ///<returns></returns>
        public static Matrix Division(Matrix A, double d)
        {
            return OperationOnOneMatrix(A, d, new Divide());
        }

        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="pow"></param>
        ///<returns></returns>
        public static Matrix Pow(Matrix A, int pow)
        {
            return OperationOnOneMatrix(A, pow, new Power());
        }

        private static Matrix OperationOnOneMatrix(Matrix A, double pow, IOperator Operator)
        {
            Matrix Temp = new Matrix(A.Alphabet);
            IMatrixBin from = A;
            IMatrixBin To = Temp;
            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < A.RowCount; j++)
                {
                    if (!from.Get(i, j).Equals(Double.NaN))
                    {
                        To.Set(i, j, Operator.Calculate(from.Get(i, j), pow));
                    }
                }
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<param name="B"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public static Matrix Multiplicate(Matrix A, Matrix B)
        {
            return OperationOnTwoMatrixes(A, B, new Multiplicate());
        }

        private static Matrix OperationOnTwoMatrixes(Matrix A, Matrix B, IOperator Operation)
        {
            Matrix Temp = new Matrix(A.Alphabet);
            if (!A.Alphabet.Equals(B.Alphabet))
            {
                throw new Exception("Try to Divide uncomortable matrixes");
            }
            IMatrixBin workwith = A;
            IMatrixBin workwith2 = B;
            IMatrixBin workwith3 = Temp;
            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < A.RowCount; j++)
                {
                    if (!workwith.Get(i, j).Equals(Double.NaN) && !workwith2.Get(i, j).Equals(Double.NaN))
                    {
                        workwith3.Set(i, j, Operation.Calculate(workwith.Get(i, j), workwith2.Get(i, j)));
                    }
                }
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="mtr"></param>
        ///<returns></returns>
        public static Matrix Bmin(Matrix mtr)
        {
            Matrix Result = (Matrix) mtr.Clone();
            IMatrixBin To = Result;
            IMatrixBin From = mtr;
            for (int i = 0; i < mtr.RowCount; i++)
            {
                for (int j = i + 1; j < mtr.RowCount; j++)
                {
                    To.Set(i, j, FindBMin(i, j, mtr));
                    To.Set(j, i, To.Get(i, j));
                }
            }
            return Result;
        }

        private static double FindBMin(int i, int j, Matrix mtr)
        {
            IMatrixBin From = mtr;
            Double Temp = From.Get(i, j);
            for (int k = 0; k < mtr.RowCount; k++)
            {
                if (Temp > From.Get(i, k))
                {
                    Temp =From.Get(i, k);
                }
            }

            for (int k = 0; k < mtr.RowCount; k++)
            {
                if (Temp > From.Get(j, k))
                {
                    Temp = From.Get(j, k);
                }
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Mtr"></param>
        ///<returns></returns>
        public static double Diameter(Matrix Mtr)
        {
            Double Temp = Double.NaN;

            foreach (double value in Mtr)
            {
                if (Temp.Equals(Double.NaN))
                {
                    Temp = value;
                }
                if ((value != Double.NaN) && (value > Temp))
                {
                    Temp = value;
                }
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<exception cref="NotImplementedException"></exception>
        public static Branch GetIndexesOfMin(Matrix A)
        {
            Branch Temp = null;
            Double Min = double.NaN;
            IMatrixBin From = A;
            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < A.RowCount; j++)
                {
                    if (!From.Get(i, j).Equals(Double.NaN) && ((Double.IsNaN(Min)) || (From.Get(i,j) < Min)))
                    {
                        Temp = new Branch((ValueInt)A.Alphabet[i], (ValueInt)A.Alphabet[j]);
                        Min = From.Get(i, j);
                    }
                }
            }
            return Temp;
            
        }

        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<exception cref="NotImplementedException"></exception>
        public static Branch GetIndexesOfMax(Matrix A)
        {
            Branch Temp = null;
            Double Min = double.NaN;
            IMatrixBin From = A;
            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < A.RowCount; j++)
                {
                    if (!From.Get(i, j).Equals(Double.NaN) && ((Double.IsNaN(Min)) || (From.Get(i, j) > Min)))
                    {
                        Temp = new Branch((ValueInt)A.Alphabet[i], (ValueInt)A.Alphabet[j]);
                        Min = From.Get(i, j);
                    }
                }
            }
            return Temp;

        }

        ///<summary>
        ///</summary>
        ///<param name="m"></param>
        ///<returns></returns>
        public static double Average(Matrix m)
        {
            int i = 0;
            Double Result = 0;
            foreach (Double Value in m)
            {
                if (!Double.IsNaN(Value))
                {
                    Result += Value;
                    i++;
                }
            }

            return Result/i;
        }
    }
}