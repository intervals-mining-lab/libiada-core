using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class Duration : IBaseObject // длительности ноты
    {
        private int numerator; // числитель в дроби доли
        private int denominator; // знаменатель в дроби доли
        private int ticks; // сколько МИДИ тиков в доле

        public Duration(int numerator, int denominator, bool doted, int ticks) 
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.ticks = ticks;
            if (doted) this.placedot();
        }
        public Duration(int numerator, int denominator, int tripletnum, int tripletdenom, bool doted,int ticks)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.ticks = ticks;
            this.placetriplet(tripletnum, tripletdenom);
            if (doted) this.placedot();
        }
        
        public double Value
        {
            get { return (numerator/denominator); }
        } // значение доли в десятичной дроби
        public int Numerator
        {
            get { return numerator; }
        }
        public int Denominator
        {
            get { return denominator; }
        }
        public int Ticks
        {
            get { return ticks; }
        }

        #region privateMethods
        private void placedot() 
        {
            if ((this.numerator % 2) == 0)
            {
                this.numerator = (int)(this.numerator * 1.5);// если четный числитель, то прибавляем к нему половину
            }
            else 
            {
                this.numerator = this.numerator * 3;
                this.denominator = this.denominator * 2;
            }
        }
        private void placetriplet(int triplnum, int tripldenom)
        {
            this.numerator = this.numerator * triplnum;
            this.denominator = this.denominator * tripldenom;
        }
        #endregion

        #region IBaseMethods

        private Duration()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Duration Temp = new Duration(this.numerator, this.denominator, false, this.ticks);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            DurationBin Temp = new DurationBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class DurationBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Duration();
            }
        }

        #endregion
    }
}
