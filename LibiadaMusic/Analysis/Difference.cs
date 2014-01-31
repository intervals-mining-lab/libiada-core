using System;
using System.Collections;
using System.Dynamic;

namespace LibiadaMusic.Analysis
{
    public class Difference
    {
        private double nonP=0;  // E|(Ft-Fp)|
        private double ononP = 0;  // (E|(Ft-Fp)|)/N
        private double sqHi=0; // N(E(Ft-Fp)/Ft)
        private double d=0; // Max(F1-F2)
        private double dV = 0; // |V1-V2|
        private double pdV = 0; // |V1-V2| / V1

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

        private Difference(double p1,double p2,double p3,double p4,double p5,double p6)
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
            Difference d = new Difference(nonP, ononP, sqHi, this.d, dV, pdV);
            return d;
        }

        public void CalcDifference(ArrayList a1 ,ArrayList a2, int N, int PCap, int LCap) // N - объем выборки
        {
            if (a1.Count==a2.Count)
            {
                double dif = 0;
                nonP = 0;
                sqHi = 0;
                d = 0;
                for (int i=0;i<a1.Count;i++)
                {
                    dif = ((double)a1[i]) - ((double)a2[i]);
                    nonP += Math.Abs(dif);
                    if (((double)a1[i]) != 0)
                    {
                        if (LCap>=PCap)
                        {
                            sqHi += Math.Pow(dif, 2)/((double) a1[i]);
                        }
                        else
                        {
                            sqHi += Math.Pow(dif, 2)/((double) a2[i]);
                        }
                    }
                    if (d<Math.Abs(dif))
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
