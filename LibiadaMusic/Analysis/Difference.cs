using System;
using System.Collections.Generic;

namespace LibiadaMusic.Analysis
{
    public class Difference
    {
        private double nonP; // E|(Ft-Fp)|
        private double ononP; // (E|(Ft-Fp)|)/N
        private double sqHi; // N(E(Ft-Fp)/Ft)
        private double d; // Max(F1-F2)
        private double dV; // |V1-V2|
        private double pdV; // |V1-V2| / V1

        public double NonP
        {
            get { return nonP; }
        }

        public double OnonP
        {
            get { return ononP; }
        }

        public double SqHi
        {
            get { return sqHi; }
        }

        public double D
        {
            get { return d; }
        }

        public double DV
        {
            get { return dV; }

        }

        public double PdV
        {
            get { return pdV; }
        }

        public Difference()
        {

        }

        private Difference(double p1, double p2, double p3, double p4, double p5, double p6)
        {
            nonP = p1;
            ononP = p2;
            sqHi = p3;
            d = p4;
            dV = p5;
            pdV = p6;
        }

        public Difference Clone()
        {
            return new Difference(nonP, ononP, sqHi, d, dV, pdV);
        }

        public void CalcDifference(List<double> a1, List<double> a2, int N, int PCap, int LCap) // N - объем выборки
        {
            if (a1.Count == a2.Count)
            {
                nonP = 0;
                sqHi = 0;
                d = 0;
                for (int i = 0; i < a1.Count; i++)
                {
                    double dif = a1[i] - a2[i];
                    nonP += Math.Abs(dif);
                    if (a1[i] != 0)
                    {
                        sqHi += Math.Pow(dif, 2)/(LCap >= PCap ? a1[i] : a2[i]);
                    }
                    if (d < Math.Abs(dif))
                    {
                        d = Math.Abs(dif);
                    }
                }
                sqHi = sqHi*N;
                ononP = nonP/PCap;
            }
        }

        public void CalcDifferenceV(int V1, int V2)
        {
            dV = Math.Abs(V1 - V2);
            pdV = Math.Round((dV/V1)*10000)/100;
        }
    }
}
