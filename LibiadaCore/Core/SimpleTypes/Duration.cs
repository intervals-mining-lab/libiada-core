namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Note duration.
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
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
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
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
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
        public int OriginalNumerator { get; private set; }

        /// <summary>
        /// Gets original denominator.
        /// оригинальный знаменатель в дроби доли
        /// (для сохранения после наложения триоли на длительность)
        /// </summary>
        public int OriginalDenominator { get; private set; }

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
        public double Value => (double)Numerator / Denominator;

        /// <summary>
        /// Gets original duration value.
        /// значение ОРИГИНАЛЬНОЙ доли в десятичной дроби
        /// </summary>
        public double OriginalValue => (double)OriginalNumerator / OriginalDenominator;

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
            int newNumerator = (Numerator * duration.Denominator) + (duration.Numerator * Denominator);
            int newDenominator = Denominator * duration.Denominator;

            //TODO: проверить избыточность одного из циклов

            for (int i = 2; i <= newNumerator; i++)
            {
                // если числитель делится на i
                if (newNumerator % i == 0)
                {
                    // и знаменатель делится на i (на случай триоли например)
                    if (newDenominator % i == 0)
                    {
                        // находим оставшиешся множители (могут входить в множимое по несколько раз)
                        newNumerator /= i;
                        newDenominator /= i;
                        i--;
                    }
                }
            }

            //--cокращение получившейся дроби--
            // пока знаменатель больше 2
            while (newDenominator > 2)
            {
                // если числитель делится на 2
                if (newNumerator % 2 == 0)
                {
                    // и знаменатель делится на 2 (на случай триоли например)
                    if (newDenominator % 2 == 0)
                    {
                        // сокращаем на 2 дробь
                        newNumerator /= 2;
                        newDenominator /= 2;
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

            return new Duration(newNumerator, newDenominator, false, Ticks + duration.Ticks);
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
                OriginalNumerator = OriginalNumerator,
                OriginalDenominator = OriginalDenominator
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
        /// calculates MD5 hash code using
        /// <see cref="Value"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:byte[]"/>.
        /// </returns>
        public byte[] GetMD5HashCode()
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(BitConverter.GetBytes(Value));
        }

        /// <summary>
        /// Calculates hash code using
        /// <see cref="Numerator"/> and <see cref="Denominator"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1534900553;
                hashCode = (hashCode * -1521134295) + Numerator.GetHashCode();
                hashCode = (hashCode * -1521134295) + Denominator.GetHashCode();
                return hashCode;
            }
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
