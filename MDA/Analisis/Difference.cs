using System;
using System.Collections;

namespace MDA.Analisis
{
    public class Difference
    {
        /// <summary>
        /// E|(Ft-Fp)|
        /// </summary>
        private double nonP = 0;

        /// <summary>
        /// (E|(Ft-Fp)|)/N
        /// </summary>
        private double ononP = 0;

        /// <summary>
        /// N(E(Ft-Fp)/Ft)
        /// </summary>
        private double sqHi = 0;

        /// <summary>
        /// Max(F1-F2)
        /// </summary>
        private double d = 0;

        /// <summary>
        /// |V1-V2|
        /// </summary>
        private double dV = 0;

        /// <summary>
        /// |V1-V2| / V1
        /// </summary>
        private double pdV = 0;

        public Difference()
        {

        }

        private Difference(double p1, double p2, double p3, double p4, double p5, double p6)
        {
            this.nonP = p1;
            this.ononP = p2;
            this.sqHi = p3;
            this.d = p4;
            this.dV = p5;
            this.pdV = p6;
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
        /// <param name="N">объем выборки</param>
        /// <param name="PCap"></param>
        /// <param name="LCap"></param>
        public void CalcDifference(ArrayList a1, ArrayList a2, int N, int PCap, int LCap)
        {
            if (a1.Count == a2.Count)
            {
                double dif = 0;
                nonP = 0;
                sqHi = 0;
                d = 0;
                for (int i = 0; i < a1.Count; i++)
                {
                    dif = ((double) a1[i]) - ((double) a2[i]);
                    nonP += Math.Abs(dif);
                    if (((double) a1[i]) != 0)
                    {
                        if (LCap >= PCap)
                        {
                            sqHi += Math.Pow(dif, 2)/((double) a1[i]);
                        }
                        else
                        {
                            sqHi += Math.Pow(dif, 2)/((double) a2[i]);
                        }
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
    }
}
