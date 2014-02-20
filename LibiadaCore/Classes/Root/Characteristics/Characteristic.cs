namespace LibiadaCore.Classes.Root.Characteristics
{
    using System;

    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    /// <summary>
    /// </summary>
    public class Characteristic : IBaseObject
    {
        protected Boolean Calculated;
        protected double CharacteristicValue;
        protected Link Link;
        protected readonly ICalculator Calculator;
        protected BaseChain Chain;

 

        /// <summary>
        /// </summary>
        ///<param name="type"></param>
        public Characteristic(ICalculator type)
        {
            Calculator = type;
        }

        protected Characteristic()
        {
            
        }


        /// <summary>
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
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
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
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