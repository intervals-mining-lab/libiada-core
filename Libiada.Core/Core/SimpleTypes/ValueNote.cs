namespace Libiada.Core.Core.SimpleTypes;

using System;
using System.Collections.Generic;

/// <summary>
/// Class presenting a note value.
/// </summary>
public class ValueNote : IBaseObject
{
    /// <summary>
    /// Gets a value indicating whether note has triplet. (наличие триоли)
    /// </summary>
    public readonly bool Triplet;

    /// <summary>
    /// Gets note's pitches.
    /// </summary>
    public readonly List<Pitch> Pitches;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueNote"/> class.
    /// </summary>
    /// <param name="pitch">
    /// The pitch.
    /// </param>
    /// <param name="duration">
    /// The duration.
    /// </param>
    /// <param name="triplet">
    /// The triplet.
    /// </param>
    /// <param name="tie">
    /// The tie.
    /// </param>
    /// <param name="priority">
    /// The priority.
    /// </param>
    public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority = -1) :
        this(pitch == null ? new List<Pitch>() : new List<Pitch>() { pitch }, duration, triplet, tie, priority)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueNote"/> class.
    /// </summary>
    /// <param name="pitchList">
    /// The pitch list.
    /// </param>
    /// <param name="duration">
    /// The duration.
    /// </param>
    /// <param name="triplet">
    /// The triplet.
    /// </param>
    /// <param name="tie">
    /// The tie.
    /// </param>
    /// <param name="priority">
    /// The priority.
    /// </param>
    public ValueNote(IReadOnlyList<Pitch> pitchList, Duration duration, bool triplet, Tie tie, int priority = -1)
    {
        Pitches = pitchList == null ? new List<Pitch>() : new List<Pitch>(pitchList);

        // если не пауза то записываем высоту и наличие лиги
        if (Pitches.Count > 0)
        {
            Tie = tie;
        }
        else
        {
            // если нота - пауза, то не может быть лиги на паузу
            Tie = Tie.None;
        }

        Duration = (Duration)duration.Clone();
        Triplet = triplet;

        Priority = priority;
    }

    /// <summary>
    /// Gets or sets the id of note.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets note duration.
    /// </summary>
    public Duration Duration { get; private set; }

    /// <summary>
    /// Gets or sets priority. (сильная/слабая доля - приоритет доли)
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Gets or sets tie. (есть ли лига)
    /// </summary>
    public Tie Tie { get; set; }

    /// <summary>
    /// The split note.
    /// </summary>
    /// <param name="duration">
    /// The duration.
    /// </param>
    /// <returns>
    /// The <see cref="List{ValueNote}"/>.
    /// </returns>
    public List<ValueNote> SplitNote(Duration duration)
    {
        var clone = new List<ValueNote>(0) { (ValueNote)Clone(), (ValueNote)Clone() };
        clone[0].Duration = duration;
        clone[1].Duration = Duration.SubtractDuration(duration);
        return clone;
    }

    /// <summary>
    /// The add pitch.
    /// </summary>
    /// <param name="pitch">
    /// The pitch.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if pitch is null.
    /// </exception>
    public void AddPitch(Pitch pitch)
    {
        if (pitch == null)
        {
            throw new ArgumentNullException(nameof(pitch));
        }

        Pitches.Add(pitch);
    }

    /// <summary>
    /// The add pitch.
    /// </summary>
    /// <param name="pitch">
    /// The pitch.
    /// </param>
    public void AddPitch(List<Pitch> pitch)
    {
        if (pitch == null)
        {
            throw new ArgumentNullException(nameof(pitch));
        }

        Pitches.AddRange(pitch);
    }

    /// <summary>
    /// The pitch equals.
    /// </summary>
    /// <param name="pitchList">
    /// The pitch list.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool PitchEquals(List<Pitch> pitchList)
    {
        if (Pitches.Count != pitchList.Count)
        {
            return false;
        }

        for (int i = 0; i < pitchList.Count; i++)
        {
            if (!Pitches[i].Equals(pitchList[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone()
    {
        return new ValueNote(Pitches, Duration, Triplet, Tie, Priority);
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
        if (!(obj is ValueNote otherNote))
        {
            return false;
        }

        // одна нота - пауза
        if (Pitches == null || Pitches.Count == 0)
        {
            // другая нота - пауза
            if (otherNote.Pitches == null || otherNote.Pitches.Count == 0)
            {
                // у пауз сравниваем только их длительности
                return Duration.Equals(otherNote.Duration);
            }

            // пауза и нота не одинаковы
            return false;
        }

        if (otherNote.Pitches == null || otherNote.Pitches.Count == 0)
        {
            // нота и пауза не одно и то же
            return false;
        }

        return Duration.Equals(otherNote.Duration) && PitchEquals(otherNote.Pitches) && (Tie == otherNote.Tie) && (Triplet == otherNote.Triplet);

        // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например,
        // TODO: из сравнения исключить триплет, так можно различать одинаковые по длительности ноты, но записанные по разному(!)
    }

    /// <summary>
    /// Calculates hash code using
    /// string representation of th note, based on
    /// <see cref="Triplet"/>, <see cref="Pitches"/>,
    /// <see cref="Duration"/> and <see cref="Tie"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode() => ToString().GetHashCode();

    /// <summary>
    /// Represents note as string using params
    /// <see cref="Triplet"/>, <see cref="Pitches"/>,
    /// <see cref="Duration"/> and <see cref="Tie"/>.
    /// </summary>
    /// <returns>
    /// Note as <see cref="string"/>
    /// </returns>
    public override string ToString()
    {
        var result = new List<string>(10);
        result.Add(Duration.ToString());
        result.Add("MidiNumbers:");
        for (int i = 0; i < Pitches.Count; i++)
        {
            result.Add(Pitches[i].ToString());
        }

        result.Add($"Tie: {Tie}");

        if (Triplet)
        {
            result.Add("Triplet");
        }

        return string.Join(" ", result);
    }
}
