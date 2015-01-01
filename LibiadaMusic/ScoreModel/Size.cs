namespace LibiadaMusic.ScoreModel
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// размер в такте
    /// size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
    /// </summary>
    public class Size : IBaseObject
    {
        // size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
        private int ticksPerBeat; // <divisions> TicksPerBeat (per 1/4)

        public int Beats { get; private set; }

        public int BeatBase { get; private set; }

        public Size(int beats, int beatBase)
        {
            Beats = beats;
            BeatBase = beatBase;
            ticksPerBeat = -1; // не определенно
        }

        public Size(int beats, int beatBase, int ticksPerBeat)
        {
            Beats = beats;
            BeatBase = beatBase;
            this.ticksPerBeat = ticksPerBeat;
        }

        public int TicksPerBeat
        {
            get
            {
                if (ticksPerBeat != -1)
                {
                    return ticksPerBeat;
                }

                throw new Exception("LibiadaMusic: Error getting not defined TicksPerBeat property!");
            }
        }

        public IBaseObject Clone()
        {
            return new Size(Beats, BeatBase, ticksPerBeat);
        }

        public override bool Equals(object obj)
        {
            if ((Beats == ((Size)obj).Beats) && (BeatBase == ((Size)obj).BeatBase) &&
                (TicksPerBeat == ((Size)obj).TicksPerBeat))
            {
                return true;
            }

            return false;
        }
    }
}
