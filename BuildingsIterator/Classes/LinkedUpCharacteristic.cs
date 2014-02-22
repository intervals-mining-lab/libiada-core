namespace BuildingsIterator.Classes
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    /// <summary>
    /// ����, ����������� �������������� � ��������
    /// </summary>
    public abstract class LinkedUpCharacteristic
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
        public LinkedUpCharacteristic(ICalculator calc, Link link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        public LinkedUpCharacteristic(ICalculator calc)
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