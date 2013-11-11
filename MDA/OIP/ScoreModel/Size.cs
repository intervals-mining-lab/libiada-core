using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class Size: IBaseObject // размер в такте
    {
        // size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
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
            get {
                    if (ticksperbeat != -1) return ticksperbeat;
                    else throw new Exception("MDA: Error getting not defined TicksPerBeat property!");
                }
        }

        #region IBaseMethods

        private Size()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Size Temp = new Size(this.beats, this.beatbase, ticksperbeat);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if ((this.Beats == ((Size)obj).Beats) && (this.Beatbase == ((Size)obj).Beatbase) && (this.Ticksperbeat == ((Size)obj).Ticksperbeat))
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            SizeBin Temp = new SizeBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class SizeBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Size();
            }
        }

        #endregion

    }
}
