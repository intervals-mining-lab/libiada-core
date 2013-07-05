using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    ///</summary>
    public class Characteristic : IBaseObject
    {
        protected Boolean Calculated;
        protected double CharacteristicValue;
        protected LinkUp Link;
        protected ICalculator Calculator;
        protected BaseChain Chain;

 

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        public Characteristic(ICalculator type)
        {
            Calculator = type;
        }

        protected Characteristic()
        {
            
        }


        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public virtual double Value(CongenericChain chain, LinkUp linkUp)
        {
            if (!Calculated || !chain.Equals(Chain) || linkUp != Link)
            {
                Chain = chain;
                Link = linkUp;
                CharacteristicValue = Calculator.Calculate(chain, linkUp);
                Calculated = true;
            }
            return CharacteristicValue;
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public virtual double Value(Chain chain, LinkUp linkUp)
        {
            if (!Calculated || !chain.Equals(Chain) || linkUp != Link)
            {
                Chain = chain;
                Link = linkUp;
                CharacteristicValue = Calculator.Calculate(chain, linkUp);
                Calculated = true;
            }
            return CharacteristicValue;
        }

        public IBaseObject Clone()
        {
            Characteristic result = new Characteristic(Calculator)
                {
                    CharacteristicValue = CharacteristicValue,
                    Chain = Chain,
                    Calculated = Calculated,
                    Link = Link
                };
            return result;

        }
    }
}