using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MDA.Analisis
{
    public class FMotiv
    {
        protected int id;//ID
        protected string name; //Имя
        private int rank;//Ранг
        private double logrank;//Log (Ранг)
        private double occurrence;//Сколько раз встретилось
        private double logoccurrence;// Log(occurrence)
        private double frequency;//Частота
        private double remoteness;// Удаленность
        private double Logremoteness;//ЛогУдаленности
        private double depth;//Глубина
        private double Logdepth;//ЛогГлубины
        ArrayList probability = new ArrayList();// Условные вероятности

        public FMotiv(int ident,string st, int occur,double freq) 
        {
            this.id = ident;
            this.name = st;
            this.occurrence = occur;
            this.logoccurrence = System.Math.Log(occur, 2);
            this.frequency = freq;
        }

        public void SetId(int n)
        {
            this.id = n;
        }
        public int GetId()
        {
            return this.id;
        }

        public void SetName(string n)
        {
            this.name = n;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetRank(int n)
        {
            this.rank = n;
            this.logrank = System.Math.Log(n,2);
        }
        public int GetRank()
        {
            return this.rank;
        }

        public double GetLogRank()
        {
            return this.logrank;
        }

        public void SetOccurernce(double n)
        {
            this.occurrence = n;
        }
        public double GetOccurernce()
        {
            return this.occurrence;
        }

        public void SetLogOccurernce(double n)
        {
            this.logoccurrence = n;
        }
        public double GetLogOccurernce()
        {
            return this.logoccurrence;
        }

        public void SetFrequency(double n)
        {
            this.frequency= n;
        }
        public double GetFrequency()
        {
            return this.frequency;
        }

        public void SetRemoteness(double n)
        {
            this.remoteness = n;
            this.Logremoteness = Math.Log(n, 2);
        }
        public double GetRemoteness()
        {
            return this.remoteness;
        }
        public double GetLogRemoteness()
        {
            return this.Logremoteness;
        }

        public void SetDepth(double n)
        {
            this.depth = n;
            this.Logdepth = Math.Log(n,2);
        }
        public double GetDepth()
        {
            return this.depth;
        }
        public double GetLogDepth()
        {
            return this.Logdepth;
        }

        public void SetProbability(ArrayList n)
        {
            this.probability = n;
        }
        public ArrayList GetProbability()
        {
            return this.probability;
        }

    }
    
}
