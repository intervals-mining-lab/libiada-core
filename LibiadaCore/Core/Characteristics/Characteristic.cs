namespace LibiadaCore.Core.Characteristics
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

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
            this.Calculator = type;
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
            if (!this.Calculated || !chain.Equals(this.Chain) || link != this.Link)
            {
                this.Chain = chain;
                this.Link = link;
                this.CharacteristicValue = this.Calculator.Calculate(chain, link);
                this.Calculated = true;
            }
            return this.CharacteristicValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public virtual double Value(Chain chain, Link link)
        {
            if (!this.Calculated || !chain.Equals(this.Chain) || link != this.Link)
            {
                this.Chain = chain;
                this.Link = link;
                this.CharacteristicValue = this.Calculator.Calculate(chain, link);
                this.Calculated = true;
            }
            return this.CharacteristicValue;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new Characteristic(this.Calculator)
                {
                    CharacteristicValue = this.CharacteristicValue,
                    Chain = this.Chain,
                    Calculated = this.Calculated,
                    Link = this.Link
                };
            return clone;

        }
    }
}