namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

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
        public readonly List<Pitch> Pitch = new List<Pitch>();

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
        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority = -1)
        {
            // если не пауза то записываем высоту и наличие лиги
            if (pitch != null)
            {
                Pitch.Add((Pitch)pitch.Clone());
                Tie = tie;
            }
            else
            {
                // если нота - пауза, то не может быть лиги на паузу
                Tie = Tie.None;
            }

            Duration = (Duration)duration.Clone();
            Triplet = triplet;

            // приоритет если указан
            Priority = priority;
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
        public ValueNote(List<Pitch> pitchList, Duration duration, bool triplet, Tie tie, int priority = -1) : this((Pitch)null, duration, triplet, tie, priority)
        {
            if (pitchList.Count > 0)
            {
                Pitch.AddRange(pitchList);
                Tie = tie;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNote"/> class.
        /// </summary>
        /// <param name="midiNumbers">
        /// The midi numbers.
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
        public ValueNote(List<int> midiNumbers, Duration duration, bool triplet, Tie tie, int priority = -1)
        {
            foreach (int midiNumber in midiNumbers)
            {
                Pitch.Add(new Pitch(midiNumber));
            }

            Tie = tie;
            Duration = (Duration)duration.Clone();
            Triplet = triplet;
            Priority = priority;
        }

        /// <summary>
        /// Gets or sets the id of note.
        /// </summary>
        public int Id { get; set; }

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
                throw new ArgumentNullException("pitch");
            }

            Pitch.Add(pitch);
        }

        /// <summary>
        /// The add pitch.
        /// </summary>
        /// <param name="pitch">
        /// The pitch.
        /// </param>
        public void AddPitch(List<Pitch> pitch)
        {
            Pitch.AddRange(pitch);
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
            if (Pitch.Count != pitchList.Count)
            {
                return false;
            }

            for (int i = 0; i < pitchList.Count; i++)
            {
                if (!Pitch[i].Equals(pitchList[i]))
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
            return new ValueNote(Pitch, Duration, Triplet, Tie, Priority);
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
            if (!(obj is ValueNote note))
            {
                return false;
            }

            // одна нота - пауза
            if (Pitch == null || Pitch.Count == 0)
            {
                // другая нота - пауза
                if (note.Pitch == null || note.Pitch.Count == 0)
                {
                    // у пауз сравниваем только их длительности
                    return Duration.Equals(note.Duration);
                }

                // пауза и нота не одинаковы
                return false;
            }

            if (note.Pitch == null || note.Pitch.Count == 0)
            {
                // нота и пауза не одно и то же
                return false;
            }

            return Duration.Equals(note.Duration) && PitchEquals(note.Pitch) && (Tie == note.Tie) && (Triplet == note.Triplet);

            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например,
            // TODO: из сравнения исключить триплет, так можно различать одинаковые по длительности ноты, но записанные по разному(!)
        }

        /// <summary>
        /// Calculates MD5 hash code using
        /// pitches, duration, Tie and Triplet.
        /// </summary>
        /// <returns>
        /// The <see cref="T:byte[]"/>.
        /// </returns>
        public byte[] GetMD5HashCode()
        {
            var hash = new List<byte>();
            foreach (Pitch pitch in Pitch)
            {
                hash.AddRange(pitch.GetMD5HashCode());
            }

            hash.AddRange(Duration.GetMD5HashCode());
            hash.Add((byte)Tie);
            hash.Add(Convert.ToByte(Triplet));
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(hash.ToArray());
        }

        /// <summary>
        /// Calculates hash code using
        /// <see cref="Triplet"/>, <see cref="Pitch"/>,
        /// <see cref="Duration"/> and <see cref="Tie"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -2024996526;
                hashCode = (hashCode * -1521134295) + Triplet.GetHashCode();
                hashCode = (hashCode * -1521134295) + ((byte)Tie).GetHashCode();
                hashCode = (hashCode * -1521134295) + Duration.GetHashCode();
                foreach (Pitch pitch in Pitch)
                {
                    hashCode = (hashCode * -1521134295) + pitch.GetHashCode();
                }

                return hashCode;
            }

        }
    }
}
