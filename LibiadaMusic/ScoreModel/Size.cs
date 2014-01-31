using System;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class Size : IBaseObject // размер в такте
    {
        // size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
        private int beats;
        private int beatbase;
        private int ticksperbeat; // <divisions> TicksPerBeat (per 1/4)

        public Size(int beats, int beatbase)
        {
            this.beats = beats;
            this.beatbase = beatbase;
            ticksperbeat = -1; // не определенно
        }

        public Size(int beats, int beatbase, int ticksperbeat)
        {
            this.beats = beats;
            this.beatbase = beatbase;
            this.ticksperbeat = ticksperbeat;
        }

        public int Beats
        {
            get { return beats; }
        }

        public int Beatbase
        {
            get { return beatbase; }
        }

        public int Ticksperbeat
        {
            get
            {
                if (ticksperbeat != -1) return ticksperbeat;
                else throw new Exception("LibiadaMusic: Error getting not defined TicksPerBeat property!");
            }
        }

        #region IBaseMethods

        public IBaseObject Clone()
        {
            Size Temp = new Size(beats, beatbase, ticksperbeat);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if ((Beats == ((Size) obj).Beats) && (Beatbase == ((Size) obj).Beatbase) &&
                (Ticksperbeat == ((Size) obj).Ticksperbeat))
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
