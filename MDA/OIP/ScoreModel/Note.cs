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
        private Pitch pitch; // высота ноты
        private Duration duration; // длительность ноты
        private int priority; // сильная/слабая доля - приоритет доли
        private int id; // id ноты для составления строя нот

        public Note(Pitch pitch, Duration duration, bool triplet, int tie) 
        {
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            { 
                this.pitch = (Pitch)pitch.Clone(); 
                this.tie = tie; 
            }
            else
            {
                this.tie = -1; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration) duration.Clone();
            this.triplet = triplet;
            this.priority = -1; // приоритет не определен
        }
        public Note(Pitch pitch, Duration duration, bool triplet, int tie, int priority)
        {

            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch = (Pitch)pitch.Clone();
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
        public Pitch Pitch
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


            if ((this.Duration.Equals(((Note)obj).Duration)) && (this.Pitch.Equals(((Note)obj).Pitch)) && (this.Tie == ((Note)obj).Tie) && (this.Triplet == ((Note)obj).Triplet))
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

