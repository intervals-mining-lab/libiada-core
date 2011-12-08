using System;
using System.Collections.Generic;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Матрица веротяностей. 
    ///</summary>
    public class ProbabilityMatrix : MatrixCommon, IProbabilityMatrix, IWritebleMatrix
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="alphabet">Алфавит для матрицы</param>
        ///<param name="razmernost">Размерность матрицы</param>
        public ProbabilityMatrix(int alphPower, int razmernost)
            : base(alphPower, razmernost, new ProbabilityMatixBuilder())
        {
        }

        public void Fill(IOpenMatrix matrix)
        {
            double temp = 0;
            for (int i = 0; i < matrix.ValueList.Count; i++)
            {
                temp += ((IOpenMatrix) matrix.ValueList[i]).Value;
            }

            for (int i = 0; i < ValueList.Count; i++)
            {
                ((IWritebleMatrix) ValueList[i]).Value = (temp == 0)
                                                             ? 0
                                                             : ((IOpenMatrix) matrix.ValueList[i]).Value/temp;
                ((IProbabilityMatrix) ValueList[i]).Fill((IOpenMatrix) matrix.ValueList[i]);
            }
        }

        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred)
        {
            Dictionary<IBaseObject, double> Result = new Dictionary<IBaseObject, double>();
            if ((Pred.Length > rang - 1) || (Pred.Length == 0))
            {
                throw new Exception();
            }

            if (Pred != null && (Pred[0] != -1))
            {
                int[] newIndexes = (Pred.Length == 1) ? null : GetChainLess(Pred);
                return ((IProbabilityMatrix)ValueList[Pred[0]]).GetProbabilityVector(alphabet, newIndexes);
            }

            for (int i = 0; i < alphabet.power; i++)
            {
                Result.Add(alphabet[i], ((MatrixBase)ValueList[i]).GetValue());
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