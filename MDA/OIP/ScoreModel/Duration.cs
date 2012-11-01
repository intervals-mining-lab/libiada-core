using System;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// длительности ноты
    /// </summary>
    public class Duration : IBaseObject
    {
        /// <summary>
        /// числитель в дроби доли
        /// </summary>
        private int numerator;

        /// <summary>
        /// знаменатель в дроби доли
        /// </summary>
        private int denominator;

        /// <summary>
        /// сколько МИДИ тиков в доле
        /// </summary>
        private int ticks;

        /// <summary>
        /// оригинальный числитель в дроби доли (для сохранения после наложения триоли на длительность)
        /// </summary>
        private int onumerator;

        /// <summary>
        /// оригинальный знаменатель в дроби доли(для сохранения после наложения триоли на длительность)
        /// </summary>
        private int odenominator;

        public Duration(int numerator, int denominator, bool doted, int ticks)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.onumerator = numerator;
            this.odenominator = denominator;
            this.ticks = ticks;
            if (doted) this.PlaceDot();
        }

        public Duration(int numerator, int denominator, int tripletnum, int tripletdenom, bool doted, int ticks)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.onumerator = numerator;
            this.odenominator = denominator;
            this.ticks = ticks;
            this.PlaceTriplet(tripletnum, tripletdenom);
            if (doted) this.PlaceDot();
        }

        /// <summary>
        /// значение доли в десятичной дроби
        /// </summary>
        public double Value
        {
            get { return (double) numerator/denominator; }
        }

        /// <summary>
        ///  значение ОРИГИНАЛЬНОЙ доли в десятичной дроби
        /// </summary>
        public double OriginalValue
        {
            get { return (double) onumerator/odenominator; }
        }
        
        public Duration AddDuration(Duration duration)
        {
            int newnum = 0;
            int newdenom = 0;

            newnum = (this.numerator*duration.denominator) + (duration.numerator*this.denominator);
            newdenom = this.denominator*duration.denominator;

            for (int i = 2; i <= newnum; i++)
            {
                if (newnum%i == 0) // если числитель делится на i
                {
                    if ((newdenom%i == 0)) // и знаменатель делится на i (на случай триоли например)
                    {
                        newnum = newnum/i;
                        newdenom = newdenom/i;
                        i = i - 1; // находим оставшиешся множители (могут входить в множимое по несколько раз)
                    }
                }
            }

            //--cокращение получившейся дроби--
            while (newdenom > 2) // пока знаменатель больше 2
            {
                if (newnum%2 == 0) // если числитель делится на 2
                {
                    if ((newdenom%2 == 0)) // и знаменатель делится на 2 (на случай триоли например)
                    {
                        // сокращаем на 2 дробь
                        newnum = newnum/2;
                        newdenom = newdenom/2;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Duration Temp = new Duration(newnum, newdenom, false, (this.Ticks + duration.Ticks));

            // добавляет длительность навсегда к объекту которого метод вызывали
           // this.numerator = newnum; // числитель в дроби доли
           // this.denominator = newdenom; // знаменатель в дроби доли
            return Temp;
            /*
             this.numerator = newnum;
             this.denominator = newdenom;
             this.ticks = this.Ticks + duration.Ticks;
            */
        }
        
        /// <summary>
        ///  остаток от вычитания длительности из текущей
        /// </summary>
        public Duration SubDuration(Duration duration)
        {
        	Duration temp = (Duration) duration.Clone();
        	temp.ticks = -temp.ticks;
        	return this.AddDuration(temp);
        }

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

        private void PlaceDot()
        {
            if ((this.numerator%2) == 0)
            {
                this.numerator = (int) (this.numerator*1.5); // если четный числитель, то прибавляем к нему половину
            }
            else
            {
                this.numerator = this.numerator*3;
                this.denominator = this.denominator*2;
            }
        }

        private void PlaceTriplet(int triplnum, int tripldenom)
        {
            this.numerator = this.numerator*triplnum;
            this.denominator = this.denominator*tripldenom;
        }

        #endregion

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary>
        private Duration()
        {
              
        }

        public IBaseObject Clone()
        {
            Duration Temp = new Duration(this.numerator, this.denominator, false, this.ticks);
            Temp.onumerator = this.onumerator;
            Temp.odenominator = this.odenominator;
            return Temp;
        }

        public bool Equals(object obj)
        {
            if (Math.Abs(this.Value - ((Duration) obj).Value) < 0.000001)
            {
                // если модул разности двух double меньше заданной точности то можно считать что эти double равны
                return true;
            }
            return false;
        }

        #endregion
    }
}
