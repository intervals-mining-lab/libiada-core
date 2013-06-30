using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// ������� ����� ��� ������
    ///</summary>
    public abstract class MatrixBase
    {
        protected readonly int AlphabetPower;
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
        /// <param name="poweOfAlphabet">�������� ��������</param>
        /// <param name="razmernost">����������� �������</param>
        /// <param name="Builder">������� �������� ������</param>
        public MatrixBase(int poweOfAlphabet, int razmernost, IMatrixBuilder Builder)
        {
            AlphabetPower = poweOfAlphabet;
            ValueList = new ArrayList();
            Rank = razmernost;
            for (int i = 0; i < AlphabetPower; i++)
            {
                ValueList.Add(Builder.Create(AlphabetPower, razmernost - 1));
            }
        }

        ///<summary>
        /// �������� ��������
        ///</summary>
        public int AlpahbetPower
        {
            get
            {
                return AlphabetPower;
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