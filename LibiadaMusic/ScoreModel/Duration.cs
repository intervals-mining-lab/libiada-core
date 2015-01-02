namespace LibiadaMusic.ScoreModel
{
    using System;

    using LibiadaCore.Core;

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
        /// Initializes a new instance of the <see cref="Duration"/> class.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <param name="denominator">
        /// The denominator.
        /// </param>
        /// <param name="doted">
        /// The doted.
        /// </param>
        /// <param name="ticks">
        /// The ticks.
        /// </param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Duration"/> class.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <param name="denominator">
        /// The denominator.
        /// </param>
        /// <param name="tripletnum">
        /// The tripletnum.
        /// </param>
        /// <param name="tripletdenom">
        /// The tripletdenom.
        /// </param>
        /// <param name="doted">
        /// The doted.
        /// </param>
        /// <param name="ticks">
        /// The ticks.
        /// </param>
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

        /// <summary>
        /// The add duration.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="Duration"/>.
        /// </returns>
        public Duration AddDuration(Duration duration)
        {
            int newnum = (Numerator * duration.Denominator) + (duration.Numerator * Denominator);
            int newdenom = Denominator * duration.Denominator;

            for (int i = 2; i <= newnum; i++)
            {
                // если числитель делится на i
                if (newnum % i == 0) 
                {
                    // и знаменатель делится на i (на случай триоли например)
                    if (newdenom % i == 0) 
                    {
                        // находим оставшиешся множители (могут входить в множимое по несколько раз)
                        newnum /= i;
                        newdenom /= i;
                        i--;
                    }
                }
            }

            //--cокращение получившейся дроби--
            // пока знаменатель больше 2
            while (newdenom > 2)
            {
                // если числитель делится на 2
                if (newnum % 2 == 0) 
                {
                    // и знаменатель делится на 2 (на случай триоли например)
                    if (newdenom % 2 == 0) 
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

            return new Duration(newnum, newdenom, false, Ticks + duration.Ticks);
        }

        /// <summary>
        /// The sub duration.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="Duration"/>.
        /// </returns>
        public Duration SubDuration(Duration duration)
        {
            var temp = (Duration)duration.Clone();
            temp.Ticks = -temp.Ticks;
            temp.Numerator = -temp.Numerator;
            return AddDuration(temp);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var temp = new Duration(Numerator, Denominator, false, Ticks)
            {
                onumerator = onumerator,
                odenominator = odenominator
            };
            return temp;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        /// <summary>
        /// The placedot.
        /// </summary>
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

        /// <summary>
        /// The place triplet.
        /// </summary>
        /// <param name="triplnum">
        /// The triplnum.
        /// </param>
        /// <param name="tripldenom">
        /// The tripldenom.
        /// </param>
        private void PlaceTriplet(int triplnum, int tripldenom)
        {
            Numerator = Numerator * triplnum;
            Denominator = Denominator * tripldenom;
        }
    }
}
