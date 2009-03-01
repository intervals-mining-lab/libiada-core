using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// �������-������ �������� ����������� ����� � �������� ���������. 
    /// ����������� = 1.
    ///</summary>
    public class MatrixRowCommon:MatrixBase
    {
        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="alphabet">������� �� ������� ������������ �������</param>
        ///<param name="razmernost">����������� �������</param>
        ///<param name="builder">������� �������� ������</param>
        public MatrixRowCommon(int powerOfAlphabet, int razmernost, IMatrixBuilder builder)
            : base(powerOfAlphabet, razmernost, builder)
        {
        }

        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes == null)
            {
                throw new Exception("������ ���������");
            }
            return (double) ValueList[indexes[0]];
        }
    }
}