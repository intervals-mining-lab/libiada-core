using System;
using System.Collections;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.MatrixCalculus
{
    ///<summary>
    ///</summary>
    public class Matrix: IEnumerable, ICloneable, IMatrixBin
    {
        private Alphabet pAlphabet = new Alphabet();
        private double[,] vault = null;

        ///<summary>
        ///</summary>
        public int RowCount
        {
            get
            {
                return vault.GetLength(0);
            }
        }

        ///<summary>
        ///</summary>
        public Alphabet Alphabet
        {
            get { return (Alphabet) pAlphabet.Clone(); }
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        public Matrix(DataTable dt)
        {
            foreach (DictionaryEntry item in dt)
            {
                pAlphabet.Add((ValueInt) (int) item.Key);
            }
            init();
        }

        private void init()
        {
            vault = new double[pAlphabet.power,pAlphabet.power];
            for (int i = 0; i < vault.GetLength(0); i++)
            {
                for (int j = 0; j < vault.GetLength(0); j++)
                {
                    vault[i, j] = Double.NaN;
                }
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="Alph"></param>
        public Matrix(Alphabet Alph)
        {
            pAlphabet = (Alphabet) Alph.Clone();
            init();
        }

        protected Matrix()
        {
            
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<param name="j"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public double Get(int i, int j)
        {
            if (pAlphabet.IndexOf((ValueInt)i) >= vault.GetLength(0) || pAlphabet.IndexOf((ValueInt)j) >= vault.GetLength(0))
            {
                throw new ArgumentOutOfRangeException();
            }
            return vault[pAlphabet.IndexOf((ValueInt)i), pAlphabet.IndexOf((ValueInt)j)];
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<param name="j"></param>
        ///<param name="value"></param>
        public void Set(int i, int j, double value)
        {
            vault[pAlphabet.IndexOf((ValueInt)i), pAlphabet.IndexOf((ValueInt)j)] = value;
        }

        public object Clone()
        {
            Matrix Temp = new Matrix();
            Temp.vault = (double[,]) vault.Clone();
            Temp.pAlphabet = (Alphabet) pAlphabet.Clone();
            return Temp;
        }

        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        #region IMatrixBin Members

        double IMatrixBin.Get(int i, int j)
        {
            if (i > vault.GetLength(0) || j > vault.GetLength(0))
            {
                throw new ArgumentOutOfRangeException();
            }
            return vault[i, j];
        }

        void IMatrixBin.Set(int i, int j, double value)
        {
            vault[i,j] = value;            
        }

        #endregion
    }
}