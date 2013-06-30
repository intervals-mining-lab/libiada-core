using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Матрица веротяностей. 
    ///</summary>
    public class ProbabilityMatrix : MatrixCommon, IProbabilityMatrix, IWritebleMatrix
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="alphPower">Мощность алфавита</param>
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
            if ((Pred.Length > Rank - 1) || (Pred.Length == 0))
            {
                throw new Exception();
            }

            if ((Pred[0] != -1))
            {
                int[] newIndexes = (Pred.Length == 1) ? null : GetChainLess(Pred);
                return ((IProbabilityMatrix)ValueList[Pred[0]]).GetProbabilityVector(alphabet, newIndexes);
            }

            for (int i = 0; i < alphabet.Power; i++)
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