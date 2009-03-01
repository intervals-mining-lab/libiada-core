using System;
using System.Collections;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute
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
            ProbabilityMatrix Temp = new ProbabilityMatrix(alphPower, rang);
            Temp.Fill(this);
            return Temp;

        }

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="alphabet">������� ��� �������</param>
        ///<param name="razmernost">����������� �������</param>
        public Matrix(int powerOfAlphabet, int razmernost)
            : base(powerOfAlphabet, razmernost, new MatrixBuilder())
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

        int IOpenMatrix.rang
        {
            get { return rang; }
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
            if (arrayToTeach == null || arrayToTeach.Length > rang)
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