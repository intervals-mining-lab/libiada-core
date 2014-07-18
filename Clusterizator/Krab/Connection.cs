using System;

namespace Clusterizator.Krab
{
    /// <summary>
    /// �����-��������� �������� ���� ����� � ��������� ���������� ����� ���� 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="element1">
        /// ������ ������� �������
        /// </param>
        /// <param name="element2">
        /// ������ ������� �������
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if element or elements are ntgative.
        /// </exception>
        public Connection(int element1, int element2)
        {
            if ((element1 < 0) || (element2 < 0))
            {
                throw new ArgumentException("������ �� ����� ���� �������������");
            }

            Connected = false;
            this.FirstElementIndex = element1;
            this.SecondElementIndex = element2;
        }

        /// <summary>
        /// ������������� ��������� �� ������ ���� �����
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// ��������� ����������
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// ������������� ��������� ����������
        /// </summary>
        public double NormalizedDistance { get; set; }

        /// <summary>
        /// ��������� ��������� �����
        /// </summary>
        public double TauStar { get; set; }

        /// <summary>
        /// ������������� ��������� ��������� �����
        /// </summary>
        public double Tau { get; set; }

        /// <summary>
        /// ������-����������
        /// </summary>
        public double Lambda { get; set; }

        /// <summary>
        /// ������ ������ �����
        /// </summary>
        public int FirstElementIndex { get; private set; }

        /// <summary>
        /// ������ ������ �����
        /// </summary>
        public int SecondElementIndex { get; private set; }

        /// <summary>
        /// ����� ���������� ����� �������
        /// </summary>
        /// <returns>
        /// ����� ����������
        /// </returns>
        public Connection Clone()
        {
            var clone = new Connection(this.FirstElementIndex, this.SecondElementIndex)
                {
                    Connected = Connected, 
                    Distance = Distance, 
                    NormalizedDistance = NormalizedDistance, 
                    TauStar = TauStar, 
                    Tau = Tau, 
                    Lambda = this.Lambda
                };
            return clone;
        }
    }
}