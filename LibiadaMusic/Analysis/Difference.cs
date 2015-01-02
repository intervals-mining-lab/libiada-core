namespace LibiadaMusic.Analysis
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The difference.
    /// </summary>
    public class Difference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Difference"/> class.
        /// </summary>
        public Difference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Difference"/> class.
        /// </summary>
        /// <param name="p1">
        /// The p 1.
        /// </param>
        /// <param name="p2">
        /// The p 2.
        /// </param>
        /// <param name="p3">
        /// The p 3.
        /// </param>
        /// <param name="p4">
        /// The p 4.
        /// </param>
        /// <param name="p5">
        /// The p 5.
        /// </param>
        /// <param name="p6">
        /// The p 6.
        /// </param>
        private Difference(double p1, double p2, double p3, double p4, double p5, double p6)
        {
            NonP = p1;
            OnonP = p2;
            SqHi = p3;
            D = p4;
            DV = p5;
            PdV = p6;
        }

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

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="Difference"/>.
        /// </returns>
        public Difference Clone()
        {
            return new Difference(NonP, OnonP, SqHi, D, DV, PdV);
        }

        /// <summary>
        /// The calculate difference.
        /// </summary>
        /// <param name="a1">
        /// The a 1.
        /// </param>
        /// <param name="a2">
        /// The a 2.
        /// </param>
        /// <param name="n">
        /// The n.
        /// объем выборки
        /// </param>
        /// <param name="pCap">
        /// The p cap.
        /// </param>
        /// <param name="lCap">
        /// The l cap.
        /// </param>
        public void CalculateDifference(List<double> a1, List<double> a2, int n, int pCap, int lCap)
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
                        SqHi += Math.Pow(diff, 2) / (lCap >= pCap ? a1[i] : a2[i]);
                    }

                    if (D < Math.Abs(diff))
                    {
                        D = Math.Abs(diff);
                    }
                }

                SqHi = SqHi * n;
                OnonP = NonP / pCap;
            }
        }

        /// <summary>
        /// The calculate difference v.
        /// </summary>
        /// <param name="v1">
        /// The v 1.
        /// </param>
        /// <param name="v2">
        /// The v 2.
        /// </param>
        public void CalculateDifferenceV(int v1, int v2)
        {
            DV = Math.Abs(v1 - v2);
            PdV = Math.Round((DV / v1) * 10000) / 100;
        }
    }
}
