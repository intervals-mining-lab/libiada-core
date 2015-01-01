namespace LibiadaMusic.ScoreModel
{
    using LibiadaCore.Core;

    using System;

    /// <summary>
    /// длительности ноты
    /// </summary>
    public class Duration : IBaseObject
    {
        /// <summary>
        /// оригинальный числитель в дроби доли 
        /// (для сохранения после наложения триоли на длительность)
        /// </summary>
        private int onumerator;

        /// <summary>
        /// оригинальный знаменатель в дроби доли
        /// (для сохранения после наложения триоли на длительность)
        /// </summary>
        private int odenominator;

        /// <summary>
        /// числитель в дроби доли
        /// </summary>
        public int Numerator { get; private set; }

        /// <summary>
        /// знаменатель в дроби доли
        /// </summary>
        public int Denominator { get; private set; }

        /// <summary>
        /// сколько МИДИ тиков в доле
        /// </summary>
        public int Ticks { get; private set; }

        /// <summary>
        ///  значение доли в десятичной дроби
        /// </summary>
        public double Value
        {
            get { return (double)Numerator / Denominator; }
        }

        /// <summary>
        /// значение ОРИГИНАЛЬНОЙ доли в десятичной дроби
        /// </summary>
        public double OriginalValue
        {
            get { return (double)onumerator / odenominator; }
        }

        public Duration(int numerator, int denominator, bool doted, int ticks)
        {
            Numerator = numerator;
            Denominator = denominator;
            onumerator = numerator;
            odenominator = denominator;
            Ticks = ticks;
            if (doted)
            {
                Placedot();
            }
        }

        public Duration(int numerator, int denominator, int tripletnum, int tripletdenom, bool doted, int ticks)
        {
            Numerator = numerator;
            Denominator = denominator;
            onumerator = numerator;
            odenominator = denominator;
            Ticks = ticks;
            PlaceTriplet(tripletnum, tripletdenom);
            if (doted)
            {
                Placedot();
            }
        }

        public Duration AddDuration(Duration duration)
        {
            int newnum = (Numerator * duration.Denominator) + (duration.Numerator * Denominator);
            int newdenom = Denominator * duration.Denominator;

            for (int i = 2; i <= newnum; i++)
            {
                if (newnum % i == 0) // если числитель делится на i
                {
                    if (newdenom % i == 0) // и знаменатель делится на i (на случай триоли например)
                    {
                        newnum /= i;
                        newdenom /= i;
                        i--; // находим оставшиешся множители (могут входить в множимое по несколько раз)
                    }
                }
            }

            //--cокращение получившейся дроби--
            while (newdenom > 2) // пока знаменатель больше 2
            {
                if (newnum % 2 == 0) // если числитель делится на 2
                {
                    if (newdenom % 2 == 0) // и знаменатель делится на 2 (на случай триоли например)
                    {
                        // сокращаем на 2 дробь
                        newnum /= 2;
                        newdenom /= 2;
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

            return new Duration(newnum, newdenom, false, (Ticks + duration.Ticks));
        }

        public Duration SubDuration(Duration duration)
        {
            var temp = (Duration)duration.Clone();
            temp.Ticks = -temp.Ticks;
            temp.Numerator = -temp.Numerator;
            return AddDuration(temp);
        }

        private void Placedot()
        {
            if ((Numerator % 2) == 0)
            {
                Numerator = (int)(Numerator * 1.5); // если четный числитель, то прибавляем к нему половину
            }
            else
            {
                Numerator = Numerator * 3;
                Denominator = Denominator * 2;
            }
        }

        private void PlaceTriplet(int triplnum, int tripldenom)
        {
            Numerator = Numerator * triplnum;
            Denominator = Denominator * tripldenom;
        }

        public IBaseObject Clone()
        {
            var temp = new Duration(Numerator, Denominator, false, Ticks)
            {
                onumerator = onumerator,
                odenominator = odenominator
            };
            return temp;
        }

        public override bool Equals(object obj)
        {
            if (Math.Abs(Value - ((Duration)obj).Value) < 0.000001)
            {
                // если модул разности двух double меньше заданной точности,
                // то можно считать что эти double равны
                return true;
            }

            return false;
        }
    }
}
