namespace BuildingsIterator
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    /// <summary>
    /// Pair of characteristic calculator and link.
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
