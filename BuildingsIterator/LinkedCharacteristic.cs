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
        /// The calculator.
        /// </summary>
        private readonly IFullCalculator calculator;

        /// <summary>
        /// The link.
        /// </summary>
        private readonly Link link;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedCharacteristic"/> class.
        /// </summary>
        /// <param name="calculator">
        /// The calculator of characteristic.
        /// </param>
        /// <param name="link">
        /// The link of characteristic.
        /// </param>
        public LinkedCharacteristic(IFullCalculator calculator, Link link)
        {
            this.calculator = calculator;
            this.link = link;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedCharacteristic"/> class.
        /// </summary>
        /// <param name="calculator">
        /// The calculator of characteristic.
        /// </param>
        public LinkedCharacteristic(IFullCalculator calculator)
        {
            this.calculator = calculator;
            link = Link.Start;
        }

        /// <summary>
        ///  Gets calculator of characteristic.
        /// </summary>
        public IFullCalculator Calculator
        {
            get
            {
                return calculator;
            }
        }

        /// <summary>
        /// Gets link of characteristic.
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
