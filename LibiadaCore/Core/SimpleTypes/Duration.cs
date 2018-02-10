﻿namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Note duration
    /// </summary>
    public class Duration : IBaseObject
    {
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
            Onumerator = numerator;
            Odenominator = denominator;
            Ticks = ticks;
            if (doted)
            {
                PlaceDot();
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
        /// <param name="tripleNumerator">
        /// The triple numerator.
        /// </param>
        /// <param name="tripleDenominator">
        /// The triple denominator.
        /// </param>
        /// <param name="doted">
        /// The doted.
        /// </param>
        /// <param name="ticks">
        /// The ticks.
        /// </param>
        public Duration(int numerator, int denominator, int tripleNumerator, int tripleDenominator, bool doted, int ticks)
        {
            Numerator = numerator;
            Denominator = denominator;
            Onumerator = numerator;
            Odenominator = denominator;
            Ticks = ticks;
            PlaceTriplet(tripleNumerator, tripleDenominator);
            if (doted)
            {
                PlaceDot();
            }
        }

        /// <summary>
        /// Gets original numerator.
        /// оригинальный числитель в дроби доли
        /// (для сохранения после наложения триоли на длительность)
        /// </summary>
        public int Onumerator { get; private set; }

        /// <summary>
        /// Gets original denominator.
        /// оригинальный знаменатель в дроби доли
        /// (для сохранения после наложения триоли на длительность)
        /// </summary>
        public int Odenominator { get; private set; }

        /// <summary>
        /// Gets numerator.
        /// числитель в дроби доли
        /// </summary>
        public int Numerator { get; private set; }

        /// <summary>
        /// Gets denominator.
        /// знаменатель в дроби доли
        /// </summary>
        public int Denominator { get; private set; }

        /// <summary>
        /// Gets number of midi tiks.
        /// сколько МИДИ тиков в доле
        /// </summary>
        public int Ticks { get; private set; }

        /// <summary>
        /// Gets duration value.
        ///  значение доли в десятичной дроби
        /// </summary>
        public double Value
        {
            get { return (double)Numerator / Denominator; }
        }

        /// <summary>
        /// Gets original duration value.
        /// значение ОРИГИНАЛЬНОЙ доли в десятичной дроби
        /// </summary>
        public double OriginalValue
        {
            get { return (double)Onumerator / Odenominator; }
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

            //TODO: проверить избыточность одного из циклов

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
        public Duration SubtractDuration(Duration duration)
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
                Onumerator = Onumerator,
                Odenominator = Odenominator
            };
            return temp;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
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
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="T:byte[]"/>.
        /// </returns>
        public new byte[] GetHashCode()
        {
            var md5 = MD5.Create();
            return md5.ComputeHash(BitConverter.GetBytes(Value));
        }

        /// <summary>
        /// The place dot.
        /// </summary>
        private void PlaceDot()
        {
            if ((Numerator % 2) == 0)
            {
                // если четный числитель, то прибавляем к нему половину
                Numerator = (int)(Numerator * 1.5);
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
        /// <param name="tripleNumerator">
        /// The triple numerator.
        /// </param>
        /// <param name="tripleDenominator">
        /// The triple denominator.
        /// </param>
        private void PlaceTriplet(int tripleNumerator, int tripleDenominator)
        {
            Numerator = Numerator * tripleNumerator;
            Denominator = Denominator * tripleDenominator;
        }
    }
}