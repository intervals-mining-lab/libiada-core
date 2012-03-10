using System;
using System.Collections;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Statistics;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    public abstract class ChainWithCharacteristic : BaseChain, IDataForCalculator, IBaseObject
    {
        protected Hashtable CharacteristicSnapshot = new Hashtable();
        protected FrequencyList endinterval = null;
        protected bool IntervalsChanged = true;
        protected FrequencyList pIntervals = null;
        protected FrequencyList startinterval = null;

        protected ChainWithCharacteristic(int length) : base(length)
        {
            pIntervals = new FrequencyList();
            startinterval = new FrequencyList();
            endinterval = new FrequencyList();
        }

        protected ChainWithCharacteristic(string s) : base(s)
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        public new void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            CharacteristicSnapshot = new Hashtable();
            endinterval = new FrequencyList();
            IntervalsChanged = true;
            pIntervals = new FrequencyList();
            startinterval = new FrequencyList();
        }

        protected ChainWithCharacteristic(ChainWithCharacteristicBin Bin)
            : base(Bin)
        {
                pIntervals = new FrequencyList(Bin.CommonIntervals);
                startinterval = new FrequencyList(Bin.StartIntervals);
                endinterval = new FrequencyList(Bin.EndInterval);

            for (int i = 0; i < Bin.Characteristics.Count; i++)
            {
                ICharacteristicCalculator CL = ((CharacteristicBin)Bin.Characteristics[i]).Type;
                ((CharacteristicBin) Bin.Characteristics[i]).Chain = this;
                CharacteristicSnapshot.Add(CL.GetType(), new Characteristic((CharacteristicBin)Bin.Characteristics[i]));
            }
        }

        ///<summary>
        ///</summary>
        public ChainWithCharacteristic()
        {
            
        }
        ///<summary>
        ///</summary>
        public ArrayList GetCharacteristicList
        {
            get
            {
                ArrayList Temp = new ArrayList(CharacteristicSnapshot.Values);
                return (ArrayList) Temp.Clone();
            }
        }


        FrequencyList IDataForCalculator.CommonIntervals
        {
            get
            {
                BuildIntervals();
                return (FrequencyList) pIntervals.Clone();
            }
        }

        FrequencyList IDataForCalculator.StartInterval
        {
            get
            {
                BuildIntervals();
                return (FrequencyList) startinterval.Clone();
            }
        }

        FrequencyList IDataForCalculator.EndInterval
        {
            get
            {
                BuildIntervals();
                return (FrequencyList) endinterval.Clone();
            }
        }

        protected abstract void BuildIntervals();

        protected override void FillClone(IBaseObject temp)
        {
            ChainWithCharacteristic TempChainWithCharacteristic = temp as ChainWithCharacteristic;
            base.FillClone(TempChainWithCharacteristic);
            if (TempChainWithCharacteristic != null)
            {
                TempChainWithCharacteristic.CharacteristicSnapshot = (Hashtable) CharacteristicSnapshot.Clone();
                TempChainWithCharacteristic.pIntervals = pIntervals.Clone() as FrequencyList;
                TempChainWithCharacteristic.startinterval = (FrequencyList) startinterval.Clone();
                TempChainWithCharacteristic.endinterval = (FrequencyList) endinterval.Clone();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="Link"></param>
        ///<param name="CharacteristicType"></param>
        ///<returns></returns>
        public double GetCharacteristic(LinkUp Link, ICharacteristicCalculator CharacteristicType)
        {
            if (!CharacteristicSnapshot.ContainsKey(CharacteristicType.GetType()))
            {
                Characteristic temp = new Characteristic(CharacteristicType);
                CharacteristicSnapshot.Add(CharacteristicType.GetType(), temp);
            }
            return InjectIntoCharacteristic(CharacteristicType.GetType(), Link);
        }

        public virtual void CalculateCharacteristicList(ArrayList list)
        {
            foreach (ICharacteristicCalculator calculator in list)
            {
                GetCharacteristic(LinkUp.Start, calculator);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public abstract double InjectIntoCharacteristic(Type type, LinkUp Link);

        protected void MarkChanged()
        {
            IntervalsChanged = true;
            pIntervals = new FrequencyList();
            startinterval = new FrequencyList();
            endinterval = new FrequencyList();
            CharacteristicSnapshot = new Hashtable();
        }

        protected FrequencyList IntervalsStart()
        {
            FrequencyList temp = (FrequencyList) pIntervals.Clone();
            temp.Sum(startinterval);
            return temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public FrequencyList Intervals(LinkUp linkUp)
        {
            BuildIntervals();
            switch (linkUp)
            {
                case LinkUp.Start:
                    return IntervalsStart();
                case LinkUp.End:
                    return IntervalsEnd();
                case LinkUp.Both:
                    return IntervalsBoth();
                default:
                    return null;
            }
        }

        private FrequencyList IntervalsBoth()
        {
            FrequencyList temp = (FrequencyList) pIntervals.Clone();
            temp.Sum(startinterval);
            temp.Sum(endinterval);
            return temp;
        }

        private FrequencyList IntervalsEnd()
        {
            FrequencyList temp = (FrequencyList) pIntervals.Clone();
            temp.Sum(endinterval);
            return temp;
        }

        public override void RemoveAt(Place from)
        {
            base.RemoveAt(from);
            MarkChanged();
        }

        public override void AddItem(IBaseObject value, Place place)
        {
            base.AddItem(value, place);
            MarkChanged();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public new IBin GetBin()
        {
            ChainWithCharacteristicBin Temp = new ChainWithCharacteristicBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public void FillBin(ChainWithCharacteristicBin Bin)
        {
            base.FillBin(Bin);
            foreach (DictionaryEntry entry in CharacteristicSnapshot)
            {
                Bin.Characteristics.Add(((Characteristic) entry.Value).GetBin());
            }

            Bin.CommonIntervals = (FrequencyListBin) IntervalsBoth().GetBin();
            Bin.EndInterval = (FrequencyListBin) IntervalsEnd().GetBin();
            Bin.StartIntervals = (FrequencyListBin) IntervalsStart().GetBin();
        }
    }

    ///<summary>
    ///</summary>
    public class ChainWithCharacteristicBin : BaseChainBin, IBin
    {
        public ArrayList Characteristics = new ArrayList();
        public FrequencyListBin StartIntervals = null;
        public FrequencyListBin CommonIntervals = null;
        public FrequencyListBin EndInterval = null;

        public new IBaseObject GetInstance()
        {
            return null;
        }
    }
}