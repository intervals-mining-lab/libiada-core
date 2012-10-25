using LibiadaCore.Classes.Root;

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
        private Pitch pitch;
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

        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie)
        {
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = (Pitch)pitch.Clone();
                this.tie = (int)tie;
            }
            else
            {
                this.tie = (int)ScoreModel.Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = -1; // приоритет не определен
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, int tie)
        {
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = (Pitch) pitch.Clone();
                this.tie = tie;
            }
            else
            {
                this.tie = (int)ScoreModel.Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration) duration.Clone();
            this.triplet = triplet;
            this.priority = -1; // приоритет не определен
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority)
        {

            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = (Pitch)pitch.Clone();
                this.tie = (int)tie;
            }
            else
            {
                this.tie = (int)ScoreModel.Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
        }

        public ValueNote(Pitch pitch, Duration duration, bool triplet, int tie, int priority)
        {

            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = (Pitch) pitch.Clone();
                this.tie = tie;
            }
            else
            {
                this.tie = (int)ScoreModel.Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration) duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
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

        public Pitch Pitch
        {
            get { return pitch; }
        }

        public Duration Duration
        {
            get { return duration; }
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
            if (this.Pitch == null)
            {
                if (((ValueNote) obj).Pitch == null)
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
                if (((ValueNote) obj).Pitch == null)
                {
                    // нота и пауза не одно и то же
                    return false;
                }
            }


            if ((this.Duration.Equals(((ValueNote) obj).Duration)) && (this.Pitch.Equals(((ValueNote) obj).Pitch)) &&
                (this.Tie == ((ValueNote) obj).Tie) && (this.Triplet == ((ValueNote) obj).Triplet))
            {
                return true;
            }
            return false;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }
        #endregion
    }
}

