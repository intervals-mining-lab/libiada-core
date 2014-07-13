namespace BuildingsIterator.Classes
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// ����, ����������� �������������� � ��������
    /// </summary>
    public abstract class LinkedCharacteristic
    {
        /// <summary>
        /// The calc.
        /// </summary>
        private readonly ICalculator calc;

        /// <summary>
        /// The link.
        /// </summary>
        private readonly Link link;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        /// <param name="link">��������</param>
        public LinkedCharacteristic(ICalculator calc, Link link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        public LinkedCharacteristic(ICalculator calc)
        {
            this.calc = calc;
            link = Link.Start;
        }

        /// <summary>
        /// ����������� ��������������
        /// </summary>
        public ICalculator Calc
        {
            get
            {
                return calc;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public Link Link
        {
            get
            {
                return link;
            }
        }
    }
}