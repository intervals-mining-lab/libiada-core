using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    ///</summary>
    public class Characteristic : IBaseObject
    {
        protected Boolean Calculated = false;
        protected double CharacteristicValue;
        protected LinkUp Link;
        protected ICharacteristicCalculator Calculator = null;
        protected ChainWithCharacteristic pChain = null;

        ///<summary>
        ///</summary>
        public Type GetCharacteristicType
        {
            get
            {
                return Calculator.GetType();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        public Characteristic(ICharacteristicCalculator type)
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
        public virtual double Value(UniformChain chain, LinkUp linkUp)
        {
            if (!Calculated || !chain.Equals(pChain) || linkUp != Link)
            {
                pChain = chain;
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
            if (!Calculated || !chain.Equals(pChain) || linkUp != Link)
            {
                pChain = chain;
                Link = linkUp;
                CharacteristicValue = Calculator.Calculate(chain, linkUp);
                Calculated = true;
            }
            return CharacteristicValue;
        }

        public IBaseObject Clone()
        {
            Characteristic temp = new Characteristic(Calculator);
            temp.CharacteristicValue = CharacteristicValue;
            temp.pChain = pChain;
            temp.Calculated = Calculated;
            temp.Link = Link;
            return temp;

        }
    }
}