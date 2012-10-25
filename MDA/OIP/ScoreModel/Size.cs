using System;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// размер в такте
    /// 
    /// size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
    /// </summary>
    public class Size : IBaseObject
    {
        private int beats;
        private int beatbase;
        private int ticksperbeat; // <divisions> TicksPerBeat (per 1/4)

        public Size(int beats, int beatbase)
        {
            this.beats = beats;
            this.beatbase = beatbase;
            this.ticksperbeat = -1; // не определенно
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
                else throw new Exception("MDA: Error getting not defined TicksPerBeat property!");
            }
        }

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary> 
        private Size()
        {
             
        }

        public IBaseObject Clone()
        {
            Size Temp = new Size(this.beats, this.beatbase, ticksperbeat);
            return Temp;
        }

        public bool Equals(object obj)
        {
            if ((this.Beats == ((Size) obj).Beats) && (this.Beatbase == ((Size) obj).Beatbase) &&
                (this.Ticksperbeat == ((Size) obj).Ticksperbeat))
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
