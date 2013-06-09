using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    public class BinaryCharacteristic : Characteristic
    {
        protected IBaseObject reasonElement;
        protected IBaseObject sequenceElement;

        public BinaryCharacteristic( ICharacteristicCalculator type):base(type)
        {
        }

        public double Value(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (!Calculated || !chain.Equals(pChain) || 
                !this.reasonElement.Equals(firstElement) || !this.sequenceElement.Equals(secondElement))
            {
                pChain = chain;
                reasonElement = firstElement;
                sequenceElement = secondElement;
                CharacteristicValue = Calculator.Calculate(chain, linkUp);
                Calculated = true;
            }
            return CharacteristicValue;
        }
    }
}