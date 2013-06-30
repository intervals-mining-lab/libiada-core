using System;
using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    /// ������� ����� ��������. 
    ///</summary>
    public class Matrix : MatrixCommon, IAbsoluteMatrix, IOpenMatrix
    {
        ///<summary>
        /// �������� ������������� ������� �� ������ �������
        ///</summary>
        ///<returns>������������ �������</returns>
        public IProbabilityMatrix ProbabilityMatrix()
        {
            ProbabilityMatrix temp = new ProbabilityMatrix(AlphabetPower, Rank);
            temp.Fill(this);
            return temp;

        }

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="alphabetPower">������� ��� �������</param>
        ///<param name="razmernost">����������� �������</param>
        public Matrix(int alphabetPower, int razmernost)
            : base(alphabetPower, razmernost, new MatrixBuilder())
        {
        }

        ///<summary>
        /// ���������� ����� ��������� �������
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
        /// ����������� ��������� ������� �� 1
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