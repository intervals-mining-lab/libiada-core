using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Матрица-строка веротяностей.
    ///</summary>
    public class ProbabilityMatixRow : MatrixRowCommon, IProbabilityMatrix, IWritebleMatrix
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="powerOfAlphabet">Мощность алфавита</param>
        ///<param name="razmernost">Размерность матрицы</param>
        public ProbabilityMatixRow(int powerOfAlphabet, int razmernost)
            : base(powerOfAlphabet, razmernost, new ProbabilityMatixBuilder())
        {
        }


        public void Fill(IOpenMatrix matrix)
        {
            double temp = 0;
            for (int i = 0; i < matrix.ValueList.Count; i++)
            {
                temp += (double) matrix.ValueList[i];
            }

            for (int i = 0; i < ValueList.Count; i++)
            {
                ValueList[i] = (temp == 0) ? 0 : ((double) matrix.ValueList[i])/temp;
            }
        }

        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred)
        {
            if (alphabet.Power != AlphabetPower)
            {
                throw new Exception();
            }
            if (Pred != null && !Pred.Equals(NullValue.Instance()))
            {
                throw new Exception();
            }

            Dictionary<IBaseObject, double> Result = new Dictionary<IBaseObject, double>();
            for (int i = 0; i < AlphabetPower; i++)
            {
                Result.Add(alphabet[i], ((double)ValueList[i]));
            }
            return Result;
        }


        double IWritebleMatrix.Value
        {
            get { return Value; }
            set { Value = value; }
        }
    }
}