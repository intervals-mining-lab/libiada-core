using LibiadaCore.Classes.Root;
using System.Collections.Generic;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// нота
    /// </summary>
    public class ValueNote : IBaseObject
    {
        /// <summary>
        /// наличие триоли
        /// </summary>
        private bool triplet;
        /// <summary>
        /// есть ли лига (-1 : нет; 0 - начало; 1 - конец)
        /// </summary>
        private int tie;
        /// <summary>
        /// высота ноты
        /// </summary>
        private List<Pitch> pitch;
        /// <summary>
        /// длительность ноты
        /// </summary>
        private Duration duration;
        /// <summary>
        /// сильная/слабая доля - приоритет доли
        /// </summary>
        private int priority;
        /// <summary>
        /// id ноты для составления строя нот
        /// </summary>
        private int id;


        public ValueNote(Pitch pitch, Duration duration, bool triplet, int tie, int priority)
        {
            this.pitch = new List<Pitch>(0);
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch.Add((Pitch)pitch.Clone());
                this.tie = tie;
            }
            else
            {
                this.tie = (int)ScoreModel.Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, int tie)
            : this(pitch, duration, triplet, tie, -1)
        {
        }
        
        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie)
            : this(pitch, duration, triplet, (int)tie, -1)
        {
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority)
            : this(pitch, duration, triplet, (int)tie, priority)
        {
        }

        public ValueNote(List<Pitch> pitchlist, Duration duration, bool triplet, int tie, int priority)
            : this(null, duration, triplet, tie)
        {
            this.pitch.AddRange(pitchlist);
            this.priority = priority;
        }

        public ValueNote(List<Pitch> pitchlist, Duration duration, bool triplet, Tie tie, int priority)
            : this(pitchlist, duration, triplet, (int)tie, priority)
        {
        }
        
        
        public void AddPitch(Pitch pitch)
        {
            this.pitch.Add((Pitch) pitch.Clone());
        }
        
        public void AddPitch(List<Pitch> pitchlist)
        {
            foreach(Pitch pitch in pitchlist) { this.pitch.Add((Pitch) pitch.Clone()); }
        }
        
        public List<ValueNote> SplitNote(Duration duration)
        {
            List<ValueNote> Temp = new List<ValueNote>(2);
            Temp[0] = (ValueNote)this.Clone();
            Temp[1] = (ValueNote)this.Clone();
            Temp[0].Duration = duration;
            Temp[1].Duration = this.Duration.SubDuration(duration);
            return Temp;
        }

        public int Id
        {
            set { this.id = value; }
            get { return id; }
        }

        public bool Triplet
        {
            get { return triplet; }
        }

        public int Tie
        {
            get { return tie; }
        }

        public List<Pitch> Pitch
        {
            get { return pitch; }
        }

        public Duration Duration
        {
            get { return duration; }
            set { this.duration = value; }
        }

        public int Priority
        {
            set { this.priority = value; }
            get { return priority; }
        }

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary>
        private ValueNote()
        {
              
        }

        public IBaseObject Clone()
        {
            ValueNote Temp = new ValueNote(this.pitch, this.duration, this.triplet, this.tie, this.priority);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.Pitch.Count == 0)
            {
                if (((ValueNote) obj).Pitch.Count == 0)
                {
                    if (this.Duration.Equals(((ValueNote) obj).Duration))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // пауза и нота не одинаковы
                    return false;
                }
            }
            else
            {
                if (((ValueNote) obj).Pitch.Count == 0)
                {
                    // нота и пауза не одно и то же
                    return false;
                }
            }

            foreach(Pitch pitch1 in ((ValueNote) obj).pitch)
                foreach(Pitch pitch2 in this.pitch)
                    if (!((this.Duration.Equals(((ValueNote) obj).Duration)) && (pitch1.Equals(pitch2)) &&
                        (this.Tie == ((ValueNote) obj).Tie) && (this.Triplet == ((ValueNote) obj).Triplet)))
                    {
                        return false;
                    }
            return true;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }
        #endregion
    }
}

