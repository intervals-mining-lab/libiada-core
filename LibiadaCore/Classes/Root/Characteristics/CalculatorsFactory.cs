using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    /// ����������� ������� ��������� �������������.
    ///</summary>
    public static class CalculatorsFactory
    {

        ///<summary>
        /// ����������� (�������).
        ///</summary>
        public static ICalculator P
        {
            get { return new Probability(); }
        }

        ///<summary>
        /// ���������� ���������� � ����������� �� ��������.
        ///</summary>
        public static ICalculator IntervalsCount
        {
            get { return new IntervalsCount(); }
        }

        ///<summary>
        /// ����� ��������� �� ����������.
        ///</summary>
        public static ICalculator CutLength
        {
            get { return new CutLength(); }
        }

        ///<summary>
        /// �������.
        ///</summary>
        public static ICalculator G
        {
            get { return new Depth(); }
        }

        ///<summary>
        /// ���������� ���������.
        /// ��� ���������� ���� ��� ���������� �������� ���������.
        /// ��� ������������ ���� ��� � �����.
        ///</summary>
        public static ICalculator n
        {
            get { return new Count(); }
        }

        ///<summary>
        /// �������������������� ��������.
        ///</summary>
        public static ICalculator deltaG
        {
            get { return new GeometricMean(); }
        }

        ///<summary>
        /// ������ ����.
        ///</summary>
        public static ICalculator Length
        {
            get { return new Length(); }
        }

        ///<summary>
        /// ������ ��� ����� ���� ����������.
        ///</summary>
        public static ICalculator IntervalsSum
        {
            get { return new IntervalsSum(); }
        }

        ///<summary>
        /// ������� �������������� �������� ���� ����������.
        ///</summary>
        public static ICalculator deltaA
        {
            get { return new ArithmeticMean(); }
        }

        ///<summary>
        /// ����� ������������ ����������.
        ///</summary>
        public static ICalculator D
        {
            get { return new DescriptiveInformation(); }
        }

        ///<summary>
        /// ������������.
        ///</summary>
        public static ICalculator r
        {
            get { return new Regularity(); }
        }

        ///<summary>
        /// �������������������� ����������.
        ///</summary>
        public static ICalculator g
        {
            get { return new AverageRemoteness(); }
        }

        ///<summary>
        /// ���������� ���������������� ���������� ������������ �� ���� �������� ���������.
        /// ��������, ���������� ����������.
        ///</summary>
        public static ICalculator H
        {
            get { return new IdentificationInformation(); }
        }

        ///<summary>
        /// ����� ����. ������������ ���� ���� � ����������.
        ///</summary>
        public static ICalculator V
        {
            get { return new Volume(); }
        }

        ///<summary>
        /// �������� ��������.
        ///</summary>
        public static ICalculator Power
        {
            get { return new AlphabetPower(); }
        }

        ///<summary>
        /// ������� ������������ �� ���� ���������.
        ///</summary>
        public static ICalculator nG
        {
            get { return new NormalizedDepth(); }
        }


        ///<summary>
        /// �������������.
        ///</summary>
        public static ICalculator t
        {
            get { return new Periodicity(); }
        }

        ///<summary>
        /// �������� ������� �� ����������.
        ///</summary>
        public static ICalculator CutLenVocEntropy
        {
            get { return new CutLengthVocabularyEntropy(); }
        }

        ///<summary>
        /// ������ ������������� �������������.
        ///</summary>
        public static List<ICalculator> List
        {
            get
            {
                List<ICalculator> temp = new List<ICalculator>
                    {
                        D,
                        deltaA,
                        deltaG,
                        g,
                        G,
                        H,
                        IntervalsCount,
                        Length,
                        n,
                        P,
                        r,
                        Power,
                        nG,
                        t
                    };

                return temp;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<returns></returns>
        public static ICalculator Create(string type)
        {
            foreach (ICalculator calculator in List)
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