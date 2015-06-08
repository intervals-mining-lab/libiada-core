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
        /// <summary>
        /// The ticks per beat.
        /// size is beats/beatbase (ex size = 3/4; beats=3; beatbase=4;)
        /// </summary>
        private int ticksPerBeat; // <divisions> TicksPerBeat (per 1/4)

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="beats">
        /// The beats.
        /// </param>
        /// <param name="beatBase">
        /// The beat base.
        /// </param>
        public Size(int beats, int beatBase)
        {
            Beats = beats;
            BeatBase = beatBase;
            ticksPerBeat = -1; // не определенно
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="beats">
        /// The beats.
        /// </param>
        /// <param name="beatBase">
        /// The beat base.
        /// </param>
        /// <param name="ticksPerBeat">
        /// The ticks per beat.
        /// </param>
        public Size(int beats, int beatBase, int ticksPerBeat)
        {
            Beats = beats;
            BeatBase = beatBase;
            this.ticksPerBeat = ticksPerBeat;
        }

        /// <summary>
        /// Gets the beats.
        /// </summary>
        public int Beats { get; private set; }

        /// <summary>
        /// Gets the beat base.
        /// </summary>
        public int BeatBase { get; private set; }

        /// <summary>
        /// Gets the ticks per beat.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown if ticksPerBeat is -1.
        /// </exception>
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

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new Size(Beats, BeatBase, ticksPerBeat);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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
