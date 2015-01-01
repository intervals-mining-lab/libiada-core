namespace BuildingsIterator
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
        private readonly IFullCalculator calc;

        /// <summary>
        /// The link.
        /// </summary>
        private readonly Link link;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        /// <param name="link">��������</param>
        public LinkedCharacteristic(IFullCalculator calc, Link link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">
        /// ����������� �������������� ����
        /// </param>
        public LinkedCharacteristic(IFullCalculator calc)
        {
            this.calc = calc;
            link = Link.Start;
        }

        /// <summary>
        /// ����������� ��������������
        /// </summary>
        public IFullCalculator Calc
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
