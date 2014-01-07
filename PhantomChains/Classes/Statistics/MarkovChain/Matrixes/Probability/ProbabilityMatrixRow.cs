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
    public class ProbabilityMatrixRow : MatrixRowCommon, IProbabilityMatrix, IWritableMatrix
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="powerOfAlphabet">Мощность алфавита</param>
        ///<param name="dimensionality">Размерность матрицы</param>
        public ProbabilityMatrixRow(int powerOfAlphabet, int dimensionality)
            : base(powerOfAlphabet, dimensionality, new ProbabilityMatrixBuilder())
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

        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet)
        {
            return GetProbabilityVector(alphabet, new int[] {});
        }

        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred)
        {
            if (alphabet.Power != alphabetPower)
            {
                throw new Exception();
            }
            if (pred != null && !pred.Equals(NullValue.Instance()))
            {
                throw new Exception();
            }

            var result = new Dictionary<IBaseObject, double>();
            for (int i = 0; i < alphabetPower; i++)
            {
                result.Add(alphabet[i], ((double)ValueList[i]));
            }
            return result;
        }


        double IWritableMatrix.Value
        {
            get { return Value; }
            set { Value = value; }
        }
    }
}