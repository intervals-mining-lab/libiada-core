using System;
using System.Collections.Generic;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root;
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


        public void Fill(IOpenMatrix Matrix)
        {
            double temp = 0;
            for (int i = 0; i < Matrix.ValueList.Count; i++)
            {
                temp += (double) Matrix.ValueList[i];
            }

            for (int i = 0; i < ValueList.Count; i++)
            {
                ValueList[i] = (temp == 0) ? 0 : ((double) Matrix.ValueList[i])/temp;
            }
        }

        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred)
        {
            if (alphabet.power != alphPower)
            {
                throw new Exception();
            }
            if (Pred != null && !Pred.Equals(PsevdoValue.Instance()))
            {
                throw new Exception();
            }

            Dictionary<IBaseObject, double> Result = new Dictionary<IBaseObject, double>();
            for (int i = 0; i < alphPower; i++)
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