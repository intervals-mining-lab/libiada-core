using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// ������� ����� ��� ������
    ///</summary>
    public abstract class MatrixBase
    {
        protected int alphPower;
        protected ArrayList ValueList;
        protected int rang;
        protected double Value;


        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="poweOfAlphabet">�������� ��������</param>
        /// <param name="razmernost">����������� �������</param>
        /// <param name="Builder">������� �������� ������</param>
        public MatrixBase(int poweOfAlphabet, int razmernost, IMatrixBuilder Builder)
        {
            alphPower = poweOfAlphabet;
            ValueList = new ArrayList();
            rang = razmernost;
            for (int i = 0; i < alphPower; i++)
            {
                ValueList.Add(Builder.Create(alphPower, razmernost - 1));
            }
        }

        ///<summary>
        /// �������� ��������
        ///</summary>
        public int AlpahbetPower
        {
            get
            {
                return alphPower;
            }
        }

        ///<summary>
        /// ����������� �������.
        /// ������ ������.
        ///</summary>
        public int Rang
        {
            get
            {
                return rang;
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