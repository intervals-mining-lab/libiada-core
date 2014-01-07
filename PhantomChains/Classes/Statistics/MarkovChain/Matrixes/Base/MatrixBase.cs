using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// ������� ����� ��� ������
    ///</summary>
    public abstract class MatrixBase
    {
        protected readonly int alphabetPower;
        protected readonly ArrayList ValueList;
        ///<summary>
        /// ����������� �������.
        /// ������ ������.
        ///</summary>
        public readonly int Rank;
        protected double Value;


        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="powerOfAlphabet">�������� ��������</param>
        /// <param name="dimensionality">����������� �������</param>
        /// <param name="builder">������� �������� ������</param>
        public MatrixBase(int powerOfAlphabet, int dimensionality, IMatrixBuilder builder)
        {
            alphabetPower = powerOfAlphabet;
            ValueList = new ArrayList();
            Rank = dimensionality;
            for (int i = 0; i < alphabetPower; i++)
            {
                ValueList.Add(builder.Create(alphabetPower, dimensionality - 1));
            }
        }

        ///<summary>
        /// �������� ��������
        ///</summary>
        public int AlphabetPower
        {
            get
            {
                return alphabetPower;
            }
        }

        /// <summary>
        /// ���������� ������� ��������� �������
        /// </summary>
        /// <returns></returns>
        public abstract double FrequencyFromObject(int[] indexes);

        /// <summary>
        /// ��������� ������� � ��������� �������
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            return Value;
        }

        ///<summary>
        /// ���������� ������ ��������� �������
        ///</summary>
        public ArrayList GetValueList
        {
            get
            {
                return ValueList;
            }
        }
    }
}