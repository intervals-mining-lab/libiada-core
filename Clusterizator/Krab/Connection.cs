namespace Clusterizator.Krab
{
    using System;

    /// <summary>
    /// �����-��������� �������� ���� ����� � ��������� ���������� ����� ���� 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="firstElement">
        /// ������ ������� �������.
        /// </param>
        /// <param name="secondElement">
        /// ������ ������� �������.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if element or elements are negative.
        /// </exception>
        public Connection(int firstElement, int secondElement)
        {
            if ((firstElement < 0) || (secondElement < 0))
            {
                throw new ArgumentException("������ �� ����� ���� �������������");
            }

            Connected = false;
            FirstElementIndex = firstElement;
            SecondElementIndex = secondElement;
        }

        /// <summary>
        /// ������������� ��������� �� ������ ���� �����.
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// ��������� ����������.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// ������������� ��������� ����������.
        /// </summary>
        public double NormalizedDistance { get; set; }

        /// <summary>
        /// ��������� ��������� �����.
        /// </summary>
        public double TauStar { get; set; }

        /// <summary>
        /// ������������� ��������� ��������� �����.
        /// </summary>
        public double Tau { get; set; }

        /// <summary>
        /// ������-����������.
        /// </summary>
        public double Lambda { get; set; }

        /// <summary>
        /// ������ ������ �����.
        /// </summary>
        public int FirstElementIndex { get; private set; }

        /// <summary>
        /// ������ ������ �����.
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
            var clone = new Connection(FirstElementIndex, SecondElementIndex)
                {
                    Connected = Connected, 
                    Distance = Distance, 
                    NormalizedDistance = NormalizedDistance, 
                    TauStar = TauStar, 
                    Tau = Tau, 
                    Lambda = Lambda
                };
            return clone;
        }
    }
}