using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    /// <summary>
    /// нота
    /// </summary>
    public class ValueNote : IBaseObject 
    {
        /// <summary>
        /// id ноты для составления строя нот
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// наличие триоли
        /// </summary>
        public bool Triplet { get; private set; }

        /// <summary>
        /// высота ноты
        /// </summary>
        public List<Pitch> Pitch { get; private set; }

        /// <summary>
        /// длительность ноты
        /// </summary>
        public Duration Duration { get; private set; }

        /// <summary>
        /// сильная/слабая доля - приоритет доли
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// есть ли лига (-1 : нет; 0 - начало; 1 - конец)
        /// </summary>
        public Tie Tie { get; set; }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority)
        {
            Pitch = new List<Pitch>(0);
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                Pitch.Add((Pitch) pitch.Clone());
                Tie = tie;
            }
            else
            {
                Tie = Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            Duration = (Duration) duration.Clone();
            Triplet = triplet;
            Priority = priority; // приоритет если указан
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie)
            : this(pitch, duration, triplet, tie, -1)
        {
        }

        public ValueNote(List<Pitch> pitchList, Duration duration, bool triplet, Tie tie, int priority = -1)
            : this((Pitch) null, duration, triplet, tie, priority)
        {
            if (pitchList.Count > 0)
            {
                Pitch.AddRange(pitchList);
                Tie = tie;
            }
        }

        public List<ValueNote> SplitNote(Duration duration)
        {
            var clone = new List<ValueNote>(0) {(ValueNote) Clone(), (ValueNote) Clone()};
            clone[0].Duration = duration;
            clone[1].Duration = Duration.SubDuration(duration);
            return clone;
        }

        public void AddPitch(Pitch pitch)
        {
            if (pitch == null)
            {
                throw new ArgumentNullException("pitch");
            }
            Pitch.Add(pitch);
        }

        public void AddPitch(List<Pitch> pitch)
        {
            Pitch.AddRange(pitch);
        }

        public void SetInstrument(int instrument)
        {
            foreach (Pitch p in Pitch)
            {
                p.Instrument = instrument;
            }
        }

        public bool PitchEquals(List<Pitch> pitchList)
        {
            if (Pitch.Count != pitchList.Count)
            {
                return false;
            }
            for (int i = 0; i < pitchList.Count; i++)
                if (!Pitch[i].Equals(pitchList[i]))
                {
                    return false;
                }
            return true;
        }

        public IBaseObject Clone()
        {
            return new ValueNote(Pitch, Duration, Triplet, Tie, Priority);
        }

        public override bool Equals(object obj)
        {
            if (Pitch == null || Pitch.Count == 0) // одна нота - пауза
            {
                if (((ValueNote) obj).Pitch == null || ((ValueNote) obj).Pitch.Count == 0) // другая нота - пауза
                {
                    if (Duration.Equals(((ValueNote) obj).Duration))
                    {
                        // одинаковые по длине паузы
                        return true;
                    }
                    // разные по длине паузы
                    return false;
                }
                // пауза и нота не одинаковы
                return false;
            }
            if (((ValueNote) obj).Pitch == null || ((ValueNote) obj).Pitch.Count == 0)
            {
                // нота и пауза не одно и то же
                return false;
            }

            if ((Duration.Equals(((ValueNote) obj).Duration)) && (PitchEquals(((ValueNote) obj).Pitch)) &&
                (Tie == ((ValueNote) obj).Tie) && (Triplet == ((ValueNote) obj).Triplet))
            {
                return true;
            }
            return false;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }
    }
}
