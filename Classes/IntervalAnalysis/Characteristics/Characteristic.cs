using System;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics
{
    ///<summary>
    ///</summary>
    public class Characteristic: IBaseObject 
    {
        protected Boolean Calculated = false;
        protected double pStartValue;
        protected double pEndValue;
        protected double pBothValue;
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
        ///<param name="Type"></param>
        public Characteristic(ICharacteristicCalculator Type)
        {
            Calculator = Type;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public Characteristic(CharacteristicBin Bin)
        {
            pStartValue = Bin.StartValue;
            pEndValue = Bin.EndValue;
            pBothValue = Bin.BothValue;
            Calculator = Bin.Type;
            pChain = Bin.Chain;
        }


        protected Characteristic()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="Chain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public virtual double Value(UniformChain Chain, LinkUp Link)
        {
            if (!Calculated || !Chain.Equals(pChain))
            {
                pChain = Chain;
                pStartValue = Calculator.Calculate(Chain, LinkUp.Start);
                pEndValue = Calculator.Calculate(Chain, LinkUp.End);
                pBothValue = Calculator.Calculate(Chain, LinkUp.Both);
                Calculated = true;
            }
            return GetCurrentValue(Link);
        }

        ///<summary>
        ///</summary>
        ///<param name="Link"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public double GetCurrentValue(LinkUp Link)
        {
            switch (Link)
            {
                case LinkUp.Start:
                    return pStartValue;
                case LinkUp.End:
                    return pEndValue;
                case LinkUp.Both:
                    return pBothValue;
                default:
                    throw new Exception("Супер странная ошибка :)");
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="Chain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Value(Chain Chain, LinkUp Link)
        {
            if (!Calculated || !Chain.Equals(pChain))
            {
                pChain = Chain;
                pStartValue = Calculator.Calculate(Chain, LinkUp.Start);
                pEndValue = Calculator.Calculate(Chain, LinkUp.End);
                pBothValue = Calculator.Calculate(Chain, LinkUp.Both);
                Calculated = true;
            }
            return GetCurrentValue(Link);
        }

        public IBaseObject Clone()
        {
            Characteristic Temp = new Characteristic(Calculator);
            Temp.pStartValue = pStartValue;
            Temp.pEndValue = pEndValue;
            Temp.pBothValue = pBothValue;
            Temp.pChain = pChain;
            Temp.Calculated = Calculated;
            return Temp;

        }

        public IBin GetBin()
        {
            CharacteristicBin  Temp = new CharacteristicBin();
            FillBin(Temp);
            return Temp;

        }

        private void FillBin(CharacteristicBin temp)
        {
            temp.StartValue = pStartValue;
            temp.EndValue = pEndValue;
            temp.BothValue = pBothValue;
            temp.Type = Calculator;
            temp.Chain = pChain;
        }
    }

    ///<summary>
    ///</summary>
    public class CharacteristicBin:IBin
    {
        public double StartValue;
        public double EndValue;
        public double BothValue;
        public ICharacteristicCalculator Type = null;
        public ChainWithCharacteristic Chain = null;

        public IBaseObject GetInstance()
        {
            return new Characteristic(this);
        }
    }
}