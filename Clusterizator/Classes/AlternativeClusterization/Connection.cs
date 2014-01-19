using System;

namespace Clusterizator.Classes.AlternativeClusterization
{
    ///<summary>
    ///�����-��������� �������� ���� ����� � ��������� ���������� ����� ���� 
    ///</summary>
    public class Connection
    {
        ///<summary>
        /// ������������� ��������� �� ������ ���� �����
        ///</summary>
        public bool Connected;
        /// <summary>
        /// ��������� ����������
        /// </summary>
        public double Distance = double.NaN;
        /// <summary>
        /// ������������� ��������� ����������
        /// </summary>
        public double NormalizedDistance = double.NaN;
        /// <summary>
        /// ��������� ��������� �����
        /// </summary>
        public double TauStar = double.NaN;
        /// <summary>
        /// ������������� ��������� ��������� �����
        /// </summary>
        public double Tau = double.NaN;
        /// <summary>
        /// ������-����������
        /// </summary>
        public double lambda = double.NaN;
        private readonly int firstElementIndex;
        private readonly int secondElementIndex;


        /// <summary>
        /// ������ ������ �����
        /// </summary>
        public int FirstElementIndex
        {
            get
            {
                return firstElementIndex;
            }
        }

        /// <summary>
        /// ������ ������ �����
        /// </summary>
        public int SecondElementIndex
        {
            get
            {
                return secondElementIndex;
            }
        }

        /// <summary>
        /// ����������� ������
        /// </summary>
        /// <param name="element1">������ ������� �������</param>
        /// <param name="element2">������ ������� �������</param>
        public Connection(int element1, int element2)
        {
            if ((element1<0)||(element2<0))
            {
                throw new Exception("������ �� ����� ���� �������������");
            }
            Connected = false;
            firstElementIndex = element1;
            secondElementIndex = element2;
        }

        ///<summary>
        /// ����� ���������� ����� �������
        ///</summary>
        ///<returns>����� ����������</returns>
        public Connection Clone()
        {
            var clone = new Connection(firstElementIndex,secondElementIndex)
                {
                    Connected = Connected,
                    Distance = Distance,
                    NormalizedDistance = NormalizedDistance,
                    TauStar = TauStar,
                    Tau = Tau,
                    lambda = lambda
                };
            return clone;
        }
    }
}