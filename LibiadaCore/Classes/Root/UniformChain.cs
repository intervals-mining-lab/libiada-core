using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Statistics;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class UniformChain : BaseChain, IBaseObject
    {
        protected List<int> intervals = new List<int>();

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        ///<param name="message"></param>
        ///<exception cref="Exception"></exception>
        public UniformChain(int length, IBaseObject message) : base(length)
        {
            alphabet.Add(message);
        }

        ///<summary>
        ///</summary>
        public UniformChain()
        {
        }


        public IBaseObject Clone()
        {
            UniformChain temp = new UniformChain(Length, Message);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(IBaseObject temp)
        {
            UniformChain TempunifromChain = temp as UniformChain;
            base.FillClone(TempunifromChain);
            if (TempunifromChain != null)
            {
                TempunifromChain.BuildIntervals();
            }
        }

        ///<summary>
        ///</summary>
        public IBaseObject Message
        {
            get { return alphabet[1]; }
        }

        protected int Left(int current)
        {
            for (int i = current - 1; i > -1; i--)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<int> Intervals
        {
            get
            {
                return new List<int>(intervals);
            }
        }

        protected int Right(int current)
        {
            for (int i = current + 1; i < Length; i++)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return Length;
        }

        public void Add(IBaseObject item, int index)
        {
            if (Message.Equals(item))
            {
                base.Add(item, index);
            }
            BuildIntervals();
        }

        protected void BuildIntervals()
        {
            intervals = new List<int>();
            int next = -1;
            do
            {
                int current = next;
                next = Right(current);

                intervals.Add(next - current);
            } while (next != Length);
        }

        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            building = RemoveAt(building, index);
            BuildIntervals();
            return element;
        }

        public double GetCharacteristic(LinkUp linkUp, ICharacteristicCalculator calculator)
        {
            return calculator.Calculate(this, linkUp);
        }
    }
}