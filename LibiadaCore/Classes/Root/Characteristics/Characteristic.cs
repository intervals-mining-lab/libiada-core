namespace LibiadaCore.Classes.Root.Characteristics
{
    using System;

    using Calculators;

    /// <summary>
    /// The characteristic.
    /// </summary>
    public class Characteristic : IBaseObject
    {
        /// <summary>
        /// The calculated.
        /// </summary>
        protected Boolean Calculated;

        /// <summary>
        /// The characteristic value.
        /// </summary>
        protected double CharacteristicValue;

        /// <summary>
        /// The link.
        /// </summary>
        protected Link Link;

        /// <summary>
        /// The calculator.
        /// </summary>
        protected readonly ICalculator Calculator;

        /// <summary>
        /// The chain.
        /// </summary>
        protected BaseChain Chain;

        /// <summary>
        /// Initializes a new instance of the <see cref="Characteristic"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        public Characteristic(ICalculator type)
        {
            Calculator = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Characteristic"/> class.
        /// </summary>
        protected Characteristic()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        /// s<exception cref="Exception"></exception>
        public virtual double Value(CongenericChain chain, Link link)
        {
            if (!Calculated || !chain.Equals(Chain) || link != Link)
            {
                Chain = chain;
                Link = link;
                CharacteristicValue = Calculator.Calculate(chain, link);
                Calculated = true;
            }
            return CharacteristicValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public virtual double Value(Chain chain, Link link)
        {
            if (!Calculated || !chain.Equals(Chain) || link != Link)
            {
                Chain = chain;
                Link = link;
                CharacteristicValue = Calculator.Calculate(chain, link);
                Calculated = true;
            }
            return CharacteristicValue;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new Characteristic(Calculator)
                {
                    CharacteristicValue = CharacteristicValue,
                    Chain = Chain,
                    Calculated = Calculated,
                    Link = Link
                };
            return clone;

        }
    }
}