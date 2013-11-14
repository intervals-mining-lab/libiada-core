using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class Note : IBaseObject // нота
    {
        private bool triplet; // наличие триоли
        private int tie; // есть ли лига (-1 : нет; 0 - начало; 1 - конец)
        private List<Pitch> pitch; // высота ноты
        private Duration duration; // длительность ноты
        private int priority; // сильная/слабая доля - приоритет доли
        private int id; // id ноты для составления строя нот

        public Note(Pitch pitch, Duration duration, bool triplet, int tie)
        {
            this.pitch = new List<Pitch>();
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch.Add(pitch);
                this.tie = tie;
            }
            else
            {
                this.tie = -1; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = -1; // приоритет не определен
        }

        public Note(Pitch pitch, Duration duration, bool triplet, int tie, int priority)
        {
            this.pitch = new List<Pitch>();
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch.Add(pitch);
                this.tie = tie;
            }
            else
            {
                this.tie = -1; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
        }

        public Note(List<Pitch> pitch, Duration duration, bool triplet, int tie, int priority)
        {
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = new List<Pitch>(pitch);
                this.tie = tie;
            }
            else
            {
                this.tie = -1; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration)duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
        }

        public void AddPitch(Pitch pitch)
        {
            this.pitch.Add(pitch);
        }
        public void AddPitch(List<Pitch> pitchlist)
        {
            foreach (Pitch pitch in pitchlist) this.pitch.Add(pitch);
        }
        public List<Note> SplitNote(int ticks)
        {
            List<Note> Temp = new List<Note>();
            Temp.Add((Note)this.Clone());
            Temp.Add((Note)this.Clone());
            /*Temp[0] = (Note)this.Clone();
            Temp[1] = (Note)this.Clone();*/
            Temp[0].Duration.Ticks = ticks;
            Temp[1].Duration.Ticks = this.Duration.Ticks - ticks;
            return Temp;
        }
        public List<Note> SplitNote(Duration duration)
        {
            int ticks = duration.Ticks;
            return SplitNote(ticks);
            /*List<Note> Temp = new List<Note>(2);
            Temp[0] = (Note)this.Clone();
            Temp[1] = (Note)this.Clone();
            Temp[0].Duration.Ticks = ticks;
            Temp[1].Duration.Ticks = this.Duration.Ticks - ticks;
            return Temp;*/
        }

        public int Id
        {
            set
            {
                this.id = value;
            }
            get
            {
                return id;
            }
        }

        public bool Triplet
        {
            get
            {
                return triplet;
            }
        }

        public int Tie
        {
            get
            {
                return tie;
            }
        }

        public List<Pitch> Pitch
        {
            get
            {
                return pitch;
            }
        }

        public Duration Duration
        {
            get
            {
                return duration;
            }
        }

        public int Priority
        {
            set
            {
                this.priority = value;
            }
            get
            {
                return priority;
            }
        }

        #region IBaseMethods

        private Note()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Note Temp = new Note(this.pitch, this.duration, this.triplet, this.tie, this.priority);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.Pitch == null)
            {
                if (((Note)obj).Pitch == null)
                {
                    if (this.Duration.Equals(((Note)obj).Duration))
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
                if (((Note)obj).Pitch == null)
                {
                    // нота и пауза не одно и то же
                    return false;
                }
            }

            bool pitchEquals = true;

            if (this.pitch.Count != ((Note)obj).Pitch.Count)
            {
                pitchEquals = false;
            }
            else
            {
                for (int i=0; i<this.pitch.Count;i++)
                {
                    if (!this.pitch[i].Equals(((Note)obj).pitch[i]))
                    {
                        pitchEquals = false;
                    }
                }
            }

            if ((this.Duration.Equals(((Note)obj).Duration)) && pitchEquals && (this.Tie == ((Note)obj).Tie) && (this.Triplet == ((Note)obj).Triplet))
            {
                return true;
            }
            return false;
            // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например, 
            // TODO: из сравнения исключить триплет, так может различать одинаковые по длительности ноты, но записанные по разному(!)
        }

        public IBin GetBin()
        {
            NoteBin Temp = new NoteBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class NoteBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Note();
            }
        }

        #endregion
    }
}
