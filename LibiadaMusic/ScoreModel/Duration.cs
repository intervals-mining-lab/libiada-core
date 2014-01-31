using System;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class Duration : IBaseObject // длительности ноты
    {
        private int numerator; // числитель в дроби доли
        private int denominator; // знаменатель в дроби доли
        private int ticks; // сколько МИДИ тиков в доле

        private int onumerator; // оригинальный числитель в дроби доли (для сохранения после наложения триоли на длительность)
        private int odenominator; // оригинальный знаменатель в дроби доли(для сохранения после наложения триоли на длительность)


        public Duration(int numerator, int denominator, bool doted, int ticks) 
        {
            this.numerator = numerator;
            this.denominator = denominator;
            onumerator = numerator;
            odenominator = denominator;
            this.ticks = ticks;
            if (doted) placedot();
        }
        public Duration(int numerator, int denominator, int tripletnum, int tripletdenom, bool doted,int ticks)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            onumerator = numerator;
            odenominator = denominator;
            this.ticks = ticks;
            placetriplet(tripletnum, tripletdenom);
            if (doted) placedot();
        }
        
        public double Value
        {
            get {
                    double val;
                    val = numerator;
                    val = val / denominator;
                    return val; 
                }
        } // значение доли в десятичной дроби
        public double oValue
        {
            get
            {
                double val;
                val = onumerator;
                val = val / odenominator;
                return val;
            }
        } // значение ОРИГИНАЛЬНОЙ доли в десятичной дроби
        public Duration AddDuration(Duration duration) 
        {
            int newnum = 0;
            int newdenom = 0;

            newnum = (numerator*duration.denominator) + (duration.numerator*denominator);
            newdenom = denominator * duration.denominator;

            for (int i = 2; i <= newnum; i++)
            {
                if (newnum % i == 0) // если числитель делится на i
                {
                    if ((newdenom % i == 0)) // и знаменатель делится на i (на случай триоли например)
                    {
                        newnum = newnum / i;
                        newdenom = newdenom / i;
                        i = i-1; // находим оставшиешся множители (могут входить в множимое по несколько раз)
                    }
                }
            }

            //--cокращение получившейся дроби--
            while (newdenom > 2) // пока знаменатель больше 2
            {
                if (newnum % 2 == 0) // если числитель делится на 2
                    {
                        if ((newdenom % 2 == 0)) // и знаменатель делится на 2 (на случай триоли например)
                        {
                            // сокращаем на 2 дробь
                            newnum = newnum / 2;
                            newdenom = newdenom / 2;
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
            //-------------------------------
            Duration Temp = new Duration(newnum, newdenom, false, (Ticks + duration.Ticks));
            return Temp;  
            /*
             this.numerator = newnum;
             this.denominator = newdenom;
             this.ticks = this.Ticks + duration.Ticks;
            */
        }

        public Duration SubDuration(Duration duration)
        {
            Duration temp = (Duration) duration.Clone();
            temp.ticks = -temp.ticks;
            temp.numerator = -temp.numerator;
            return AddDuration(temp);
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
        private void placedot() 
        {
            if ((numerator % 2) == 0)
            {
                numerator = (int)(numerator * 1.5);// если четный числитель, то прибавляем к нему половину
            }
            else 
            {
                numerator = numerator * 3;
                denominator = denominator * 2;
            }
        }
        private void placetriplet(int triplnum, int tripldenom)
        {
            numerator = numerator * triplnum;
            denominator = denominator * tripldenom;
        }
        #endregion

        #region IBaseMethods

        public IBaseObject Clone()
        {
            Duration Temp = new Duration(numerator, denominator, false, ticks);
            Temp.onumerator = onumerator;
            Temp.odenominator = odenominator;
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (Math.Abs(Value - ((Duration)obj).Value)<0.000001)
            {
                // если модул разности двух double меньше заданной точности то можно считать что эти double равны
                return true;
            }
            return false;
        }

        #endregion
    }
}
