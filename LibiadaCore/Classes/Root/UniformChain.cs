using System;
using System.Collections;
using LibiadaCore.Classes.EventTheory;
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
        ///<param name="Message"></param>
        ///<exception cref="Exception"></exception>
        public UniformChain(int length, IBaseObject Message) : base(length)
        {
            pAlphabet.Add(Message);
        }

        ///<summary>
        ///</summary>
        public UniformChain()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="uchain"></param>
        ///<exception cref="NotImplementedException"></exception>
        public UniformChain(UniformChainBin uchain) : base(uchain)
        {
            if (uchain.Alphabet.Items.Count != 1)
            {
                throw  new Exception("");
            }
        }

        public override IBaseObject Clone()
        {
            UniformChain temp = new UniformChain(Length, Message);
            FillClone(temp);
            return temp;
        }

        protected override void FillClone(IBaseObject temp)
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
            get { return pAlphabet[1]; }
        }

        protected int Left(int current)
        {
            for (int i = current - 1; i > -1; i--)
            {
                if (vault[i] == 1)
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
                if (vault[i] == 1)
                {
                    return i;
                }
            }
            return Length;
        }

        public override void AddItem(IBaseObject value, Place place)
        {
            if (Message.Equals(value))
            {
                base.AddItem(value, place);
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

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public new IBin GetBin()
        {
            UniformChainBin Temp = new UniformChainBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public void FillBin(UniformChainBin Bin)
        {
            base.FillBin(Bin);
            Bin.Message = Message.GetBin();
        }
    }

    ///<summary>
    ///</summary>
    public class UniformChainBin : ChainWithCharacteristicBin, IBin
    {
        public IBin Message = null;

        public new IBaseObject GetInstance()
        {
            return new UniformChain(this);
        }
    }
}