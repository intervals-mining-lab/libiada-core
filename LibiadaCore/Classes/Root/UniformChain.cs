using System;
using System.Collections;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Statistics;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class UniformChain : ChainWithCharacteristic, IBaseObject
    {
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
                TempunifromChain.IntervalsChanged = IntervalsChanged;

                TempunifromChain.CharacteristicSnapshot = (Hashtable) CharacteristicSnapshot.Clone();
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
        }

        private FrequencyList GetFrequancyIntervalList(int number)
        {
            if (number == -1)
            {
                return startinterval;
            }
            if (number == Length)
            {
                return endinterval;
            }
            return pIntervals;
        }

        protected override void BuildIntervals()
        {
            if (!IntervalsChanged) return;

            IntervalsChanged = false;

            pIntervals = new FrequencyList();
            int next = -1;
            FrequencyList IntervalList;
            do
            {
                int current = next;
                next = Right(current);
                if (next == Length)
                {
                    IntervalList = GetFrequancyIntervalList(Length);
                }
                else
                {
                    IntervalList = GetFrequancyIntervalList(current);
                }

                IntervalList.Add((ValueInt) (next - current));
            } while (next != Length);
        }

        public override double InjectIntoCharacteristic(Type type, LinkUp Link)
        {
            return ((Characteristic) CharacteristicSnapshot[type]).Value(this, Link);
        }

    }
}