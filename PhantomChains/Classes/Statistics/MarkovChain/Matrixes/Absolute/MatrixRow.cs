using System;
using System.Collections;
using LibiadaCore.Classes.EventTheory;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    /// Матрица-строка абсолютных значений.
    ///</summary>
    public class MatrixRow : MatrixRowCommon, IAbsoluteMatrix, IOpenMatrix
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="alphabet">Алфавит для матрицы</param>
        ///<param name="razmernost">Размерность матрицы</param>
        public MatrixRow(int powerOfAlphabet, int razmernost)
            : base(powerOfAlphabet, razmernost, new MatrixBuilder())
        {
        }

        public double Count
        {
            get 
            {
                double sum=0;
                foreach (double i in ValueList)
                {
                    sum += i;
                }
                return sum;
            }
        }

        ArrayList IOpenMatrix.ValueList
        {
            get { return (ArrayList) ValueList.Clone(); }
        }

        int IOpenMatrix.rang
        {
            get { return Rang; }
        }

        double IOpenMatrix.Value
        {
            get { return GetValue(); }
        }

        public  void IncValue()
        {
            Value += 1;
        }

        public double Sum(int[] arrayOfIndexes)
        {
            if (arrayOfIndexes != null && !arrayOfIndexes.Equals(PsevdoValue.Instance()))
            {
                throw  new Exception();
            }

            return Count;
        }

        public IProbabilityMatrix ProbabilityMatrix()
        {
            ProbabilityMatixRow temp = new ProbabilityMatixRow(alphPower, 1);
            temp.Fill(this);
            return temp;

        }

        public double Add(int[] arrayToTeach)
        {
            if (arrayToTeach == null || arrayToTeach.Length > rang)
            {
                throw new Exception();
            }

            if (arrayToTeach[0] == -1)
            {
                return Value;
            }

            double result = ((double)ValueList[arrayToTeach[0]]) + 1;
            ValueList[arrayToTeach[0]] = result;
            return result;

        }
    }
}