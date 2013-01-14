using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Iterators
{
    /// <summary>
    /// Describes a behavior and a structure of  a simple iterator
    /// </summary>
    public abstract class BaseIterator: IIterator
    {
        /// <summary>
        /// Current cursor cursorPosition
        /// </summary>
        protected int cursorPosition = -1;

        /// <summary>
        /// The number of elements through which the pointer will jump at the next iteration
        /// </summary>
        protected int Step;

        /// <summary>
        /// Length of a word (window of cutting)
        /// </summary>
        protected int WindowLength;

        /// <summary>
        /// Amount of offsets for current sequence
        /// </summary>
        protected int maxShifts;

        /// <summary>
        /// An iterate sequence
        /// </summary>
        protected ComplexChain Chain;

        /// <summary>
        /// The currentCut composed sequence was extracted from a chain
        /// </summary>
        protected List<String> CurrentCut = new List<String>();

        /// <summary>
        /// Initializes a main options of an iterator.
        /// </summary>
        /// <param name="chain">An iterate sequence</param>
        /// <param name="length">Length of a word (window of cutting)</param>
        /// <param name="step">The number of elements through which the pointer will jump at the next iteration</param>
        public BaseIterator(ComplexChain chain, int length, int step)
        {
            Init(chain, length, step);
        }

        private void Init(ComplexChain chain, int windowLength, int step)
        {
            try
            {
                int chainLength = chain.Length;

                if ((chainLength < windowLength) || (windowLength == 0)
                    || ((step < 1) || (step > chainLength)))
                    throw new Exception();
            }
            catch (Exception e)
            {
            }


            this.Chain = (ComplexChain)chain.Clone();
            this.WindowLength = windowLength;
            this.Step = step;
            this.cursorPosition = -step;
            CalculateMaxShifts();
        }

        /// <summary>
        /// Returns maximum number of iterations on this chain
        /// </summary>
        /// <returns>Maximum number of iterations on this chain</returns>
        public int MaxShifts
        {
            get { return maxShifts; }

        }

        /// <summary>
        /// Returns current cursor cursorPosition
        /// </summary>
        /// <returns>Current cursor cursorPosition</returns>
        public int CursorPosition
        {
            get { return cursorPosition; }

        }

        /// <summary>
        /// Returns number of shifts at this moment
        /// </summary>
        /// <returns>number of shifts</returns>
        public int Shifts
        {
            get{return (CursorPosition/Step) + 1;}
            
        }

        /// <summary>
        /// Calculates count of shifts
        /// </summary>
        private void CalculateMaxShifts()
        {
            maxShifts = (Chain.Length - WindowLength)/Step + 1;
        }

        /// <summary>
        /// Moves a pointer to specified cursorPosition
        /// </summary>
        /// <param name="position">a cursorPosition in a chain subject to a cutting window</param>
        /// <returns>true if moving is available, false - otherwise</returns>
        public abstract bool Move(int position);

        public abstract bool HasNext();

        public abstract List<string> Next();

        public abstract void Reset();

        public abstract int Position();

        public abstract List<string> Current();
    }
}