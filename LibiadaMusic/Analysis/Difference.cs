using System;
using System.Collections.Generic;

namespace LibiadaMusic.Analysis
{
    public class Difference
    {
        /// <summary>
        /// E|(Ft-Fp)|
        /// </summary>
        public double NonP { get; private set; }
        /// <summary>
        /// (E|(Ft-Fp)|)/N
        /// </summary>
        public double OnonP { get; private set; }
        /// <summary>
        /// N(E(Ft-Fp)/Ft)
        /// </summary>
        public double SqHi { get; private set; }
        /// <summary>
        /// Max(F1-F2)
        /// </summary>
        public double D { get; private set; }
        /// <summary>
        /// |V1-V2|
        /// </summary>
        public double DV { get; private set; }
        /// <summary>
        /// |V1-V2| / V1
        /// </summary>
        public double PdV { get; private set; }

        public Difference()
        {
        }

        private Difference(double p1, double p2, double p3, double p4, double p5, double p6)
        {
            NonP = p1;
            OnonP = p2;
            SqHi = p3;
            D = p4;
            DV = p5;
            PdV = p6;
        }

        public Difference Clone()
        {
            return new Difference(NonP, OnonP, SqHi, D, DV, PdV);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="n">объем выборки</param>
        /// <param name="pCap"></param>
        /// <param name="lCap"></param>
        public void CalcDifference(List<double> a1, List<double> a2, int n, int pCap, int lCap)
        {
            if (a1.Count == a2.Count)
            {
                NonP = 0;
                SqHi = 0;
                D = 0;
                for (int i = 0; i < a1.Count; i++)
                {
                    double diff = a1[i] - a2[i];
                    NonP += Math.Abs(diff);
                    if (a1[i] != 0)
                    {
                        SqHi += Math.Pow(diff, 2)/(lCap >= pCap ? a1[i] : a2[i]);
                    }
                    if (D < Math.Abs(diff))
                    {
                        D = Math.Abs(diff);
                    }
                }
                SqHi = SqHi*n;
                OnonP = NonP/pCap;
            }
        }

        public void CalcDifferenceV(int v1, int v2)
        {
            DV = Math.Abs(v1 - v2);
            PdV = Math.Round((DV/v1)*10000)/100;
        }
    }
}