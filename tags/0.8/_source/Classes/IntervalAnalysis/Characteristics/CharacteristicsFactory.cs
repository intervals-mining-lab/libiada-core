using System.Collections;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using libiada.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics
{
    ///<summary>
    ///</summary>
    public static class CharacteristicsFactory
    {
        public static ICharacteristicCalculator PhChainCount
        {
            get
            {
                return new PhantomMessagesCount();
            }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator P
        {
            get { return new Probability(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator Ph
        {
            get { return new PhantomMessagesCount(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator IntervalsCount
        {
            get { return new IntervalsCount(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator CutLength
        {
            get { return new CutLength(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator G
        {
            get { return new Gamut(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator n
        {
            get { return new Count(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator deltaG
        {
            get { return new GeometricMiddling(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator Length
        {
            get { return new Length(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator deltaA
        {
            get { return new ArithmeticMean(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator D
        {
            get { return new DescriptiveInformation(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator r
        {
            get { return new Regularity(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator g
        {
            get { return new AverageRemoteness(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator H
        {
            get { return new IdentificationInformation(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator Power
        {
            get { return new AlphabetPower(); }
        }

        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator nG
        {
            get { return new NomalizationGamut(); }
        }


        ///<summary>
        ///</summary>
        public static ICharacteristicCalculator t
        {
            get { return new Periodicity(); }
        }

        ///<summary>
        ///</summary>
        public static ArrayList List
        {
            get
            {
                ArrayList temp = new ArrayList();

                temp.Add(D);
                temp.Add(deltaA);
                temp.Add(deltaG);
                temp.Add(g);
                temp.Add(G);
                temp.Add(H);
                temp.Add(IntervalsCount);
                temp.Add(Length);
                temp.Add(n);
                temp.Add(P);
                temp.Add(r);
                temp.Add(Power);
                temp.Add(nG);
                temp.Add(t);
                temp.Add(Ph);
               // temp.Add(CutLength);
                return temp;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<returns></returns>
        public static ICharacteristicCalculator Create(string type)
        {
            foreach (ICharacteristicCalculator calculator in List)
            {
                if (type == calculator.GetType().ToString())
                {
                    return calculator;
                }
            }
            return null;
        }
    }
}