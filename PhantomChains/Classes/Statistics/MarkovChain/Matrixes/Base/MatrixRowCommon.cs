using System;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
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
        ///<param name="powerOfAlphabet">�������� ��������</param>
        ///<param name="dimensionality">����������� �������</param>
        ///<param name="builder">������� �������� ������</param>
        public MatrixRowCommon(int powerOfAlphabet, int dimensionality, IMatrixBuilder builder)
            : base(powerOfAlphabet, dimensionality, builder)
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