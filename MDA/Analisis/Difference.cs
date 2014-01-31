using System;
using System.Collections;
//using System.Linq;

namespace MDA.Analisis
{
    public class Difference
    {
        private double nonP=0;  // E|(Ft-Fp)|
        private double OnonP = 0;  // (E|(Ft-Fp)|)/N
        private double SqHi=0; // N(E(Ft-Fp)/Ft)
        private double D=0; // Max(F1-F2)
        private double dV = 0; // |V1-V2|
        private double pdV = 0; // |V1-V2| / V1

        public Difference()
        {
            
        }

        private Difference(double p1,double p2,double p3,double p4,double p5,double p6)
        {
            this.nonP = p1;
            this.OnonP = p2;
            this.SqHi = p3;
            this.D = p4;
            this.dV = p5;
            this.pdV = p6;
        }

        public Difference Clone()
        {
            Difference d = new Difference(this.GetnonP(), this.GetOnonP(), this.GetSqHi(), this.GetD(), this.GetdV(), this.GetpdV());
            return d;
        }

        public void CalcDifference(ArrayList a1 ,ArrayList a2, int N, int PCap, int LCap) // N - объем выборки
        {
            if (a1.Count==a2.Count)
            {
                double dif = 0;
                nonP = 0;
                SqHi = 0;
                D = 0;
                for (int i=0;i<a1.Count;i++)
                {
                    dif = ((double)a1[i]) - ((double)a2[i]);
                    nonP += Math.Abs(dif);
                    if (((double)a1[i]) != 0)
                    {
                        if (LCap>=PCap)
                        {
                            SqHi += Math.Pow(dif, 2)/((double) a1[i]);
                        }
                        else
                        {
                            SqHi += Math.Pow(dif, 2)/((double) a2[i]);
                        }
                    }
                    if (D<Math.Abs(dif))
                    {
                        D = Math.Abs(dif);
                    }
                }
                SqHi = SqHi*N;
                OnonP = nonP/PCap;
            }
        }

        public void CalcDifferenceV(int V1, int V2)
        {
            dV = Math.Abs(V1 - V2);
            pdV = Math.Round((dV/V1)*10000)/100;
        }



        public double GetnonP()
        {
            return nonP;
        }
        public double GetOnonP()
        {
            return OnonP;
        }
        public double GetSqHi()
        {
            return SqHi;
        }
        public double GetD()
        {
            return D;
        }
        public double GetdV()
        {
            return dV;
        }
        public double GetpdV()
        {
            return pdV;
        }

    }
}
