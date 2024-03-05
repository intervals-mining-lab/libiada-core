namespace Libiada.Core.Core.SimpleTypes;

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
    public Duration(int numerator, int denominator, bool doted = false)
    {
        Numerator = numerator;
        Denominator = denominator;
        OriginalNumerator = numerator;
        OriginalDenominator = denominator;
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
    public Duration(int numerator, int denominator, int tripleNumerator, int tripleDenominator, bool doted)
    {
        Numerator = numerator;
        Denominator = denominator;
        OriginalNumerator = numerator;
        OriginalDenominator = denominator;
        PlaceTriplet(tripleNumerator, tripleDenominator);
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
    /// <param name="originalNumerator">
    /// The original numerator.
    /// </param>
    /// <param name="originalDenominator">
    /// The original denominator.
    /// </param>
    public Duration(int numerator, int denominator, int originalNumerator, int originalDenominator) : this(numerator, denominator)
    {
        OriginalNumerator = originalNumerator;
        OriginalDenominator = originalDenominator;
    }

    /// <summary>
    /// Gets original numerator.
    /// Used to preserve original duration.
    /// (для сохранения после наложения триоли на длительность)
    /// </summary>
    public int OriginalNumerator { get; private set; }

    /// <summary>
    /// Gets original denominator.
    /// Used to preserve original duration.
    /// (для сохранения после наложения триоли на длительность)
    /// </summary>
    public int OriginalDenominator { get; private set; }

    /// <summary>
    /// Numerator of the fraction representing duration.
    /// </summary>
    public int Numerator { get; private set; }

    /// <summary>
    /// Denominator of the fraction representing duration.
    /// </summary>
    public int Denominator { get; private set; }

    /// <summary>
    /// Duration as double precision floating pint value.
    /// </summary>
    public double Value => (double)Numerator / Denominator;

    /// <summary>
    /// Gets original duration value.
    /// </summary>
    public double OriginalValue => (double)OriginalNumerator / OriginalDenominator;

    /// <summary>
    /// Adds given duration to current duration.
    /// </summary>
    /// <param name="duration">
    /// Duration to add.
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
        // while denominator greater than 2
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

        return new Duration(newNumerator, newDenominator, false);
    }

    /// <summary>
    /// Subtracts given duration from current duration.
    /// </summary>
    /// <param name="duration">
    /// Duration to subtract.
    /// </param>
    /// <returns>
    /// The <see cref="Duration"/>.
    /// </returns>
    public Duration SubtractDuration(Duration duration)
    {
        var temp = (Duration)duration.Clone();
        temp.Numerator = -temp.Numerator;
        return AddDuration(temp);
    }

    /// <summary>
    /// Clones current duration.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone()
    {
        var temp = new Duration(Numerator, Denominator, false)
        {
            OriginalNumerator = OriginalNumerator,
            OriginalDenominator = OriginalDenominator
        };
        return temp;
    }

    /// <summary>
    /// Compares duration values
    /// (not numerator and denominator separately).
    /// If absolute value of durations difference is less than given precision 
    /// they are considered to be equeal.
    /// </summary>
    /// <param name="obj">
    /// Duration to compare to.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is Duration duration && Math.Abs(Value - duration.Value) < 0.000001;
    }

    /// <summary>
    /// Calculates hash code using
    /// <see cref="Numerator"/> and <see cref="Denominator"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode() => ToString().GetHashCode();

    /// <summary>
    /// Represents duration as string
    /// as "Duration: {Numerator}/{Denominator}".
    /// </summary>
    /// <returns>
    /// Duration as <see cref="string"/>
    /// </returns>
    public override string ToString()
    {
        return $"Duration: {Numerator}/{Denominator}";
    }

    /// <summary>
    /// Palces dot.
    /// I.e. extends duration by half.
    /// </summary>
    private void PlaceDot()
    {
        if ((Numerator % 2) == 0)
        {
            // if numerator is even we just increase it by one and a half times
            Numerator = (int)(Numerator * 1.5);
        }
        else
        {
            // otherwise multiply it by 3/2
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
        Numerator *= tripleNumerator;
        Denominator *= tripleDenominator;
    }
}
