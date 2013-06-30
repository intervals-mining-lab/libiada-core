using System;
using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    /// Матрица целых значений. 
    ///</summary>
    public class Matrix : MatrixCommon, IAbsoluteMatrix, IOpenMatrix
    {
        ///<summary>
        /// Получить вероятностную матрицу из данной матрицы
        ///</summary>
        ///<returns>Веротяностая матрица</returns>
        public IProbabilityMatrix ProbabilityMatrix()
        {
            ProbabilityMatrix temp = new ProbabilityMatrix(AlphabetPower, Rank);
            temp.Fill(this);
            return temp;

        }

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="alphabetPower">Алфавит для матрицы</param>
        ///<param name="razmernost">Размерность матрицы</param>
        public Matrix(int alphabetPower, int razmernost)
            : base(alphabetPower, razmernost, new MatrixBuilder())
        {
        }

        ///<summary>
        /// Возвращает сумму элементов матрицы
        ///</summary>
        public double Count
        {
            get
            {
                double sum = 0;
                foreach (MatrixBase row in ValueList)
                {
                    sum += row.GetValue();
                }
                return sum;
            }
        }

        ArrayList IOpenMatrix.ValueList
        {
            get { return (ArrayList) ValueList.Clone(); }
        }

        int IOpenMatrix.Rank
        {
            get { return Rank; }
        }

        double IOpenMatrix.Value
        {
            get { return Value; }
        }
        

        ///<summary>
        /// Увеличивает заначение матрицы на 1
        ///</summary>
        public void IncValue()
        {
            Value += 1;
        }

        public double Add(int[] arrayToTeach)
        {
            if (arrayToTeach == null || arrayToTeach.Length > Rank)
            {
                throw new Exception();
            }

            int index = arrayToTeach[0];
            ((IAbsoluteMatrix)ValueList[index]).IncValue();

            if (arrayToTeach.Length <= 1)
            {
                return GetValue();
            }

            int[] newIndexes = GetChainLess(arrayToTeach);
            if (newIndexes[0] == -1)
            {
                return GetValue();
            }
            return ((IAbsoluteMatrix)ValueList[index]).Add(newIndexes);
            
        }

        public double Sum(int[] arrayOfIndexes)
        {
            if (null != arrayOfIndexes && (arrayOfIndexes[0] != -1))
            {
                int index = arrayOfIndexes[0];
                int[] newArray = (arrayOfIndexes.Length == 1) ? null : GetChainLess(arrayOfIndexes);
                return ((IAbsoluteMatrix)ValueList[index]).Sum(newArray);
            }
            else
            {
                return Count;
            }
        }
    }
}