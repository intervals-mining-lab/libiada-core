﻿using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class Note : IBaseObject // нота
    {
        private bool triplet; // наличие триоли
        private Tie tie; // есть ли лига (-1 : нет; 0 - начало; 1 - конец)
        private List<Pitch> pitch; // высота ноты
        private Duration duration; // длительность ноты
        private int priority; // сильная/слабая доля - приоритет доли
        private int id; // id ноты для составления строя нот


        public Note(Pitch pitch, Duration duration, bool triplet, Tie tie, int priority)
        {
            this.pitch = new List<Pitch>(0);
            if (pitch != null) // если не пауза то записываем высоту и наличие лиги
            {
                this.pitch.Add((Pitch) pitch.Clone());
                this.tie = tie;
            }
            else
            {
                this.tie = Tie.None; // если нота - пауза, то не может быть лиги на паузу
            }
            this.duration = (Duration) duration.Clone();
            this.triplet = triplet;
            this.priority = priority; // приоритет если указан
        }

        public Note(Pitch pitch, Duration duration, bool triplet, Tie tie)
            : this(pitch, duration, triplet, tie, -1)
        {
        }

        public Note(List<Pitch> pitchlist, Duration duration, bool triplet, Tie tie, int priority)
            : this((Pitch) null, duration, triplet, tie, priority)
        {
            if (pitchlist.Count > 0)
            {
                pitch.AddRange(pitchlist);
                this.tie = tie;
            }
        }

        public Note(List<Pitch> pitchlist, Duration duration, bool triplet, Tie tie)
            : this((Pitch) null, duration, triplet, tie, -1)
        {
            if (pitchlist.Count > 0)
            {
                pitch.AddRange(pitchlist);
                this.tie = tie;
            }
        }

        public List<Note> SplitNote(Duration duration)
        {
            List<Note> Temp = new List<Note>(0);
            Temp.Add((Note) Clone());
            Temp.Add((Note) Clone());
            Temp[0].Duration = duration;
            Temp[1].Duration = Duration.SubDuration(duration);
            return Temp;
        }

        public int AddPitch(Pitch pitch)
        {
            this.pitch.Add(pitch);
            return 0;
        }

        public int AddPitch(List<Pitch> pitch)
        {
            this.pitch.AddRange(pitch);
            return 0;
        }

        public int SetInstrument(int instrument)
        {
            foreach (Pitch p in pitch)
                p.Instrument = instrument;
            return 0;
        }

        public bool PitchEquals(List<Pitch> pitchlist)
        {
            if (pitch.Count != pitchlist.Count)
            {
                //throw new Exception("LibiadaMusic: Pitches of tie notes not equal because of count!");
                return false;
            }
            for (int i = 0; i < pitchlist.Count; i++)
                if (!pitch[i].Equals(pitchlist[i]))
                {
                    //throw new Exception("LibiadaMusic: Pitches of tie notes not equal because of pitches!");
                    return false;
                }
            return true;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public bool Triplet
        {
            get { return triplet; }
        }

        public Tie Tie
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
            set { duration = value; }
        }

        public int Priority
        {
            set { priority = value; }
            get { return priority; }
        }

        internal void SetTie(Tie newtie)
        {
            tie = newtie;
        }

        #region IBaseMethods

        public IBaseObject Clone()
        {
            Note Temp = new Note(pitch, duration, triplet, tie, priority);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (pitch == null || pitch.Count == 0) // одна нота - пауза
            {
                if (((Note) obj).Pitch == null || ((Note) obj).Pitch.Count == 0) // другая нота - пауза
                {
                    if (Duration.Equals(((Note) obj).Duration))
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
            if (((Note) obj).Pitch == null || ((Note) obj).Pitch.Count == 0)
            {
                // нота и пауза не одно и то же
                return false;
            }


            if ((Duration.Equals(((Note) obj).Duration)) && (PitchEquals(((Note) obj).Pitch)) &&
                (Tie == ((Note) obj).Tie) && (Triplet == ((Note) obj).Triplet))
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

