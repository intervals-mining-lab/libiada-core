using System.Collections;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    /// ����������� ������� ��������� �������������.
    ///</summary>
    public static class CharacteristicsFactory
    {

        ///<summary>
        /// ����������� (�������).
        ///</summary>
        public static ICharacteristicCalculator P
        {
            get { return new Probability(); }
        }

        ///<summary>
        /// ���������� ���������� � ����������� �� ��������.
        ///</summary>
        public static ICharacteristicCalculator IntervalsCount
        {
            get { return new IntervalsCount(); }
        }

        ///<summary>
        /// ����� ��������� �� ����������.
        ///</summary>
        public static ICharacteristicCalculator CutLength
        {
            get { return new CutLength(); }
        }

        ///<summary>
        /// ����������.
        ///</summary>
        public static ICharacteristicCalculator G
        {
            get { return new Depth(); }
        }

        ///<summary>
        /// ���������� ���������.
        /// ��� ���������� ���� ��� ���������� 
        /// �������� ���������.
        /// ��� ������������ ���� ��� � �����.
        ///</summary>
        public static ICharacteristicCalculator n
        {
            get { return new Count(); }
        }

        ///<summary>
        /// �������������������� ��������.
        ///</summary>
        public static ICharacteristicCalculator deltaG
        {
            get { return new GeometricMean(); }
        }

        ///<summary>
        /// ������ ��� ����� ���� ����������.
        ///</summary>
        public static ICharacteristicCalculator Length
        {
            get { return new Length(); }
        }

        ///<summary>
        /// ������� �������������� �������� ���� ����������.
        ///</summary>
        public static ICharacteristicCalculator deltaA
        {
            get { return new ArithmeticMean(); }
        }

        ///<summary>
        /// ����� ������������ ����������.
        ///</summary>
        public static ICharacteristicCalculator D
        {
            get { return new DescriptiveInformation(); }
        }

        ///<summary>
        /// ������������.
        ///</summary>
        public static ICharacteristicCalculator r
        {
            get { return new Regularity(); }
        }

        ///<summary>
        /// �������������������� ����������.
        ///</summary>
        public static ICharacteristicCalculator g
        {
            get { return new AverageRemoteness(); }
        }

        ///<summary>
        /// ���������� ���������������� ���������� ������������ �� ���� �������� ���������.
        /// ��������, ���������� ����������.
        ///</summary>
        public static ICharacteristicCalculator H
        {
            get { return new IdentificationInformation(); }
        }

        ///<summary>
        /// ����� ����. ������������ ���� ���� � ����������.
        ///</summary>
        public static ICharacteristicCalculator V
        {
            get { return new Volume(); }
        }

        ///<summary>
        /// �������� ��������.
        ///</summary>
        public static ICharacteristicCalculator Power
        {
            get { return new AlphabetPower(); }
        }

        ///<summary>
        /// ���������� ������������ �� ���� ���������.
        ///</summary>
        public static ICharacteristicCalculator nG
        {
            get { return new NormalizedGamut(); }
        }


        ///<summary>
        /// �������������.
        ///</summary>
        public static ICharacteristicCalculator t
        {
            get { return new Periodicity(); }
        }

        ///<summary>
        /// �������� ������� �� ����������.
        ///</summary>
        public static ICharacteristicCalculator CutLenVocEntropy
        {
            get { return new CutLengthVocabularyEntropy(); }
        }

        ///<summary>
        /// ������ ������������� �������������.
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
                //temp.Add(PhChainCount);
                //temp.Add(CutLength);
                //temp.Add(V);
                //temp.Add(CutLenVocEntropy);
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
                if ((type == calculator.GetType().ToString()) ||
                    ("LibiadaCore.Classes.Root.Characteristics.Calculators." + type == calculator.GetType().ToString()))
                {
                    return calculator;
                }
            }
            return null;
        }
    }
}